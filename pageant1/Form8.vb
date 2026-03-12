Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Form8
    Dim cmd As MySqlCommand
    Dim adapter As MySqlDataAdapter
    Dim dt As New DataTable

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMainCriteria()
        LoadGrid()
    End Sub

    Private Sub LoadMainCriteria()
        Try
            Dim query As String = "SELECT Criteria_ID, Criteria_Name FROM criteria ORDER BY Criteria_Name ASC;"
            adapter = New MySqlDataAdapter(query, con)
            Dim table As New DataTable()
            adapter.Fill(table)
            criterialistcmbb.DataSource = table
            criterialistcmbb.DisplayMember = "Criteria_Name"
            criterialistcmbb.ValueMember = "Criteria_ID"
            criterialistcmbb.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error loading criteria list: " & ex.Message)
        End Try
    End Sub

    Private Sub MainInsertbtn_Click(sender As Object, e As EventArgs) Handles MainInsertbtn.Click
        If String.IsNullOrWhiteSpace(maincriteriatxt.Text) Then
            MessageBox.Show("Please enter a main criteria name.")
            Exit Sub
        End If

        For Each item As DataRowView In criterialistcmbb.Items
            If String.Equals(item("Criteria_Name").ToString(), maincriteriatxt.Text.Trim(), StringComparison.OrdinalIgnoreCase) Then
                MessageBox.Show("This main criteria already exists. Please choose a different name.", "Duplicate Entry", MessageBoxButtons.OK)
                Exit Sub
            End If
        Next

        Try
            con.Open()
            Dim query As String = "INSERT INTO criteria (Criteria_Name) VALUES (@name)"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@name", maincriteriatxt.Text.Trim())
            cmd.ExecuteNonQuery()
            SafeCloseConnection()

            MessageBox.Show("Main criteria added successfully!")
            ClearMain()
            LoadMainCriteria()
            LoadGrid()
        Catch ex As Exception
            MessageBox.Show("Error adding main criteria: " & ex.Message)
            SafeCloseConnection()
        End Try
    End Sub

    Private Sub MainUpdatebtn_Click(sender As Object, e As EventArgs) Handles MainUpdatebtn.Click
        If criterialistcmbb.SelectedIndex = -1 Then
            MessageBox.Show("Please select a main criteria to update.")
            Exit Sub
        End If

        Try
            con.Open()
            Dim query As String = "UPDATE criteria SET Criteria_Name=@name WHERE Criteria_ID=@id"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@name", maincriteriatxt.Text.Trim())
            cmd.Parameters.AddWithValue("@id", criterialistcmbb.SelectedValue)
            cmd.ExecuteNonQuery()
            SafeCloseConnection()

            MessageBox.Show("Main criteria updated successfully!")
            ClearMain()
            LoadMainCriteria()
            LoadGrid()
        Catch ex As Exception
            MessageBox.Show("Error updating main criteria: " & ex.Message)
            SafeCloseConnection()
        End Try
    End Sub

    Private Sub MainDeletebtn_Click(sender As Object, e As EventArgs) Handles MainDeletebtn.Click
        If criterialistcmbb.SelectedIndex = -1 Then
            MessageBox.Show("Please select a main criteria to delete.")
            Exit Sub
        End If

        Dim result = MessageBox.Show("Deleting this main criteria will also delete all its subcriteria. Continue?", "Confirm Delete", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then Exit Sub

        Try
            con.Open()
            Dim delSub As String = "DELETE FROM subcriteria WHERE Criteria_ID=@id"
            cmd = New MySqlCommand(delSub, con)
            cmd.Parameters.AddWithValue("@id", criterialistcmbb.SelectedValue)
            cmd.ExecuteNonQuery()

            Dim delMain As String = "DELETE FROM criteria WHERE Criteria_ID=@id"
            cmd = New MySqlCommand(delMain, con)
            cmd.Parameters.AddWithValue("@id", criterialistcmbb.SelectedValue)
            cmd.ExecuteNonQuery()

            SafeCloseConnection()
            MessageBox.Show("Main criteria deleted successfully!")

            ClearMain()
            LoadMainCriteria()
            LoadGrid()
        Catch ex As Exception
            MessageBox.Show("Error deleting main criteria: " & ex.Message)
            SafeCloseConnection()
        End Try
    End Sub

    Private Sub MainClearbtn_Click(sender As Object, e As EventArgs) Handles MainClearbtn.Click
        ClearMain()
    End Sub

    Private Sub ClearMain()
        maincriteriatxt.Clear()
        criterialistcmbb.SelectedIndex = -1
    End Sub

    Private Sub criterialistcmbb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles criterialistcmbb.SelectedIndexChanged
        If criterialistcmbb.SelectedIndex <> -1 Then
            maincriteriatxt.Text = criterialistcmbb.Text
        End If
    End Sub

    Private Sub SubInsertbtn_Click(sender As Object, e As EventArgs) Handles SubInsertbtn.Click
        If criterialistcmbb.SelectedIndex = -1 Then
            MessageBox.Show("Please select a main criteria first.")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(subcriteriatxt.Text) OrElse
           String.IsNullOrWhiteSpace(mintxt.Text) OrElse
           String.IsNullOrWhiteSpace(maxtxt.Text) Then
            MessageBox.Show("Please fill in all subcriteria fields.")
            Exit Sub
        End If

        Try
            con.Open()
            Dim query As String = "INSERT INTO subcriteria (Criteria_ID, SubCriteria_Name, Min_Score, Max_Score)
                                   VALUES (@cid, @name, @min, @max)"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@cid", criterialistcmbb.SelectedValue)
            cmd.Parameters.AddWithValue("@name", subcriteriatxt.Text.Trim())
            cmd.Parameters.AddWithValue("@min", Convert.ToDecimal(mintxt.Text))
            cmd.Parameters.AddWithValue("@max", Convert.ToDecimal(maxtxt.Text))
            cmd.ExecuteNonQuery()
            SafeCloseConnection()

            MessageBox.Show("Subcriteria added successfully!")
            ClearSub()
            LoadGrid()
        Catch ex As Exception
            MessageBox.Show("Error adding subcriteria: " & ex.Message)
            SafeCloseConnection()
        End Try
    End Sub

    Private Sub SubUpdatebtn_Click(sender As Object, e As EventArgs) Handles SubUpdatebtn.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a subcriteria from the list to update.")
            Exit Sub
        End If

        Dim subId As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("SubCriteria_ID").Value)

        Try
            con.Open()
            Dim query As String = "UPDATE subcriteria SET SubCriteria_Name=@name, Min_Score=@min, Max_Score=@max WHERE SubCriteria_ID=@id"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@name", subcriteriatxt.Text.Trim())
            cmd.Parameters.AddWithValue("@min", Convert.ToDecimal(mintxt.Text))
            cmd.Parameters.AddWithValue("@max", Convert.ToDecimal(maxtxt.Text))
            cmd.Parameters.AddWithValue("@id", subId)
            cmd.ExecuteNonQuery()
            SafeCloseConnection()

            MessageBox.Show("Subcriteria updated successfully!")
            ClearSub()
            LoadGrid()
        Catch ex As Exception
            MessageBox.Show("Error updating subcriteria: " & ex.Message)
            SafeCloseConnection()
        End Try
    End Sub
    Private Sub SubDeletebtn_Click(sender As Object, e As EventArgs) Handles SubDeletebtn.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a subcriteria to delete.")
            Exit Sub
        End If

        Dim selRow As DataGridViewRow = DataGridView1.SelectedRows(0)

        If Not DataGridView1.Columns.Contains("SubCriteria_ID") Then
            MessageBox.Show("Internal error: SubCriteria_ID column missing.")
            Exit Sub
        End If

        Dim idCell = selRow.Cells("SubCriteria_ID")
        If idCell Is Nothing OrElse idCell.Value Is Nothing OrElse Convert.IsDBNull(idCell.Value) Then
            MessageBox.Show("Please select a subcriteria to delete.")
            Exit Sub
        End If

        Dim subId As Integer
        If Not Integer.TryParse(idCell.Value.ToString(), subId) Then
            MessageBox.Show("Invalid subcriteria selection.")
            Exit Sub
        End If

        Dim result = MessageBox.Show("Are you sure you want to delete this subcriteria?", "Confirm Delete", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then Exit Sub

        Try
            con.Open()
            Dim query As String = "DELETE FROM subcriteria WHERE SubCriteria_ID=@id"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@id", subId)
            Dim affected As Integer = cmd.ExecuteNonQuery()
            SafeCloseConnection()

            If affected > 0 Then
                MessageBox.Show("Subcriteria deleted successfully!")
                ClearSub()
                LoadGrid()
            Else
                MessageBox.Show("No subcriteria deleted. It may already be removed.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error deleting subcriteria: " & ex.Message)
            If con.State = ConnectionState.Open Then SafeCloseConnection()
        End Try
    End Sub

    Private Sub SubClearbtn_Click(sender As Object, e As EventArgs) Handles SubClearbtn.Click
        ClearSub()
    End Sub

    Private Sub ClearSub()
        subcriteriatxt.Clear()
        mintxt.Clear()
        maxtxt.Clear()
    End Sub

    Private Sub LoadGrid()
        Try
            Dim query As String = "SELECT c.Criteria_ID, s.SubCriteria_ID, c.Criteria_Name AS 'Main Criteria', s.SubCriteria_Name AS 'Sub Criteria', s.Min_Score AS 'Min Score', s.Max_Score AS 'Max Score' FROM criteria c LEFT JOIN subcriteria s ON c.Criteria_ID = s.Criteria_ID ORDER BY c.Criteria_Name, s.SubCriteria_Name;"

            adapter = New MySqlDataAdapter(query, con)
            dt = New DataTable()
            adapter.Fill(dt)
            DataGridView1.DataSource = dt
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.MultiSelect = False
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.ReadOnly = True
            If DataGridView1.Columns.Contains("Criteria_ID") Then DataGridView1.Columns("Criteria_ID").Visible = False
            If DataGridView1.Columns.Contains("SubCriteria_ID") Then DataGridView1.Columns("SubCriteria_ID").Visible = False

        Catch ex As Exception
            MessageBox.Show("Error loading data grid: " & ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex < 0 Then Exit Sub

        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        maincriteriatxt.Text = row.Cells("Main Criteria").Value.ToString()
        subcriteriatxt.Text = row.Cells("Sub Criteria").Value.ToString()
        mintxt.Text = row.Cells("Min Score").Value.ToString()
        maxtxt.Text = row.Cells("Max Score").Value.ToString()

        For i As Integer = 0 To criterialistcmbb.Items.Count - 1
            Dim drv As DataRowView = TryCast(criterialistcmbb.Items(i), DataRowView)
            If drv IsNot Nothing AndAlso drv("Criteria_Name").ToString() = row.Cells("Main Criteria").Value.ToString() Then
                criterialistcmbb.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class
