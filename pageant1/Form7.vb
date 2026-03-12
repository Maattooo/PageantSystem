Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Form7
    Dim cmd As MySqlCommand
    Dim adapter As MySqlDataAdapter
    Dim dt As New DataTable

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGender()
        LoadJudges()
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
            MessageBox.Show("Error loading genders: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadJudges()
        Try
            Dim query As String = "
                SELECT 
                    j.Judge_ID AS 'Judge ID',
                    j.Full_Name AS 'Full Name',
                    j.Password AS 'Password',
                    g.Gender_Name AS 'Assigned Gender'
                FROM judges j
                LEFT JOIN gender g ON j.Gender_ID = g.Gender_ID
                ORDER BY j.Full_Name ASC;"

            adapter = New MySqlDataAdapter(query, con)
            dt = New DataTable()
            adapter.Fill(dt)

            DataGridView1.DataSource = dt
            ConfigureGrid()

            If DataGridView1.Columns.Contains("Judge ID") Then
                DataGridView1.Columns("Judge ID").Visible = False
            End If

            If dt.Rows.Count > 0 Then
                DataGridView1.ClearSelection()
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading judges: " & ex.Message)
        End Try
    End Sub

    Private Sub Insertbtn_Click(sender As Object, e As EventArgs) Handles Insertbtn.Click
        If String.IsNullOrWhiteSpace(fullnametxt.Text) OrElse
           String.IsNullOrWhiteSpace(passwordtxt.Text) OrElse
           gendercmbb.SelectedIndex = -1 Then
            MessageBox.Show("Please fill in all fields before inserting.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Dim checkQuery As String = "SELECT COUNT(*) FROM judges WHERE Full_Name=@name AND Gender_ID=@gender"
            cmd = New MySqlCommand(checkQuery, con)
            cmd.Parameters.AddWithValue("@name", fullnametxt.Text.Trim())
            cmd.Parameters.AddWithValue("@gender", gendercmbb.SelectedValue)
            con.Open()
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            SafeCloseConnection()

            If count > 0 Then
                MessageBox.Show("A judge with this name already exists for this gender!", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim insertQuery As String = "INSERT INTO judges (Full_Name, Password, Gender_ID) VALUES (@name, @password, @gender)"
            cmd = New MySqlCommand(insertQuery, con)
            cmd.Parameters.AddWithValue("@name", fullnametxt.Text.Trim())
            cmd.Parameters.AddWithValue("@password", passwordtxt.Text.Trim())
            cmd.Parameters.AddWithValue("@gender", gendercmbb.SelectedValue)

            con.Open()
            cmd.ExecuteNonQuery()
            SafeCloseConnection()

            MessageBox.Show("Judge added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()
            LoadJudges()
        Catch ex As Exception
            MessageBox.Show("Error inserting judge: " & ex.Message)
            If con.State = ConnectionState.Open Then SafeCloseConnection()
        End Try
    End Sub

    Private Sub Updatebtn_Click(sender As Object, e As EventArgs) Handles Updatebtn.Click
        If DataGridView1.CurrentRow Is Nothing Then
            MessageBox.Show("Please select a judge to update.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Dim judgeID As Integer = Convert.ToInt32(DataGridView1.CurrentRow.Cells("Judge ID").Value)
            Dim query As String = "
                UPDATE judges
                SET Full_Name=@name, Password=@password, Gender_ID=@gender
                WHERE Judge_ID=@id"

            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@name", fullnametxt.Text.Trim())
            cmd.Parameters.AddWithValue("@password", passwordtxt.Text.Trim())
            cmd.Parameters.AddWithValue("@gender", gendercmbb.SelectedValue)
            cmd.Parameters.AddWithValue("@id", judgeID)

            con.Open()
            cmd.ExecuteNonQuery()
            SafeCloseConnection()

            MessageBox.Show("Judge updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()
            LoadJudges()
        Catch ex As Exception
            MessageBox.Show("Error updating judge: " & ex.Message)
            If con.State = ConnectionState.Open Then SafeCloseConnection()
        End Try
    End Sub

    Private Sub Deletebtn_Click(sender As Object, e As EventArgs) Handles Deletebtn.Click
        If DataGridView1.CurrentRow Is Nothing Then
            MessageBox.Show("Please select a judge to delete.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim confirm = MessageBox.Show("Are you sure you want to delete this judge?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirm = DialogResult.No Then Exit Sub

        Try
            Dim judgeID As Integer = Convert.ToInt32(DataGridView1.CurrentRow.Cells("Judge ID").Value)
            Dim query As String = "DELETE FROM judges WHERE Judge_ID=@id"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@id", judgeID)

            con.Open()
            cmd.ExecuteNonQuery()
            SafeCloseConnection()

            MessageBox.Show("Judge deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()
            LoadJudges()
        Catch ex As Exception
            MessageBox.Show("Error deleting judge: " & ex.Message)
            If con.State = ConnectionState.Open Then SafeCloseConnection()
        End Try
    End Sub

    Private Sub ClearFields()
        fullnametxt.Clear()
        passwordtxt.Clear()
        gendercmbb.SelectedIndex = -1
        DataGridView1.ClearSelection()
    End Sub

    Private Sub Clearbtn_Click(sender As Object, e As EventArgs) Handles Clearbtn.Click
        ClearFields()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        fullnametxt.Text = row.Cells("Full Name").Value.ToString()
        passwordtxt.Text = row.Cells("Password").Value.ToString()

        For i As Integer = 0 To gendercmbb.Items.Count - 1
            Dim drv As DataRowView = TryCast(gendercmbb.Items(i), DataRowView)
            If drv IsNot Nothing AndAlso drv("Gender_Name").ToString() = row.Cells("Assigned Gender").Value.ToString() Then
                gendercmbb.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
