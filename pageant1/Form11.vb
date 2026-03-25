Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Form11
    Public judgeID As Integer = 0
    Public judgeName As String = ""
    Public criteriaName As String = ""
    Public judgeGender As Integer = 0
    Public selectedCriteriaID As Integer
    Public selectedCriteriaName As String
    Public assignedGenderID As Integer
    Private isLoadingContestants As Boolean = False


    Dim cmd As MySqlCommand
    Dim adapter As MySqlDataAdapter
    Dim dt As DataTable
    Dim contestants As New List(Of DataRow)

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Judgeinfo.Text = "Judge: " & judgeName
        assignedgender.Text = If(judgeGender = 1, "Male", "Female")
        category.Text = selectedCriteriaName

        Dim basePath As String = Path.Combine(Application.StartupPath, "Pictures")
        Dim imageFile As String = ""
        Dim genderFolder As String = If(judgeGender = 1, "Male", "Female")
        Dim folderPath As String = Path.Combine(basePath, genderFolder)

        Select Case selectedCriteriaName
            Case "School Uniform"
                imageFile = Path.Combine(folderPath, "school_uniform.png")
            Case "Shorts Wear"
                imageFile = Path.Combine(folderPath, "shorts_wear.png")
            Case "Formal Wear"
                imageFile = Path.Combine(folderPath, "formal_wear.png")
            Case "Mr and Ms"
                imageFile = Path.Combine(folderPath, "finals.png")
            Case Else
                imageFile = Path.Combine(folderPath, "default.png")
        End Select

        If File.Exists(imageFile) Then
            PictureBox2.Image = Image.FromFile(imageFile)
            PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        Else
            PictureBox2.Image = Nothing
        End If

        LoadSubCriteria()
        LoadContestants()
    End Sub


    Private Sub LoadSubCriteria()
        Dim query As String = "SELECT SubCriteria_ID, SubCriteria_Name, Min_Score, Max_Score 
                               FROM subcriteria WHERE Criteria_ID=@cid ORDER BY SubCriteria_ID ASC"
        cmd = New MySqlCommand(query, con)
        cmd.Parameters.AddWithValue("@cid", selectedCriteriaID)
        adapter = New MySqlDataAdapter(cmd)
        dt = New DataTable()
        adapter.Fill(dt)

        If dt.Rows.Count >= 3 Then
            sub1.Text = dt.Rows(0)("SubCriteria_Name").ToString()
            Label2.Text = dt.Rows(1)("SubCriteria_Name").ToString()
            Label3.Text = dt.Rows(2)("SubCriteria_Name").ToString()
            min1.Text = dt.Rows(0)("Min_Score").ToString()
            min2.Text = dt.Rows(1)("Min_Score").ToString()
            min3.Text = dt.Rows(2)("Min_Score").ToString()
            max1.Text = dt.Rows(0)("Max_Score").ToString()
            max2.Text = dt.Rows(1)("Max_Score").ToString()
            max3.Text = dt.Rows(2)("Max_Score").ToString()
        End If
    End Sub

    Private Sub LoadContestants()
        If judgeID <= 0 Then
            contestants = New List(Of DataRow)
            Return
        End If

        Dim query As String

        If selectedCriteriaName = "Mr and Ms" Then
            query = "
            WITH JudgeTotals AS (
                SELECT 
                    s.Judge_ID,
                    s.Contestant_ID,
                    sc.Criteria_ID,
                    SUM(s.Score) AS judge_total
                FROM scores s
                JOIN subcriteria sc ON s.SubCriteria_ID = sc.SubCriteria_ID
                JOIN criteria cr ON sc.Criteria_ID = cr.Criteria_ID
                WHERE cr.Criteria_Name IN ('School Uniform', 'Shorts Wear', 'Formal Wear')
                GROUP BY s.Judge_ID, s.Contestant_ID, sc.Criteria_ID
            ),
            CriteriaAverages AS (
                SELECT 
                    Contestant_ID,
                    Criteria_ID,
                    ROUND(AVG(judge_total),2) AS avg_per_criteria
                FROM JudgeTotals
                GROUP BY Contestant_ID, Criteria_ID
            ),
            ContestantAverages AS (
                SELECT 
                    c.Contestant_ID,
                    AVG(ca.avg_per_criteria) AS overall_average
                FROM CriteriaAverages ca
                JOIN contestants c ON ca.Contestant_ID = c.Contestant_ID
                WHERE c.Gender_ID = @gid
                GROUP BY c.Contestant_ID
            )
            SELECT 
                c.Contestant_ID,
                c.Contestant_Number,
                c.Full_Name,
                p.Program_Name,
                g.Gender_Name,
                c.Picture
            FROM ContestantAverages ca
            JOIN contestants c ON ca.Contestant_ID = c.Contestant_ID
            JOIN programs p ON c.Program_ID = p.Program_ID
            JOIN gender g ON c.Gender_ID = g.Gender_ID
            WHERE c.Gender_ID = @gid
            ORDER BY ca.overall_average DESC
            LIMIT 5;"
        Else
            query = "
            SELECT 
                c.Contestant_ID, 
                c.Contestant_Number,
                c.Full_Name, 
                p.Program_Name, 
                g.Gender_Name, 
                c.Picture
            FROM contestants c
            JOIN programs p ON c.Program_ID = p.Program_ID
            JOIN gender g ON c.Gender_ID = g.Gender_ID
            WHERE c.Gender_ID = (SELECT Gender_ID FROM judges WHERE Judge_ID = @jid)
            ORDER BY c.Contestant_Number ASC;"
        End If

        cmd = New MySqlCommand(query, con)
        cmd.Parameters.AddWithValue("@jid", judgeID)
        cmd.Parameters.AddWithValue("@gid", judgeGender)

        adapter = New MySqlDataAdapter(cmd)
        dt = New DataTable()

        Try
            isLoadingContestants = True
            adapter.Fill(dt)
            contestants = dt.AsEnumerable().ToList()

            If dt.Rows.Count > 0 Then
                contestantcmbb.DataSource = Nothing
                contestantcmbb.DataSource = dt
                contestantcmbb.DisplayMember = "Contestant_Number"
                contestantcmbb.ValueMember = "Contestant_ID"

                Me.BeginInvoke(Sub()
                                   isLoadingContestants = False
                                   If contestantcmbb.Items.Count > 0 Then
                                       contestantcmbb.SelectedIndex = 0
                                       LoadContestantInfo()
                                       LoadPreviousScores()
                                       UpdateProgress()

                                   End If
                               End Sub)

            Else
                contestantcmbb.DataSource = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading contestants: " & ex.Message)
        End Try
    End Sub

    Private Sub prebtn_Click(sender As Object, e As EventArgs) Handles prebtn.Click
        If contestantcmbb.Items.Count = 0 Then Exit Sub
        If contestantcmbb.SelectedIndex > 0 Then
            contestantcmbb.SelectedIndex -= 1
        Else
            contestantcmbb.SelectedIndex = contestantcmbb.Items.Count - 1
        End If
    End Sub

    Private Sub nextbtn_Click(sender As Object, e As EventArgs) Handles nextbtn.Click
        If contestantcmbb.Items.Count = 0 Then Exit Sub
        If contestantcmbb.SelectedIndex < contestantcmbb.Items.Count - 1 Then
            contestantcmbb.SelectedIndex += 1
        Else
            contestantcmbb.SelectedIndex = 0
        End If
    End Sub

    Private Sub contestantcmbb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles contestantcmbb.SelectedIndexChanged
        If isLoadingContestants Then Exit Sub
        If contestantcmbb.SelectedIndex < 0 Then Exit Sub
        If contestantcmbb.SelectedValue Is Nothing Then Exit Sub
        If Not IsNumeric(contestantcmbb.SelectedValue) Then Exit Sub

        LoadContestantInfo()
        LoadPreviousScores()
        UpdateProgress()
    End Sub


    Private Sub UpdateProgress()
        Try
            Dim scoredCount As Integer = 0
            Dim totalCount As Integer = 0
            Dim query As String
            Dim cmd As MySqlCommand

            If selectedCriteriaName = "Mr and Ms" Then

                query = "
                SELECT 
                    COUNT(DISTINCT s.Contestant_ID) AS ScoredCount,
                    5 AS TotalCount
                FROM scores s
                JOIN contestants c ON s.Contestant_ID = c.Contestant_ID
                WHERE s.Judge_ID = @jid 
                  AND s.Criteria_ID = @cid 
                  AND c.Contestant_ID IN (
                      SELECT Contestant_ID
                      FROM (
                          SELECT ca.Contestant_ID
                          FROM (
                              SELECT s.Contestant_ID, AVG(s.Score) AS avg_score
                              FROM scores s
                              JOIN subcriteria sc ON s.SubCriteria_ID = sc.SubCriteria_ID
                              JOIN criteria cr ON sc.Criteria_ID = cr.Criteria_ID
                              WHERE cr.Criteria_Name IN ('School Uniform','Shorts Wear','Formal Wear')
                              GROUP BY s.Contestant_ID
                              ORDER BY avg_score DESC
                              LIMIT 5
                          ) AS ca
                      ) AS top5
                  )
                  AND c.Gender_ID = @gid;"
            Else

                query = "
                SELECT 
                    COUNT(DISTINCT s.Contestant_ID) AS ScoredCount,
                    (SELECT COUNT(*) FROM contestants WHERE Gender_ID = @gid) AS TotalCount
                FROM scores s
                JOIN contestants c ON s.Contestant_ID = c.Contestant_ID
                WHERE s.Judge_ID = @jid AND s.Criteria_ID = @cid AND c.Gender_ID = @gid;"
            End If

            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@jid", judgeID)
            cmd.Parameters.AddWithValue("@cid", selectedCriteriaID)
            cmd.Parameters.AddWithValue("@gid", judgeGender)

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader = cmd.ExecuteReader()

            If reader.Read() Then
                scoredCount = Convert.ToInt32(reader("ScoredCount"))
                totalCount = Convert.ToInt32(reader("TotalCount"))
            End If
            reader.Close()
            SafeCloseConnection()

            progresslabel.Text = $"Progress: {scoredCount}/{totalCount}"
        Catch ex As Exception
            If con.State = ConnectionState.Open Then SafeCloseConnection()
            progresslabel.Text = "Progress: Error"

        End Try
    End Sub

    Private Sub LoadContestantInfo()
        Dim query As String = "
            SELECT c.Full_Name, p.Program_Name, g.Gender_Name, c.Picture
            FROM contestants c
            JOIN programs p ON c.Program_ID=p.Program_ID
            JOIN gender g ON c.Gender_ID=g.Gender_ID
            WHERE c.Contestant_ID=@cid"
        cmd = New MySqlCommand(query, con)
        cmd.Parameters.AddWithValue("@cid", contestantcmbb.SelectedValue)
        adapter = New MySqlDataAdapter(cmd)
        dt = New DataTable()
        adapter.Fill(dt)

        If dt.Rows.Count > 0 Then
            contestantname.Text = dt.Rows(0)("Full_Name").ToString()
            program.Text = dt.Rows(0)("Program_Name").ToString()
            assignedgender.Text = dt.Rows(0)("Gender_Name").ToString()
            If Not IsDBNull(dt.Rows(0)("Picture")) Then
                DisplayPicture(DirectCast(dt.Rows(0)("Picture"), Byte()))
            Else
                PictureBox1.Image = Nothing
            End If
        End If
    End Sub

    Private Sub DisplayPicture(picBytes As Byte())
        PictureBox1.Image = Nothing
        If picBytes Is Nothing OrElse picBytes.Length = 0 Then Return
        Using ms As New MemoryStream(picBytes)
            PictureBox1.Image = Image.FromStream(ms)
        End Using
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
    End Sub

    Private Sub LoadPreviousScores()
        Dim query As String = "
            SELECT SubCriteria_ID, Score FROM scores
            WHERE Judge_ID=@jid AND Contestant_ID=@cid AND Criteria_ID=@crid
            ORDER BY SubCriteria_ID ASC"
        cmd = New MySqlCommand(query, con)
        cmd.Parameters.AddWithValue("@jid", judgeID)
        cmd.Parameters.AddWithValue("@cid", contestantcmbb.SelectedValue)
        cmd.Parameters.AddWithValue("@crid", selectedCriteriaID)
        adapter = New MySqlDataAdapter(cmd)
        dt = New DataTable()
        adapter.Fill(dt)

        If dt.Rows.Count = 3 Then
            score1.Text = dt.Rows(0)("Score").ToString()
            score2.Text = dt.Rows(1)("Score").ToString()
            score3.Text = dt.Rows(2)("Score").ToString()
            score1.ReadOnly = True
            score2.ReadOnly = True
            score3.ReadOnly = True
            savebtn.Enabled = False
        Else
            score1.Clear()
            score2.Clear()
            score3.Clear()
            score1.ReadOnly = False
            score2.ReadOnly = False
            score3.ReadOnly = False
            savebtn.Enabled = True
        End If
    End Sub

    Private Sub savebtn_Click(sender As Object, e As EventArgs) Handles savebtn.Click
        If contestantcmbb.SelectedIndex = -1 Then
            MessageBox.Show("Please select a contestant.")
            Exit Sub
        End If
        If Not ValidateScores() Then Exit Sub

        Dim subs = GetSubCriteriaIDs()
        Dim scores As Integer() = {CInt(score1.Text), CInt(score2.Text), CInt(score3.Text)}

        Try
            con.Open()
            Dim tx = con.BeginTransaction()

            For i As Integer = 0 To 2
                Dim q As String = "INSERT INTO scores (Judge_ID, Contestant_ID, Criteria_ID, SubCriteria_ID, Score)
                           VALUES (@jid, @cid, @crid, @sid, @scr)"
                cmd = New MySqlCommand(q, con, tx)
                cmd.Parameters.AddWithValue("@jid", judgeID)
                cmd.Parameters.AddWithValue("@cid", contestantcmbb.SelectedValue)
                cmd.Parameters.AddWithValue("@crid", selectedCriteriaID)
                cmd.Parameters.AddWithValue("@sid", subs(i))
                cmd.Parameters.AddWithValue("@scr", scores(i))
                cmd.ExecuteNonQuery()
            Next

            tx.Commit()
            MessageBox.Show("Scores saved successfully.")

            LoadPreviousScores()
            UpdateProgress()
            Clearfields()

        Catch ex As Exception
            MessageBox.Show("Failed to save scores.")
        Finally
            SafeCloseConnection()
        End Try



    End Sub

    Private Function GetSubCriteriaIDs() As List(Of Integer)
        Dim list As New List(Of Integer)
        Dim query As String = "SELECT SubCriteria_ID FROM subcriteria WHERE Criteria_ID=@cid ORDER BY SubCriteria_ID ASC LIMIT 3"
        cmd = New MySqlCommand(query, con)
        cmd.Parameters.AddWithValue("@cid", selectedCriteriaID)
        adapter = New MySqlDataAdapter(cmd)
        dt = New DataTable()
        adapter.Fill(dt)
        For Each r As DataRow In dt.Rows
            list.Add(CInt(r("SubCriteria_ID")))
        Next
        Return list
    End Function


    Private Function ValidateScores() As Boolean
        Dim s1, s2, s3 As Integer
        If Not Integer.TryParse(score1.Text, s1) OrElse Not Integer.TryParse(score2.Text, s2) OrElse Not Integer.TryParse(score3.Text, s3) Then
            MessageBox.Show("Please enter valid numbers.")
            Return False
        End If
        If s1 < CInt(min1.Text) OrElse s1 > CInt(max1.Text) OrElse
           s2 < CInt(min2.Text) OrElse s2 > CInt(max2.Text) OrElse
           s3 < CInt(min3.Text) OrElse s3 > CInt(max3.Text) Then
            MessageBox.Show("Scores must be within the allowed range.")
            Return False
        End If
        Return True
    End Function

    Private Sub Clearfields()
        score1.Clear()
        score2.Clear()
        score3.Clear()

        If contestantcmbb.SelectedIndex < contestantcmbb.Items.Count - 1 Then
            contestantcmbb.SelectedIndex += 1
        Else
            contestantcmbb.SelectedIndex = 0
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub totalscore()
        Dim total As Integer

        total = Val(score1.Text) + Val(score2.Text) + Val(score3.Text)

        Totals.Text = total.ToString()
    End Sub

    Private Sub score1_TextChanged(sender As Object, e As EventArgs) Handles score1.TextChanged
        totalscore()
    End Sub

    Private Sub score2_TextChanged(sender As Object, e As EventArgs) Handles score2.TextChanged
        totalscore()
    End Sub

    Private Sub score3_TextChanged(sender As Object, e As EventArgs) Handles score3.TextChanged
        totalscore()
    End Sub

End Class
