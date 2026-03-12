Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form13
    Dim adapter As MySqlDataAdapter
    Dim dt As New DataTable

    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGender()
    End Sub

    Private Sub LoadGender()
        Try
            Dim query As String = "SELECT Gender_ID, Gender_Name FROM gender ORDER BY Gender_Name ASC"
            adapter = New MySqlDataAdapter(query, con)
            Dim genderTable As New DataTable()
            adapter.Fill(genderTable)
            gendercmbb.DataSource = genderTable
            gendercmbb.DisplayMember = "Gender_Name"
            gendercmbb.ValueMember = "Gender_ID"
            gendercmbb.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error loading gender: " & ex.Message)
        End Try
    End Sub

    Private Sub loadbtn_Click(sender As Object, e As EventArgs) Handles loadbtn.Click
        If gendercmbb.SelectedIndex = -1 Then
            MessageBox.Show("Please select a gender.")
            Exit Sub
        End If

        Dim query As String = "
            SELECT c.Contestant_ID, c.Contestant_Number, c.Full_Name, p.Program_Name, c.Picture
            FROM contestants c
            JOIN programs p ON c.Program_ID = p.Program_ID
            WHERE c.Gender_ID = @GenderID
            ORDER BY c.Contestant_Number ASC;"
        Using cmd As New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@GenderID", gendercmbb.SelectedValue)
            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable()
            adapter.Fill(dt)
        End Using

        DataGridView1.Columns.Clear()
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Add("Contestant_ID", "ID")
        DataGridView1.Columns("Contestant_ID").Visible = False
        DataGridView1.Columns.Add("Contestant_Number", "Contestant Number")
        DataGridView1.Columns.Add("Full_Name", "Contestant Name")
        DataGridView1.Columns.Add("Program_Name", "Program")

        Dim imgCol As New DataGridViewImageColumn()
        imgCol.Name = "Picture"
        imgCol.HeaderText = "Picture"
        imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom
        DataGridView1.Columns.Add(imgCol)

        For Each r As DataRow In dt.Rows
            Dim img As Image = Nothing
            If Not IsDBNull(r("Picture")) Then
                Dim imgBytes() As Byte = DirectCast(r("Picture"), Byte())
                Using ms As New MemoryStream(imgBytes)
                    img = Image.FromStream(ms)
                End Using
            End If
            DataGridView1.Rows.Add(r("Contestant_ID"), r("Contestant_Number").ToString(), r("Full_Name").ToString(), r("Program_Name").ToString(), img)
        Next
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        DataGridView1.RowTemplate.Height = 70
        DataGridView1.ScrollBars = ScrollBars.Both

        For Each col As DataGridViewColumn In DataGridView1.Columns
            If TypeOf col Is DataGridViewImageColumn Then
                CType(col, DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Zoom
            End If
        Next

        DataGridView1.Refresh()

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex < 0 OrElse e.RowIndex >= DataGridView1.Rows.Count Then Return

        Try
            Dim row = DataGridView1.Rows(e.RowIndex)
            Dim idCell = row.Cells("Contestant_ID")
            Dim numCell = row.Cells("Contestant_Number")

            If idCell Is Nothing OrElse idCell.Value Is Nothing Then
                MessageBox.Show("Unable to determine contestant ID.")
                Return
            End If

            Dim contestantID As Integer = Convert.ToInt32(idCell.Value)
            Dim contestantNum As String = If(numCell IsNot Nothing, numCell.Value.ToString(), "")

            Form2.SelectedContestantID = contestantID
            Form2.contestantnum.Text = contestantNum
            Form2.LoadContestantDetails(contestantID)
            Form2.Show()
            Me.Hide()
        Catch ex As Exception
            MessageBox.Show("Error opening contestant for edit: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
