Imports MySql.Data.MySqlClient

Public Class Form4
    Dim cmd As MySqlCommand
    Dim adapter As MySqlDataAdapter
    Dim dt As New DataTable

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
        ConfigureGrid()
    End Sub

    Private Sub ConfigureGrid()
        With DataGridView1
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .RowTemplate.Height = 35
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
        End With
    End Sub

    Private Sub LoadData(Optional searchTerm As String = "", Optional searchBy As String = "Gender_ID")
        dt.Clear()
        Dim query As String

        If String.IsNullOrEmpty(searchTerm) Then
            query = "SELECT * FROM gender ORDER BY Gender_ID ASC"
        Else
            If searchBy = "Gender_ID" Then
                query = "SELECT * FROM gender WHERE Gender_ID = @SearchTerm ORDER BY Gender_ID ASC"
            ElseIf searchBy = "Gender_Name" Then
                query = "SELECT * FROM gender WHERE Gender_Name LIKE @SearchTerm ORDER BY Gender_ID ASC"
            Else
                query = "SELECT * FROM gender ORDER BY Gender_ID ASC"
            End If
        End If

        con.Open()
        cmd = New MySqlCommand(query, con)

        If Not String.IsNullOrEmpty(searchTerm) Then
            If searchBy = "Gender_Name" Then
                cmd.Parameters.AddWithValue("@SearchTerm", searchTerm & "%")
            ElseIf searchBy = "Gender_ID" Then
                cmd.Parameters.AddWithValue("@SearchTerm", searchTerm)
            End If
        End If

        adapter = New MySqlDataAdapter(cmd)
        adapter.Fill(dt)
        SafeCloseConnection()

        DataGridView1.DataSource = dt
        ConfigureGrid()

        If dt.Rows.Count > 0 Then
            DataGridView1.ClearSelection()
        End If
    End Sub

    Private Sub Insertbtn_Click(sender As Object, e As EventArgs) Handles Insertbtn.Click
        Try
            Dim query As String = "INSERT INTO gender (Gender_Name) VALUES (@GenderName)"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@GenderName", gendertxt.Text.Trim())

            con.Open()
            cmd.ExecuteNonQuery()
            SafeCloseConnection()

            MessageBox.Show("Gender inserted successfully!")
            LoadData()
            Clearfields()
        Catch ex As Exception
            MessageBox.Show("Error inserting gender: " & ex.Message)
        End Try
    End Sub

    Private Sub Updatebtn_Click(sender As Object, e As EventArgs) Handles Updatebtn.Click
        Try
            If DataGridView1.CurrentRow Is Nothing Then
                MessageBox.Show("Select a gender to update.")
                Exit Sub
            End If

            Dim genderID As Integer = Convert.ToInt32(DataGridView1.CurrentRow.Cells("Gender_ID").Value)
            Dim query As String = "UPDATE gender SET Gender_Name=@GenderName WHERE Gender_ID=@GenderID"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@GenderName", gendertxt.Text.Trim())
            cmd.Parameters.AddWithValue("@GenderID", genderID)

            con.Open()
            cmd.ExecuteNonQuery()
            SafeCloseConnection()

            MessageBox.Show("Gender updated successfully!")
            LoadData()
            Clearfields()
        Catch ex As Exception
            MessageBox.Show("Error updating gender: " & ex.Message)
        End Try
    End Sub

    Private Sub Deletebtn_Click(sender As Object, e As EventArgs) Handles Deletebtn.Click
        Try
            If DataGridView1.CurrentRow Is Nothing Then
                MessageBox.Show("Select a gender to delete.")
                Exit Sub
            End If

            Dim genderID As Integer = Convert.ToInt32(DataGridView1.CurrentRow.Cells("Gender_ID").Value)
            Dim query As String = "DELETE FROM gender WHERE Gender_ID=@GenderID"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@GenderID", genderID)

            con.Open()
            cmd.ExecuteNonQuery()
            SafeCloseConnection()

            MessageBox.Show("Gender deleted successfully!")
            LoadData()
            Clearfields()
        Catch ex As Exception
            MessageBox.Show("Error deleting gender: " & ex.Message)
        End Try
    End Sub

    Private Sub Clearbtn_Click(sender As Object, e As EventArgs) Handles Clearbtn.Click
        Clearfields()
    End Sub

    Private Sub Clearfields()
        gendertxt.Clear()
        DataGridView1.ClearSelection()
        gendertxt.Focus()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            gendertxt.Text = row.Cells("Gender_Name").Value.ToString()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

End Class
