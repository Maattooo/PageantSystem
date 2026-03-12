Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Timers
Imports System.Drawing.Printing



Public Class Form12
    Dim cmd As MySqlCommand
    Dim adapter As MySqlDataAdapter
    Dim dt As New DataTable()
    Dim refreshTimer As System.Windows.Forms.Timer
    Dim printDoc As New PrintDocument()
    Dim printPreview As New PrintPreviewDialog()
    Dim printFont As New Font("Arial", 10)
    Dim currentY As Integer



    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGender()
        LoadCategories()
        progresslabel.Text = ""
        SetupAutoRefresh()
    End Sub

    Private Sub SetupAutoRefresh()
        refreshTimer = New System.Windows.Forms.Timer()
        refreshTimer.Interval = 5000
        AddHandler refreshTimer.Tick, AddressOf RefreshProgress
        refreshTimer.Start()
    End Sub

    Private Sub LoadGender()
        Try
            Dim query As String = "SELECT Gender_ID, Gender_Name FROM gender ORDER BY Gender_Name ASC"
            Dim genderAdapter As New MySqlDataAdapter(query, con)
            Dim genderTable As New DataTable()
            genderAdapter.Fill(genderTable)
            ComboBox1.DataSource = genderTable
            ComboBox1.DisplayMember = "Gender_Name"
            ComboBox1.ValueMember = "Gender_ID"
            ComboBox1.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error loading gender: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadCategories()
        Try
            Dim query As String = "SELECT Criteria_ID, Criteria_Name FROM criteria WHERE Criteria_Name <> 'Mr and Ms' ORDER BY Criteria_Name ASC"
            Dim criteriaAdapter As New MySqlDataAdapter(query, con)
            Dim criteriaTable As New DataTable()
            criteriaAdapter.Fill(criteriaTable)
            ComboBox2.DataSource = criteriaTable
            ComboBox2.DisplayMember = "Criteria_Name"
            ComboBox2.ValueMember = "Criteria_ID"
            ComboBox2.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error loading criteria: " & ex.Message)
        End Try
    End Sub

    Private Sub readbtn_Click(sender As Object, e As EventArgs) Handles readbtn.Click
        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Please select a gender.")
            Exit Sub
        End If
        If ComboBox2.SelectedIndex = -1 Then
            MessageBox.Show("Please select a category.")
            Exit Sub
        End If
        Try
            Dim query As String = "
                SELECT
                    IFNULL(c.Contestant_Number, c.Contestant_ID) AS Contestant_Number,
                    c.Full_Name AS `Contestant Name`,
                    d.Department_Name AS Department,
                    cr.Criteria_Name AS Category,
                    ROUND(AVG(jt.judge_total), 2) AS `Average Score`,
                    RANK() OVER (ORDER BY AVG(jt.judge_total) DESC) AS Rank
                FROM (
                    SELECT s.Judge_ID, s.Contestant_ID, SUM(s.Score) AS judge_total
                    FROM scores s
                    JOIN subcriteria sc ON s.SubCriteria_ID = sc.SubCriteria_ID
                    WHERE sc.Criteria_ID = @CriteriaID
                    GROUP BY s.Judge_ID, s.Contestant_ID
                ) jt
                JOIN contestants c ON jt.Contestant_ID = c.Contestant_ID
                JOIN programs p ON c.Program_ID = p.Program_ID
                JOIN departments d ON p.Department_ID = d.Department_ID
                JOIN criteria cr ON cr.Criteria_ID = @CriteriaID
                WHERE c.Gender_ID = @GenderID
                GROUP BY c.Contestant_ID, c.Contestant_Number, c.Full_Name, d.Department_Name, cr.Criteria_Name
                ORDER BY AVG(jt.judge_total) DESC;"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@GenderID", ComboBox1.SelectedValue)
            cmd.Parameters.AddWithValue("@CriteriaID", ComboBox2.SelectedValue)
            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable()
            adapter.Fill(dt)
            DataGridView1.DataSource = dt
            StyleGrid()
            RefreshProgress()
        Catch ex As Exception
            MessageBox.Show("Error loading category results: " & ex.Message)
        End Try
    End Sub

    Private Sub RefreshProgress()
        If ComboBox1.SelectedIndex = -1 Or ComboBox2.SelectedIndex = -1 Then
            progresslabel.Text = "Progress: Select gender and category"
            overallbtn.Enabled = False
            Return
        End If
        Try
            Dim queryTotalJudges As String = "SELECT COUNT(*) FROM judges WHERE Gender_ID = @gid"
            Dim queryDoneJudges As String = "
                SELECT COUNT(DISTINCT s.Judge_ID)
                FROM scores s
                JOIN subcriteria sc ON s.SubCriteria_ID = sc.SubCriteria_ID
                JOIN contestants c ON s.Contestant_ID = c.Contestant_ID
                WHERE sc.Criteria_ID = @cid AND c.Gender_ID = @gid"
            Dim totalJudges, doneJudges As Integer
            Using cmdTotal As New MySqlCommand(queryTotalJudges, con)
                cmdTotal.Parameters.AddWithValue("@gid", ComboBox1.SelectedValue)
                con.Open()
                totalJudges = Convert.ToInt32(cmdTotal.ExecuteScalar())
                SafeCloseConnection()
            End Using
            Using cmdDone As New MySqlCommand(queryDoneJudges, con)
                cmdDone.Parameters.AddWithValue("@gid", ComboBox1.SelectedValue)
                cmdDone.Parameters.AddWithValue("@cid", ComboBox2.SelectedValue)
                con.Open()
                doneJudges = Convert.ToInt32(cmdDone.ExecuteScalar())
                SafeCloseConnection()
            End Using
            progresslabel.Text = $"Progress: {doneJudges}/{totalJudges} Complete"
            overallbtn.Enabled = (doneJudges = totalJudges)
        Catch ex As Exception
            If con.State = ConnectionState.Open Then SafeCloseConnection()
            progresslabel.Text = "Error loading progress"
        End Try
    End Sub

    Private Sub overallbtn_Click(sender As Object, e As EventArgs) Handles overallbtn.Click
        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Please select a gender.")
            Exit Sub
        End If
        Try
            Dim query As String = "
                WITH JudgeTotals AS (
                    SELECT s.Judge_ID, s.Contestant_ID, sc.Criteria_ID, SUM(s.Score) AS judge_total
                    FROM scores s
                    JOIN subcriteria sc ON s.SubCriteria_ID = sc.SubCriteria_ID
                    WHERE sc.Criteria_ID IN (
                        SELECT Criteria_ID FROM criteria WHERE Criteria_Name IN ('School Uniform', 'Shorts Wear', 'Formal Wear')
                    )
                    GROUP BY s.Judge_ID, s.Contestant_ID, sc.Criteria_ID
                ),
                CriteriaAverages AS (
                    SELECT Contestant_ID, Criteria_ID, ROUND(AVG(judge_total),2) AS avg_per_criteria
                    FROM JudgeTotals
                    GROUP BY Contestant_ID, Criteria_ID
                ),
                ContestantAverages AS (
                    SELECT c.Contestant_ID, AVG(ca.avg_per_criteria) AS overall_average
                    FROM CriteriaAverages ca
                    JOIN contestants c ON ca.Contestant_ID = c.Contestant_ID
                    WHERE c.Gender_ID = @GenderID
                    GROUP BY c.Contestant_ID
                    HAVING COUNT(DISTINCT ca.Criteria_ID) = 3
                )
                SELECT 
                    IFNULL(c.Contestant_Number, c.Contestant_ID) AS Contestant_Number,
                    c.Full_Name AS `Contestant Name`,
                    d.Department_Name AS Department,
                    ROUND(ca.overall_average,2) AS `Overall Average`,
                    RANK() OVER (ORDER BY ca.overall_average DESC) AS Rank
                FROM ContestantAverages ca
                JOIN contestants c ON ca.Contestant_ID = c.Contestant_ID
                JOIN programs p ON c.Program_ID = p.Program_ID
                JOIN departments d ON p.Department_ID = d.Department_ID
                WHERE c.Gender_ID = @GenderID
                ORDER BY ca.overall_average DESC;"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@GenderID", ComboBox1.SelectedValue)
            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable()
            adapter.Fill(dt)
            DataGridView1.DataSource = dt
            StyleGrid()
        Catch ex As Exception
            MessageBox.Show("Error loading overall results: " & ex.Message)
        End Try
    End Sub

    Private Sub finalsbtn_Click(sender As Object, e As EventArgs) Handles finalsbtn.Click
        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Please select a gender.")
            Exit Sub
        End If
        Try
            Dim query As String = "
                WITH JudgeTotals AS (
                    SELECT s.Judge_ID, s.Contestant_ID, sc.Criteria_ID, SUM(s.Score) AS total_by_judge
                    FROM scores s
                    JOIN subcriteria sc ON s.SubCriteria_ID = sc.SubCriteria_ID
                    WHERE sc.Criteria_ID = (SELECT Criteria_ID FROM criteria WHERE Criteria_Name = 'Mr and Ms')
                    GROUP BY s.Judge_ID, s.Contestant_ID, sc.Criteria_ID
                ),
                CriteriaAverages AS (
                    SELECT Contestant_ID, ROUND(AVG(total_by_judge),2) AS avg_final_score
                    FROM JudgeTotals
                    GROUP BY Contestant_ID
                )
                SELECT 
                    IFNULL(c.Contestant_Number, c.Contestant_ID) AS Contestant_Number,
                    c.Full_Name AS `Contestant Name`,
                    d.Department_Name AS Department,
                    ROUND(ca.avg_final_score,2) AS `Final Average`,
                    RANK() OVER (ORDER BY ca.avg_final_score DESC) AS Rank
                FROM CriteriaAverages ca
                JOIN contestants c ON ca.Contestant_ID = c.Contestant_ID
                JOIN programs p ON c.Program_ID = p.Program_ID
                JOIN departments d ON p.Department_ID = d.Department_ID
                WHERE c.Gender_ID = @GenderID
                ORDER BY ca.avg_final_score DESC;"
            cmd = New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@GenderID", ComboBox1.SelectedValue)
            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable()
            adapter.Fill(dt)
            DataGridView1.DataSource = dt
            StyleGrid()
        Catch ex As Exception
            MessageBox.Show("Error loading finals results: " & ex.Message)
        End Try
    End Sub

    Private Sub StyleGrid()
        If DataGridView1.Columns.Count = 0 Then Exit Sub
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.RowTemplate.Height = 40
        DataGridView1.ScrollBars = ScrollBars.Both
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.MultiSelect = False
    End Sub

    Private Sub printbtn_Click(sender As Object, e As EventArgs) Handles printbtn.Click
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("No data to print.")
            Exit Sub
        End If

        printDoc.DefaultPageSettings.Landscape = True
        printPreview.Document = printDoc
        AddHandler printDoc.PrintPage, AddressOf PrintPageHandler
        printPreview.Width = 1200
        printPreview.Height = 800
        printPreview.ShowDialog()
        RemoveHandler printDoc.PrintPage, AddressOf PrintPageHandler
    End Sub

    Private Sub PrintPageHandler(sender As Object, e As PrintPageEventArgs)
        Dim leftMargin As Integer = e.MarginBounds.Left
        Dim topMargin As Integer = e.MarginBounds.Top
        Dim lineHeight As Integer = CInt(printFont.GetHeight(e.Graphics)) + 6
        Dim pageWidth As Integer = e.MarginBounds.Width
        currentY = topMargin

        Dim headerTitle As String = "VMUF PAGEANT RESULTS"
        Dim headerFont As New Font("Arial", 14, FontStyle.Bold)
        Dim headerSize As SizeF = e.Graphics.MeasureString(headerTitle, headerFont)
        e.Graphics.DrawString(headerTitle, headerFont, Brushes.Black,
                          (e.PageBounds.Width - headerSize.Width) / 2, currentY)
        currentY += lineHeight * 2

        Dim subHeader As String = $"Category: {ComboBox2.Text}    |    Gender: {ComboBox1.Text}"
        e.Graphics.DrawString(subHeader, New Font("Arial", 11, FontStyle.Italic), Brushes.Black, leftMargin, currentY)
        currentY += lineHeight * 2

        Dim totalColCount As Integer = DataGridView1.Columns.Count
        Dim colWidths(totalColCount - 1) As Single
        Dim totalHeaderWidth As Single = 0
        Dim headerFontSmall As New Font("Arial", 10, FontStyle.Bold)

        For i As Integer = 0 To totalColCount - 1
            Dim headerText As String = DataGridView1.Columns(i).HeaderText
            Dim headerTextSize As SizeF = e.Graphics.MeasureString(headerText, headerFontSmall)
            Dim maxWidth As Single = headerTextSize.Width + 20

            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells(i).Value IsNot Nothing Then
                    Dim valueText As String = row.Cells(i).Value.ToString()
                    Dim textSize As SizeF = e.Graphics.MeasureString(valueText, printFont)
                    maxWidth = Math.Max(maxWidth, textSize.Width + 20)
                End If
            Next
            colWidths(i) = maxWidth
            totalHeaderWidth += maxWidth
        Next

        Dim scaleFactor As Single = If(totalHeaderWidth > pageWidth, pageWidth / totalHeaderWidth, 1)
        For i As Integer = 0 To totalColCount - 1
            colWidths(i) *= scaleFactor
        Next

        Dim currentX As Single = leftMargin
        For i As Integer = 0 To totalColCount - 1
            e.Graphics.DrawString(DataGridView1.Columns(i).HeaderText,
                              headerFontSmall, Brushes.Black, currentX, currentY)
            currentX += colWidths(i)
        Next

        currentY += lineHeight
        e.Graphics.DrawLine(Pens.Black, leftMargin, currentY, e.MarginBounds.Right, currentY)
        currentY += 5

        For Each row As DataGridViewRow In DataGridView1.Rows
            currentX = leftMargin
            For i As Integer = 0 To totalColCount - 1
                Dim value As String = If(row.Cells(i).Value IsNot Nothing, row.Cells(i).Value.ToString(), "")
                e.Graphics.DrawString(value, printFont, Brushes.Black, currentX, currentY)
                currentX += colWidths(i)
            Next
            currentY += lineHeight

            If currentY > e.MarginBounds.Bottom - lineHeight Then
                e.HasMorePages = True
                Return
            End If
        Next

        e.HasMorePages = False
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
