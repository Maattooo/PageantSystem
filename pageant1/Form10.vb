Imports MySql.Data.MySqlClient

Public Class Form10
    Dim cmd As MySqlCommand
    Dim adapter As MySqlDataAdapter
    Dim dt As New DataTable

    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadJudges()
    End Sub

    Private Sub LoadJudges()
        Try
            Dim query As String = "SELECT Judge_ID, Full_Name FROM judges ORDER BY Full_Name ASC"
            Dim judgeAdapter As New MySqlDataAdapter(query, con)
            Dim judgeTable As New DataTable()
            judgeAdapter.Fill(judgeTable)

            fullnametxt.DataSource = judgeTable
            fullnametxt.DisplayMember = "Full_Name"
            fullnametxt.ValueMember = "Judge_ID"
            fullnametxt.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error loading judges: " & ex.Message)
        End Try
    End Sub

    Private Sub loginbtn_Click(sender As Object, e As EventArgs) Handles loginbtn.Click

        If fullnametxt.Text = "admin" And passwordtxt.Text = "admin" Then
            Form1.Show()
            Me.Hide()
            Exit Sub
        ElseIf fullnametxt.SelectedIndex = -1 Then
            MessageBox.Show("Please select your name.")
            Exit Sub
        End If

        If passwordtxt.Text.Trim() = "" Then
            MessageBox.Show("Please enter your password.")
            Exit Sub
        End If

        Try
            Dim query As String = "SELECT * FROM judges WHERE Judge_ID=@JudgeID AND Password=@Password"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@JudgeID", fullnametxt.SelectedValue)
            cmd.Parameters.AddWithValue("@Password", passwordtxt.Text.Trim())

            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable()
            adapter.Fill(dt)

            If dt.Rows.Count > 0 Then
                Dim judgeID As Integer = Convert.ToInt32(dt.Rows(0)("Judge_ID"))
                Dim judgeName As String = dt.Rows(0)("Full_Name").ToString()
                Dim judgeGender As Integer = 0
                If Not IsDBNull(dt.Rows(0)("Gender_ID")) Then
                    Integer.TryParse(dt.Rows(0)("Gender_ID").ToString(), judgeGender)
                End If

                Dim categoryForm As New Form14()
                categoryForm.judgeID = judgeID
                categoryForm.judgeName = judgeName
                categoryForm.judgeGender = judgeGender
                categoryForm.Show()
                passwordtxt.Clear()
                Me.Hide()
            Else
                MessageBox.Show("Invalid password. Please try again.")
                passwordtxt.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show("Error logging in: " & ex.Message)
        End Try
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Application.Exit()
    End Sub

End Class
