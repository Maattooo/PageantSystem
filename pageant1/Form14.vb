Imports MySql.Data.MySqlClient

Public Class Form14
    Public judgeID As Integer
    Public judgeName As String
    Public judgeGender As Integer
    Private Sub Form14_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(judgeName) Then
            judge.Text = "Judge: " & judgeName
        End If
    End Sub

    Private Sub School_Click(sender As Object, e As EventArgs) Handles School.Click
        OpenScoringForm("School Uniform")

    End Sub

    Private Sub Shorts_Click(sender As Object, e As EventArgs) Handles Shorts.Click
        OpenScoringForm("Shorts Wear")

    End Sub

    Private Sub Formal_Click(sender As Object, e As EventArgs) Handles Formal.Click
        OpenScoringForm("Formal Wear")

    End Sub

    Private Sub Finals_Click(sender As Object, e As EventArgs) Handles Finals.Click
        Try
            If Not CanOpenFinals() Then
                MessageBox.Show("Finals cannot be opened yet. All judges must finish scoring all contestants in all non-final criteria for this gender.")
                Exit Sub
            End If

            Dim criteriaID As Integer = 0
            Dim q As String = "SELECT Criteria_ID FROM criteria WHERE Criteria_Name='Mr and Ms'"
            Dim cmd As New MySqlCommand(q, con)
            con.Open()
            Dim result = cmd.ExecuteScalar()
            SafeCloseConnection()

            If result IsNot Nothing Then
                criteriaID = Convert.ToInt32(result)
            Else
                MessageBox.Show("'Mr and Ms' criteria not found in database.")
                Exit Sub
            End If

            Dim scoringForm As New Form11()
            scoringForm.judgeID = judgeID
            scoringForm.judgeName = judgeName
            scoringForm.judgeGender = judgeGender
            scoringForm.selectedCriteriaID = criteriaID
            scoringForm.selectedCriteriaName = "Mr and Ms"
            scoringForm.assignedGenderID = judgeGender
            scoringForm.Show()


        Catch ex As Exception
            If con.State = ConnectionState.Open Then SafeCloseConnection()
            MessageBox.Show("Error opening Finals scoring form: " & ex.Message)
        End Try
    End Sub

    Private Function CanOpenFinals() As Boolean
        Try
            Dim query As String = "
                SELECT 
                    COUNT(DISTINCT j.Judge_ID) = (SELECT COUNT(*) FROM judges WHERE Gender_ID = @gid) AS AllJudgesDone
                FROM judges j
                WHERE j.Gender_ID = @gid
                AND NOT EXISTS (
                    SELECT 1
                    FROM contestants c
                    JOIN subcriteria sc ON sc.Criteria_ID IN (
                        SELECT Criteria_ID FROM criteria WHERE Criteria_Name IN ('School Uniform', 'Shorts Wear', 'Formal Wear')
                    )
                    LEFT JOIN scores s 
                        ON s.Judge_ID = j.Judge_ID 
                        AND s.Contestant_ID = c.Contestant_ID 
                        AND s.SubCriteria_ID = sc.SubCriteria_ID
                    WHERE c.Gender_ID = @gid
                    GROUP BY c.Contestant_ID, sc.Criteria_ID
                    HAVING COUNT(s.Score) < COUNT(sc.SubCriteria_ID)
                );"

            Dim cmd As New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@gid", judgeGender)
            con.Open()
            Dim result = cmd.ExecuteScalar()
            SafeCloseConnection()
            Return Convert.ToBoolean(result)
        Catch ex As Exception
            If con.State = ConnectionState.Open Then SafeCloseConnection()
            MessageBox.Show("Error checking finals readiness: " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub OpenScoringForm(criteriaName As String)
        Try
            Dim criteriaID As Integer = 0
            Dim q As String = "SELECT Criteria_ID FROM criteria WHERE Criteria_Name=@name"
            Dim cmd As New MySqlCommand(q, con)
            cmd.Parameters.AddWithValue("@name", criteriaName)

            con.Open()
            Dim result = cmd.ExecuteScalar()
            SafeCloseConnection()

            If result IsNot Nothing Then
                criteriaID = Convert.ToInt32(result)
            Else
                MessageBox.Show("Criteria not found in database.")
                Exit Sub
            End If

            Dim scoringForm As New Form11()
            scoringForm.judgeID = judgeID
            scoringForm.judgeName = judgeName
            scoringForm.judgeGender = judgeGender
            scoringForm.selectedCriteriaID = criteriaID
            scoringForm.selectedCriteriaName = criteriaName
            scoringForm.assignedGenderID = judgeGender

            scoringForm.ShowDialog()


        Catch ex As Exception
            If con.State = ConnectionState.Open Then SafeCloseConnection()
            MessageBox.Show("Error opening scoring form: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Form10.Show()
    End Sub

End Class
