Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form2
    Public Property SelectedContestantID As Integer = -1
    Dim cmd As MySqlCommand
    Dim adapter As MySqlDataAdapter
    Dim dt As New DataTable
    Dim selectedImagePath As String = ""
    Private originalImageBytes As Byte() = Nothing
    Private isEditMode As Boolean = False

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGender()
        LoadPrograms()
        If SelectedContestantID <> -1 Then
            LoadContestantDetails(SelectedContestantID)
        End If
    End Sub

    Private Sub LoadGender()
        Try
            Dim query As String = "SELECT Gender_ID, Gender_Name FROM gender ORDER BY Gender_Name ASC"
            adapter = New MySqlDataAdapter(query, con)
            Dim genderTable As New DataTable()
            adapter.Fill(genderTable)
            GenderIDtxt.DataSource = genderTable
            GenderIDtxt.DisplayMember = "Gender_Name"
            GenderIDtxt.ValueMember = "Gender_ID"
            GenderIDtxt.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error loading gender: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadPrograms()
        Try
            Dim query As String = "SELECT Program_ID, Program_Name FROM programs ORDER BY Program_Name ASC"
            adapter = New MySqlDataAdapter(query, con)
            Dim programTable As New DataTable()
            adapter.Fill(programTable)
            programIDtxt.DataSource = programTable
            programIDtxt.DisplayMember = "Program_Name"
            programIDtxt.ValueMember = "Program_ID"
            programIDtxt.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error loading programs: " & ex.Message)
        End Try
    End Sub

    Public Sub LoadContestantDetails(contestantID As Integer)
        Try
            Dim query As String = "SELECT Contestant_Number, Full_Name, Gender_ID, Program_ID, Picture FROM contestants WHERE Contestant_ID = @ContestantID;"
            Using cmd As New MySqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ContestantID", contestantID)
                con.Open()
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        contestantnum.Text = reader("Contestant_Number").ToString()
                        fullnametxt.Text = reader("Full_Name").ToString()
                        If Not IsDBNull(reader("Gender_ID")) Then GenderIDtxt.SelectedValue = Convert.ToInt32(reader("Gender_ID"))
                        If Not IsDBNull(reader("Program_ID")) Then programIDtxt.SelectedValue = Convert.ToInt32(reader("Program_ID"))

                        PictureBox1.Image = Nothing
                        If Not IsDBNull(reader("Picture")) Then
                            originalImageBytes = DirectCast(reader("Picture"), Byte())
                            Using ms As New MemoryStream(originalImageBytes)
                                PictureBox1.Image = Image.FromStream(ms)
                            End Using
                        Else
                            originalImageBytes = Nothing
                            PictureBox1.Image = Nothing
                        End If
                        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
                    End If
                End Using
                isEditMode = True
                Insertbtn.Enabled = False
                Updatebtn.Enabled = True
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading contestant details: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then SafeCloseConnection()
        End Try
    End Sub

    Private Sub browsebtn_Click(sender As Object, e As EventArgs) Handles browsebtn.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        ofd.Title = "Select a Picture"
        If ofd.ShowDialog() = DialogResult.OK Then
            selectedImagePath = ofd.FileName
            PictureBox1.Image = Image.FromFile(selectedImagePath)
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        End If
    End Sub

    Private Sub Insertbtn_Click(sender As Object, e As EventArgs) Handles Insertbtn.Click
        If String.IsNullOrWhiteSpace(fullnametxt.Text) OrElse
           String.IsNullOrWhiteSpace(contestantnum.Text) OrElse
           GenderIDtxt.SelectedIndex = -1 OrElse programIDtxt.SelectedIndex = -1 Then
            MessageBox.Show("Please fill in all required fields.", "Missing Data", MessageBoxButtons.OK)
            Exit Sub
        End If

        Try
            Dim imgBytes() As Byte = Nothing
            If Not String.IsNullOrEmpty(selectedImagePath) Then
                imgBytes = File.ReadAllBytes(selectedImagePath)
            End If

            con.Open()

            If ContestantExists(contestantnum.Text.Trim(), GenderIDtxt.SelectedValue) Then
                MessageBox.Show("A contestant with this number already exists for this gender.")
                Exit Sub
            End If

            Dim insertQuery As String = "
                INSERT INTO contestants (Contestant_Number, Full_Name, Gender_ID, Program_ID, Picture)
                VALUES (@Number, @FullName, @GenderID, @ProgramID, @Picture)"
            Using cmd As New MySqlCommand(insertQuery, con)
                cmd.Parameters.AddWithValue("@Number", contestantnum.Text.Trim())
                cmd.Parameters.AddWithValue("@FullName", fullnametxt.Text.Trim())
                cmd.Parameters.AddWithValue("@GenderID", GenderIDtxt.SelectedValue)
                cmd.Parameters.AddWithValue("@ProgramID", programIDtxt.SelectedValue)
                If imgBytes IsNot Nothing Then
                    cmd.Parameters.Add("@Picture", MySqlDbType.Blob).Value = imgBytes
                Else
                    cmd.Parameters.Add("@Picture", MySqlDbType.Blob).Value = DBNull.Value
                End If
                cmd.ExecuteNonQuery()
            End Using
            MessageBox.Show("Contestant added successfully!", "Success", MessageBoxButtons.OK)
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Error inserting contestant: " & ex.Message)
        Finally
            SafeCloseConnection()
        End Try
    End Sub

    Private Sub Updatebtn_Click(sender As Object, e As EventArgs) Handles Updatebtn.Click
        If SelectedContestantID = -1 Then
            MessageBox.Show("Please select a contestant first.")
            Exit Sub
        End If

        Try
            Dim imgBytes() As Byte

            If Not String.IsNullOrEmpty(selectedImagePath) Then
                imgBytes = File.ReadAllBytes(selectedImagePath)
            Else
                imgBytes = originalImageBytes
            End If


            If ContestantExists(contestantnum.Text.Trim(), GenderIDtxt.SelectedValue, SelectedContestantID) Then
                MessageBox.Show("Another contestant already uses this number.")
                Exit Sub
            End If

            Dim query As String = "
                UPDATE contestants 
                SET Contestant_Number=@Number, Full_Name=@FullName, Gender_ID=@GenderID, Program_ID=@ProgramID, Picture=@Picture
                WHERE Contestant_ID=@ContestantID"
            Using cmd As New MySqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Number", contestantnum.Text.Trim())
                cmd.Parameters.AddWithValue("@FullName", fullnametxt.Text.Trim())
                cmd.Parameters.AddWithValue("@GenderID", GenderIDtxt.SelectedValue)
                cmd.Parameters.AddWithValue("@ProgramID", programIDtxt.SelectedValue)
                If imgBytes IsNot Nothing Then
                    cmd.Parameters.Add("@Picture", MySqlDbType.Blob).Value = imgBytes
                Else
                    cmd.Parameters.Add("@Picture", MySqlDbType.Blob).Value = DBNull.Value
                End If
                cmd.Parameters.AddWithValue("@ContestantID", SelectedContestantID)
                con.Open()
                cmd.ExecuteNonQuery()
                SafeCloseConnection()
            End Using
            MessageBox.Show("Contestant updated successfully!")
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Error updating contestant: " & ex.Message)
            SafeCloseConnection()
        End Try
    End Sub

    Private Sub Deletebtn_Click(sender As Object, e As EventArgs) Handles Deletebtn.Click
        If SelectedContestantID = -1 Then
            MessageBox.Show("Please select a contestant to delete.")
            Exit Sub
        End If

        Dim result = MessageBox.Show("Are you sure you want to delete this contestant?", "Confirm Delete", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then Exit Sub

        Try
            Using delCmd As New MySqlCommand("DELETE FROM contestants WHERE Contestant_ID=@id", con)
                delCmd.Parameters.AddWithValue("@id", SelectedContestantID)
                con.Open()
                delCmd.ExecuteNonQuery()
                SafeCloseConnection()
            End Using
            MessageBox.Show("Contestant deleted successfully.")
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Error deleting contestant: " & ex.Message)
            SafeCloseConnection()
        End Try
    End Sub

    Private Sub ClearFields()
        contestantnum.Clear()
        fullnametxt.Clear()
        GenderIDtxt.SelectedIndex = -1
        programIDtxt.SelectedIndex = -1
        PictureBox1.Image = Nothing
        originalImageBytes = Nothing
        selectedImagePath = ""
        SelectedContestantID = -1
        isEditMode = False
        Insertbtn.Enabled = True
        Updatebtn.Enabled = False
    End Sub

    Private Function ContestantExists(number As String, genderID As Integer, Optional excludeID As Integer = -1) As Boolean
        Dim query As String = "
        SELECT COUNT(*) 
        FROM contestants 
        WHERE Contestant_Number = @num 
        AND Gender_ID = @gid"

        If excludeID <> -1 Then
            query &= " AND Contestant_ID <> @id"
        End If

        Using cmd As New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@num", number)
            cmd.Parameters.AddWithValue("@gid", genderID)

            If excludeID <> -1 Then
                cmd.Parameters.AddWithValue("@id", excludeID)
            End If

            con.Open()
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            SafeCloseConnection()
            Return count > 0
        End Using
    End Function


    Private Sub Clearbtn_Click(sender As Object, e As EventArgs) Handles Clearbtn.Click
        ClearFields()
    End Sub

    Private Sub Viewbtn_Click(sender As Object, e As EventArgs) Handles Viewbtn.Click
        Form13.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class
