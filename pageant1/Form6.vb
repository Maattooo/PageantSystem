Imports MySql.Data.MySqlClient

Public Class Form6
    Dim cmd As MySqlCommand
    Dim adapter As MySqlDataAdapter
    Dim dt As New DataTable

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub LoadData(Optional searchTerm As String = "", Optional searchBy As String = "Department_ID")
        dt.Clear()
        Dim query As String

        If String.IsNullOrEmpty(searchTerm) Then
            query = "SELECT Department_ID, Department_Name FROM departments ORDER BY Department_ID ASC"
        Else
            If searchBy = "Department_ID" Then
                query = "SELECT Department_ID, Department_Name FROM departments WHERE Department_ID = @SearchTerm ORDER BY Department_ID ASC"
            ElseIf searchBy = "Department_Name" Then
                query = "SELECT Department_ID, Department_Name FROM departments WHERE Department_Name LIKE @SearchTerm ORDER BY Department_Name ASC"
            Else
                query = "SELECT Department_ID, Department_Name FROM departments ORDER BY Department_ID ASC"
            End If
        End If

        con.Open()
        cmd = New MySqlCommand(query, con)

        If Not String.IsNullOrEmpty(searchTerm) Then
            If searchBy = "Department_Name" Then
                cmd.Parameters.AddWithValue("@SearchTerm", searchTerm & "%")
            ElseIf searchBy = "Department_ID" Then
                cmd.Parameters.AddWithValue("@SearchTerm", searchTerm)
            End If
        End If

        adapter = New MySqlDataAdapter(cmd)
        adapter.Fill(dt)
        SafeCloseConnection()

        DataGridView1.DataSource = dt
        ConfigureGrid()

        If DataGridView1.Columns.Contains("Department_ID") Then
            DataGridView1.Columns("Department_ID").Visible = False
        End If

        If dt.Rows.Count > 0 Then
            DataGridView1.ClearSelection()
        End If
    End Sub

    Private Sub Insertbtn_Click(sender As Object, e As EventArgs) Handles Insertbtn.Click
        Try
            Dim query As String = "INSERT INTO departments (Department_Name) VALUES (@DeptName)"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@DeptName", departmentnametxt.Text.Trim())

            con.Open()
            cmd.ExecuteNonQuery()
            SafeCloseConnection()

            MessageBox.Show("Department inserted successfully!")
            LoadData()
            Clearfields()
        Catch ex As Exception
            MessageBox.Show("Error inserting department: " & ex.Message)
        End Try
    End Sub

    Private Sub Updatebtn_Click(sender As Object, e As EventArgs) Handles Updatebtn.Click
        Try
            If DataGridView1.CurrentRow Is Nothing Then
                MessageBox.Show("Select a department to update.")
                Exit Sub
            End If

            Dim deptID As Integer = Convert.ToInt32(DataGridView1.CurrentRow.Cells("Department_ID").Value)
            Dim query As String = "UPDATE departments SET Department_Name=@DeptName WHERE Department_ID=@DeptID"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@DeptName", departmentnametxt.Text.Trim())
            cmd.Parameters.AddWithValue("@DeptID", deptID)

            con.Open()
            cmd.ExecuteNonQuery()
            SafeCloseConnection()

            MessageBox.Show("Department updated successfully!")
            LoadData()
            Clearfields()
        Catch ex As Exception
            MessageBox.Show("Error updating department: " & ex.Message)
        End Try
    End Sub

    Private Sub Deletebtn_Click(sender As Object, e As EventArgs) Handles Deletebtn.Click
        Try
            If DataGridView1.CurrentRow Is Nothing Then
                MessageBox.Show("Select a department to delete.")
                Exit Sub
            End If

            Dim deptID As Integer = Convert.ToInt32(DataGridView1.CurrentRow.Cells("Department_ID").Value)
            Dim query As String = "DELETE FROM departments WHERE Department_ID=@DeptID"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@DeptID", deptID)

            con.Open()
            cmd.ExecuteNonQuery()
            SafeCloseConnection()

            MessageBox.Show("Department deleted successfully!")
            LoadData()
            Clearfields()
        Catch ex As Exception
            MessageBox.Show("Error deleting department: " & ex.Message)
        End Try
    End Sub

    Private Sub Clearbtn_Click(sender As Object, e As EventArgs) Handles Clearbtn.Click
        Clearfields()
    End Sub

    Private Sub Clearfields()
        departmentnametxt.Clear()
        DataGridView1.ClearSelection()
        departmentnametxt.Focus()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            departmentnametxt.Text = row.Cells("Department_Name").Value.ToString()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
