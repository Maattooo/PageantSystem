Imports MySql.Data.MySqlClient

Public Class Form5
    Dim cmd As MySqlCommand
    Dim adapter As MySqlDataAdapter
    Dim dt As New DataTable

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDepartments()
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

    Private Sub LoadDepartments()
        Try
            Dim query As String = "SELECT Department_ID, Department_Name FROM departments ORDER BY Department_Name ASC"
            Dim deptAdapter As New MySqlDataAdapter(query, con)
            Dim deptTable As New DataTable()
            deptAdapter.Fill(deptTable)

            departmentIDtxt.DataSource = deptTable
            departmentIDtxt.DisplayMember = "Department_Name"
            departmentIDtxt.ValueMember = "Department_ID"
            departmentIDtxt.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadData(Optional searchTerm As String = "", Optional searchBy As String = "Program_ID")
        dt.Clear()
        Dim query As String

        If String.IsNullOrEmpty(searchTerm) Then
            query = "SELECT p.Program_ID, p.Program_Name, d.Department_Name 
                     FROM programs p 
                     JOIN departments d ON p.Department_ID = d.Department_ID
                     ORDER BY p.Program_ID ASC"
        Else
            If searchBy = "Program_ID" Then
                query = "SELECT p.Program_ID, p.Program_Name, d.Department_Name 
                         FROM programs p 
                         JOIN departments d ON p.Department_ID = d.Department_ID
                         WHERE p.Program_ID = @SearchTerm
                         ORDER BY p.Program_ID ASC"
            ElseIf searchBy = "Program_Name" Then
                query = "SELECT p.Program_ID, p.Program_Name, d.Department_Name 
                         FROM programs p 
                         JOIN departments d ON p.Department_ID = d.Department_ID
                         WHERE p.Program_Name LIKE @SearchTerm
                         ORDER BY p.Program_ID ASC"
            Else
                query = "SELECT p.Program_ID, p.Program_Name, d.Department_Name 
                         FROM programs p 
                         JOIN departments d ON p.Department_ID = d.Department_ID
                         ORDER BY p.Program_ID ASC"
            End If
        End If

        con.Open()
        cmd = New MySqlCommand(query, con)

        If Not String.IsNullOrEmpty(searchTerm) Then
            If searchBy = "Program_Name" Then
                cmd.Parameters.AddWithValue("@SearchTerm", searchTerm & "%")
            ElseIf searchBy = "Program_ID" Then
                cmd.Parameters.AddWithValue("@SearchTerm", searchTerm)
            End If
        End If

        adapter = New MySqlDataAdapter(cmd)
        adapter.Fill(dt)
        SafeCloseConnection()

        DataGridView1.DataSource = dt
        ConfigureGrid()

        If DataGridView1.Columns.Contains("Program_ID") Then
            DataGridView1.Columns("Program_ID").Visible = False
        End If

        If dt.Rows.Count > 0 Then
            DataGridView1.ClearSelection()
        End If
    End Sub

    Private Sub Insertbtn_Click(sender As Object, e As EventArgs) Handles Insertbtn.Click
        Try
            Dim query As String = "INSERT INTO programs (Program_Name, Department_ID) VALUES (@ProgramName, @DepartmentID)"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@ProgramName", programnametxt.Text.Trim())
            cmd.Parameters.AddWithValue("@DepartmentID", departmentIDtxt.SelectedValue)

            con.Open()
            cmd.ExecuteNonQuery()
            SafeCloseConnection()

            MessageBox.Show("Program inserted successfully!")
            LoadData()
            Clearfields()
        Catch ex As Exception
            MessageBox.Show("Error inserting program: " & ex.Message)
        End Try
    End Sub

    Private Sub Updatebtn_Click(sender As Object, e As EventArgs) Handles Updatebtn.Click
        Try
            If DataGridView1.CurrentRow Is Nothing Then
                MessageBox.Show("Select a program to update.")
                Exit Sub
            End If

            Dim programID As Integer = Convert.ToInt32(DataGridView1.CurrentRow.Cells("Program_ID").Value)
            Dim query As String = "UPDATE programs SET Program_Name=@ProgramName, Department_ID=@DepartmentID WHERE Program_ID=@ProgramID"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@ProgramName", programnametxt.Text.Trim())
            cmd.Parameters.AddWithValue("@DepartmentID", departmentIDtxt.SelectedValue)
            cmd.Parameters.AddWithValue("@ProgramID", programID)

            con.Open()
            cmd.ExecuteNonQuery()
            SafeCloseConnection()

            MessageBox.Show("Program updated successfully!")
            LoadData()
            Clearfields()
        Catch ex As Exception
            MessageBox.Show("Error updating program: " & ex.Message)
        End Try
    End Sub

    Private Sub Deletebtn_Click(sender As Object, e As EventArgs) Handles Deletebtn.Click
        Try
            If DataGridView1.CurrentRow Is Nothing Then
                MessageBox.Show("Select a program to delete.")
                Exit Sub
            End If

            Dim programID As Integer = Convert.ToInt32(DataGridView1.CurrentRow.Cells("Program_ID").Value)
            Dim query As String = "DELETE FROM programs WHERE Program_ID=@ProgramID"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@ProgramID", programID)

            con.Open()
            cmd.ExecuteNonQuery()
            SafeCloseConnection()

            MessageBox.Show("Program deleted successfully!")
            LoadData()
            Clearfields()
        Catch ex As Exception
            MessageBox.Show("Error deleting program: " & ex.Message)
        End Try
    End Sub

    Private Sub Clearbtn_Click(sender As Object, e As EventArgs) Handles Clearbtn.Click
        Clearfields()
    End Sub

    Private Sub Clearfields()
        programnametxt.Clear()
        departmentIDtxt.SelectedIndex = -1
        DataGridView1.ClearSelection()
        programnametxt.Focus()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            programnametxt.Text = row.Cells("Program_Name").Value.ToString()
            If departmentIDtxt IsNot Nothing Then
                Dim deptName As String = row.Cells("Department_Name").Value.ToString()
                departmentIDtxt.SelectedIndex = departmentIDtxt.FindStringExact(deptName)

            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class
