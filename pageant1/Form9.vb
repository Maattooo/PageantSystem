Imports System.IO
Imports System.Globalization
Imports MySql.Data.MySqlClient
Imports System.Diagnostics
Imports System.Drawing.Printing

Public Class Form9
    Dim cmd As MySqlCommand
    Dim adapter As MySqlDataAdapter
    Dim dt As DataTable


    Dim printDoc As New PrintDocument()
    Dim printPreview As New PrintPreviewDialog()
    Dim printFont As New Font("Arial", 10)
    Dim currentY As Integer

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCriteria()
        LoadGender()
        ConfigureGrid()

    End Sub

    Private Sub ConfigureGrid()
        With DataGridView1
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.False
            .RowTemplate.Height = 30
            .ScrollBars = ScrollBars.Both
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
        End With
    End Sub

    Private Sub LoadGender()
        Dim q As String = "SELECT Gender_ID, Gender_Name FROM gender ORDER BY Gender_Name ASC"
        Try
            Dim localDt As New DataTable()
            Using localAdapter As New MySqlDataAdapter(q, con)
                localAdapter.Fill(localDt)
            End Using

            gendercmbb.DataSource = localDt
            gendercmbb.DisplayMember = "Gender_Name"
            gendercmbb.ValueMember = "Gender_ID"
            gendercmbb.SelectedIndex = -1
        Catch ex As Exception
            Debug.WriteLine(ex.ToString())
            MessageBox.Show("Failed to load genders.")
        End Try
    End Sub

    Private Sub LoadCriteria()
        Dim q As String = "SELECT Criteria_ID, Criteria_Name FROM criteria ORDER BY Criteria_Name ASC"
        Try
            Dim localDt As New DataTable()
            Using localAdapter As New MySqlDataAdapter(q, con)
                localAdapter.Fill(localDt)
            End Using

            criteriacmb.DataSource = localDt
            criteriacmb.DisplayMember = "Criteria_Name"
            criteriacmb.ValueMember = "Criteria_ID"
            criteriacmb.SelectedIndex = -1
        Catch ex As Exception
            Debug.WriteLine(ex.ToString())
            MessageBox.Show("Failed to load criteria.")
        End Try
    End Sub

    Private Sub LoadJudgesByGender(genderId As Object)
        If genderId Is Nothing OrElse IsDBNull(genderId) Then
            judgecmbb.DataSource = Nothing
            judgecmbb.Items.Clear()
            judgecmbb.SelectedIndex = -1
            Return
        End If

        Dim q As String = "SELECT Judge_ID, Full_Name FROM judges WHERE Gender_ID = @gender ORDER BY Full_name ASC"
        Try
            Dim localDt As New DataTable()
            Using localCmd As New MySqlCommand(q, con)
                localCmd.Parameters.AddWithValue("@gender", genderId)
                Using localAdapter As New MySqlDataAdapter(localCmd)
                    localAdapter.Fill(localDt)
                End Using
            End Using

            If localDt.Rows.Count = 0 Then
                judgecmbb.DataSource = Nothing
                judgecmbb.Items.Clear()
                judgecmbb.SelectedIndex = -1
            Else
                judgecmbb.DataSource = localDt
                judgecmbb.DisplayMember = "Full_name"
                judgecmbb.ValueMember = "Judge_id"
                judgecmbb.SelectedIndex = -1
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.ToString())
            MessageBox.Show("Failed to load judges for the selected gender.")
        End Try
    End Sub

    Private Sub gendercmbb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gendercmbb.SelectedIndexChanged
        If gendercmbb.SelectedIndex <> -1 Then
            LoadJudgesByGender(gendercmbb.SelectedValue)
        Else
            LoadJudgesByGender(Nothing)
        End If
    End Sub

    Private Sub Clearbtn_Click(sender As Object, e As EventArgs) Handles Clearbtn.Click
        criteriacmb.SelectedIndex = -1
        gendercmbb.SelectedIndex = -1
        judgecmbb.SelectedIndex = -1
        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
    End Sub

    Private Sub loadbtn_Click(sender As Object, e As EventArgs) Handles loadbtn.Click
        If criteriacmb.SelectedIndex = -1 Or gendercmbb.SelectedIndex = -1 Or judgecmbb.SelectedIndex = -1 Then
            MessageBox.Show("Please select Gender, Criteria and Judges.")
            Exit Sub
        End If

        Try
            Dim subcriteriaQuery As String = "SELECT SubCriteria_ID, SubCriteria_Name FROM subcriteria WHERE Criteria_ID=@crid ORDER BY SubCriteria_ID"
            Dim subDt As New DataTable()
            Using subCmd As New MySqlCommand(subcriteriaQuery, con)
                subCmd.Parameters.AddWithValue("@crid", criteriacmb.SelectedValue)
                Using subAdapter As New MySqlDataAdapter(subCmd)
                    subAdapter.Fill(subDt)
                End Using
            End Using

            If subDt.Rows.Count = 0 Then
                MessageBox.Show("No subcriteria defined for the selected criteria.")
                DataGridView1.DataSource = Nothing
                Return
            End If

            Dim pivotColumns As New List(Of String)()
            Dim subAliases As New List(Of (aliasName As String, displayName As String))()

            For Each r As DataRow In subDt.Rows
                Dim id As Integer = Convert.ToInt32(r("SubCriteria_ID"), CultureInfo.InvariantCulture)
                Dim displayName As String = r("SubCriteria_Name").ToString()
                Dim aliasName As String = $"sc_{id}"
                subAliases.Add((aliasName, displayName))
                pivotColumns.Add($"MAX(CASE WHEN s.SubCriteria_ID={id} THEN sc.Score ELSE 0 END) AS `{aliasName}`")
            Next

            Dim pivotColumnsSql As String = String.Join(", ", pivotColumns)

            Dim query As String = $"
                                    SELECT 
                                        c.Contestant_Number,
                                        c.Full_name AS Contestant_Name,
                                        j.Full_name AS Judge_Name,
                                        cr.Criteria_Name,
                                        {pivotColumnsSql},
                                        SUM(COALESCE(sc.Score,0)) AS TotalScore
                                    FROM contestants c
                                    LEFT JOIN scores sc 
                                        ON sc.Contestant_ID = c.Contestant_ID 
                                        AND sc.Criteria_ID = @crid
                                        AND sc.Judge_ID = @judge
                                    LEFT JOIN judges j ON j.Judge_ID = @judge
                                    LEFT JOIN subcriteria s ON sc.Subcriteria_ID = s.Subcriteria_ID
                                    LEFT JOIN criteria cr ON cr.Criteria_ID = @crid
                                    WHERE c.Gender_ID = @gender
                                    GROUP BY 
                                        c.Contestant_ID,
                                        c.Contestant_Number,
                                        c.Full_Name,
                                        j.Judge_ID,
                                        j.Full_Name,
                                        cr.Criteria_Name
                                    ORDER BY c.Contestant_Number, j.Full_Name;"
            Dim resultDt As New DataTable()
            Using mainCmd As New MySqlCommand(query, con)
                mainCmd.Parameters.AddWithValue("@crid", criteriacmb.SelectedValue)
                mainCmd.Parameters.AddWithValue("@gender", gendercmbb.SelectedValue)
                mainCmd.Parameters.AddWithValue("@judge", judgecmbb.SelectedValue)
                Using mainAdapter As New MySqlDataAdapter(mainCmd)
                    mainAdapter.Fill(resultDt)
                End Using
            End Using

            If resultDt.Rows.Count = 0 Then
                MessageBox.Show("No scores found for the selected criteria/gender/judge.")
                DataGridView1.DataSource = Nothing
                Return
            End If

            DataGridView1.SuspendLayout()
            DataGridView1.Rows.Clear()
            DataGridView1.Columns.Clear()

            DataGridView1.Columns.Add("Contestant_Number", "Contestant Number")
            DataGridView1.Columns.Add("Contestant_Name", "Contestant Name")
            DataGridView1.Columns.Add("Criteria_Name", "Criteria")

            For Each pair In subAliases
                Dim col As New DataGridViewTextBoxColumn() With {
                    .Name = pair.aliasName,
                    .HeaderText = pair.displayName
                }
                DataGridView1.Columns.Add(col)
            Next

            DataGridView1.Columns.Add("TotalScore", "Total")
            ConfigureGrid()
            DataGridView1.Columns("TotalScore").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            For Each r As DataRow In resultDt.Rows
                Dim rowValues As New List(Of Object) From {
                    If(IsDBNull(r("Contestant_Number")), String.Empty, r("Contestant_Number")),
                    If(IsDBNull(r("Contestant_Name")), String.Empty, r("Contestant_Name")),
                    If(IsDBNull(r("Criteria_Name")), String.Empty, r("Criteria_Name"))
                }

                For Each pair In subAliases
                    Dim fieldName As String = pair.aliasName
                    Dim val As Object = If(resultDt.Columns.Contains(fieldName) AndAlso Not IsDBNull(r(fieldName)), r(fieldName), 0)
                    rowValues.Add(val)
                Next

                rowValues.Add(If(IsDBNull(r("TotalScore")), 0, r("TotalScore")))

                DataGridView1.Rows.Add(rowValues.ToArray())
            Next

            DataGridView1.ResumeLayout()
        Catch ex As Exception
            Debug.WriteLine(ex.ToString())
            MessageBox.Show("Error loading contestants. See logs for details.")
        End Try
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

        Dim headerTitle As String = "VMUF PAGEANT SCORES"
        Dim headerFont As New Font("Arial", 14, FontStyle.Bold)
        Dim headerSize As SizeF = e.Graphics.MeasureString(headerTitle, headerFont)
        e.Graphics.DrawString(headerTitle, headerFont, Brushes.Black,
                          (e.PageBounds.Width - headerSize.Width) / 2, currentY)
        currentY += lineHeight * 2

        Dim subHeader As String = $"Criteria: {criteriacmb.Text}    |    Gender: {gendercmbb.Text}    |    Judge: {judgecmbb.Text}"
        e.Graphics.DrawString(subHeader, New Font("Arial", 11, FontStyle.Italic), Brushes.Black, leftMargin, currentY)
        currentY += lineHeight * 2

        Dim totalColCount As Integer = DataGridView1.Columns.Count
        Dim colWidths(totalColCount - 1) As Single
        Dim totalHeaderWidth As Single = 0
        Dim headerFontSmall As New Font("Arial", 10, FontStyle.Bold)

        Dim minColWidth As Single = 80.0F
        Dim extraPadding As Single = 30.0F

        For i As Integer = 0 To totalColCount - 1
            Dim headerText As String = DataGridView1.Columns(i).HeaderText
            Dim headerTextSize As SizeF = e.Graphics.MeasureString(headerText, headerFontSmall)
            Dim maxWidth As Single = Math.Max(minColWidth, headerTextSize.Width + extraPadding)

            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells(i).Value IsNot Nothing Then
                    Dim valueText As String = row.Cells(i).Value.ToString()
                    Dim textSize As SizeF = e.Graphics.MeasureString(valueText, printFont)
                    maxWidth = Math.Max(maxWidth, textSize.Width + extraPadding)
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
                Dim valueStr As String = ""
                Dim cellValue = row.Cells(i).Value
                If cellValue IsNot Nothing Then
                    valueStr = cellValue.ToString()
                End If
                e.Graphics.DrawString(valueStr, printFont, Brushes.Black, currentX, currentY)
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
