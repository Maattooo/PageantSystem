Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Form9
    Dim cmd As MySqlCommand
    Dim adapter As MySqlDataAdapter
    Dim dt As DataTable

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCriteria()
        LoadGender()
        ConfigureGrid()
    End Sub

    Private Sub ConfigureGrid()
        With DataGridView1
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .RowTemplate.Height = 60
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True

            For Each col As DataGridViewColumn In .Columns
                If TypeOf col Is DataGridViewImageColumn Then
                    col.Width = 80
                    CType(col, DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Zoom
                End If
            Next
        End With
    End Sub

    Private Sub LoadGender()
        Dim q As String = "SELECT Gender_ID, Gender_Name FROM gender ORDER BY Gender_Name ASC"
        adapter = New MySqlDataAdapter(q, con)
        dt = New DataTable()
        adapter.Fill(dt)
        gendercmbb.DataSource = dt
        gendercmbb.DisplayMember = "Gender_Name"
        gendercmbb.ValueMember = "Gender_ID"
        gendercmbb.SelectedIndex = -1
    End Sub

    Private Sub LoadCriteria()
        Dim q As String = "SELECT Criteria_ID, Criteria_Name FROM criteria ORDER BY Criteria_Name ASC"
        adapter = New MySqlDataAdapter(q, con)
        dt = New DataTable()
        adapter.Fill(dt)
        criteriacmb.DataSource = dt
        criteriacmb.DisplayMember = "Criteria_Name"
        criteriacmb.ValueMember = "Criteria_ID"
        criteriacmb.SelectedIndex = -1
    End Sub

    Private Sub Clearbtn_Click(sender As Object, e As EventArgs) Handles Clearbtn.Click
        criteriacmb.SelectedIndex = -1
        DataGridView1.DataSource = Nothing
    End Sub

    Private Sub loadbtn_Click(sender As Object, e As EventArgs) Handles loadbtn.Click
        If criteriacmb.SelectedIndex = -1 Or gendercmbb.SelectedIndex = -1 Then
            MessageBox.Show("Please select Gender and Criteria.")
            Exit Sub
        End If

        Try

            Dim subcriteriaQuery As String = "SELECT SubCriteria_ID, SubCriteria_Name FROM subcriteria WHERE Criteria_ID=@crid ORDER BY SubCriteria_ID"
            Dim subDt As New DataTable()
            Using cmd As New MySqlCommand(subcriteriaQuery, con)
                cmd.Parameters.AddWithValue("@crid", criteriacmb.SelectedValue)
                adapter = New MySqlDataAdapter(cmd)
                adapter.Fill(subDt)
            End Using

            Dim subcriteriaColumns As String = String.Join(", ", subDt.AsEnumerable().Select(Function(r) $"MAX(CASE WHEN s.SubCriteria_ID={r("SubCriteria_ID")} THEN sc.Score ELSE 0 END) AS `{r("SubCriteria_Name")}`"))

            Dim query As String = $"
            SELECT 
                c.Picture,
                c.Contestant_Number,
                c.Full_Name AS Contestant_Name,
                j.Full_Name AS Judge_Name,
                cr.Criteria_Name,
                {subcriteriaColumns},
                ({String.Join(" + ", subDt.AsEnumerable().Select(Function(r) $"MAX(CASE WHEN s.SubCriteria_ID={r("SubCriteria_ID")} THEN sc.Score ELSE 0 END)"))}) AS TotalScore
            FROM contestants c
            LEFT JOIN scores sc ON sc.Contestant_ID = c.Contestant_ID AND sc.Criteria_ID=@crid
            LEFT JOIN judges j ON sc.Judge_ID = j.Judge_ID
            LEFT JOIN subcriteria s ON sc.SubCriteria_ID = s.SubCriteria_ID
            LEFT JOIN criteria cr ON sc.Criteria_ID = cr.Criteria_ID
            WHERE c.Gender_ID=@gender
            GROUP BY c.Contestant_ID, j.Judge_ID
            ORDER BY c.Contestant_ID, j.Judge_ID;"

            Dim dt As New DataTable()
            Using cmd As New MySqlCommand(query, con)
                cmd.Parameters.AddWithValue("@crid", criteriacmb.SelectedValue)
                cmd.Parameters.AddWithValue("@gender", gendercmbb.SelectedValue)
                adapter = New MySqlDataAdapter(cmd)
                adapter.Fill(dt)
            End Using

            If dt.Rows.Count = 0 Then
                MessageBox.Show("No scores found.")
                DataGridView1.DataSource = Nothing
                Exit Sub
            End If

            DataGridView1.Columns.Clear()
            Dim imgCol As New DataGridViewImageColumn() With {.HeaderText = "Picture", .ImageLayout = DataGridViewImageCellLayout.Zoom}
            DataGridView1.Columns.Add(imgCol)
            DataGridView1.Columns.Add("Contestant_Number", "Contestant Number")
            DataGridView1.Columns.Add("Contestant_Name", "Contestant Name")
            DataGridView1.Columns.Add("Judge_Name", "Judge")
            DataGridView1.Columns.Add("Criteria_Name", "Criteria")

            For Each r As DataRow In subDt.Rows
                DataGridView1.Columns.Add(r("SubCriteria_Name").ToString(), r("SubCriteria_Name").ToString())
            Next

            DataGridView1.Columns.Add("TotalScore", "Total")

            For Each r As DataRow In dt.Rows
                Dim img As Image = Nothing
                If Not IsDBNull(r("Picture")) Then
                    Dim bytes As Byte() = DirectCast(r("Picture"), Byte())
                    Using ms As New MemoryStream(bytes)
                        img = Image.FromStream(ms)
                    End Using
                End If

                Dim rowValues As New List(Of Object) From {
        img,
        r("Contestant_Number"),
        r("Contestant_Name"),
        r("Judge_Name"),
        r("Criteria_Name")
    }

                For Each scRow As DataRow In subDt.Rows
                    rowValues.Add(r(scRow("SubCriteria_Name").ToString()))
                Next

                rowValues.Add(r("TotalScore"))

                DataGridView1.Rows.Add(rowValues.ToArray())
            Next

            ConfigureGrid()
            DataGridView1.Columns("TotalScore").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Catch ex As Exception
            MessageBox.Show("Error loading contestants: " & ex.Message)
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub
End Class
