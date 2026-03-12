
Public Class Form1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form10.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form12.Show()
    End Sub

    Private Sub contbtn_Click(sender As Object, e As EventArgs) Handles contbtn.Click
        Form2.Show()
    End Sub

    Private Sub deptbtn_Click(sender As Object, e As EventArgs) Handles deptbtn.Click
        Form6.Show()
    End Sub

    Private Sub progbtn_Click(sender As Object, e As EventArgs) Handles progbtn.Click
        Form5.Show()
    End Sub

    Private Sub genbtn_Click(sender As Object, e As EventArgs) Handles genbtn.Click
        Form4.Show()
    End Sub

    Private Sub judgbtn_Click(sender As Object, e As EventArgs) Handles judgbtn.Click
        Form7.Show()
    End Sub

    Private Sub crtbtn_Click(sender As Object, e As EventArgs) Handles crtbtn.Click
        Form8.Show()
    End Sub

    Private Sub scrbtn_Click(sender As Object, e As EventArgs) Handles scrbtn.Click
        Form9.Show()
    End Sub

    Private Sub exitbtn_Click(sender As Object, e As EventArgs) Handles exitbtn.Click
        Application.Exit()
    End Sub

End Class
