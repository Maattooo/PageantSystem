<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form12
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        ComboBox1 = New ComboBox()
        readbtn = New Button()
        DataGridView1 = New DataGridView()
        finalsbtn = New Button()
        ComboBox2 = New ComboBox()
        Label2 = New Label()
        overallbtn = New Button()
        progresslabel = New Label()
        Panel1 = New Panel()
        Label7 = New Label()
        Label3 = New Label()
        Label6 = New Label()
        Button1 = New Button()
        printbtn = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century", 12F)
        Label1.Location = New Point(12, 69)
        Label1.Name = "Label1"
        Label1.Size = New Size(67, 20)
        Label1.TabIndex = 0
        Label1.Text = "Gender:"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.BackColor = SystemColors.HighlightText
        ComboBox1.Font = New Font("Century", 12F)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(85, 66)
        ComboBox1.Margin = New Padding(3, 2, 3, 2)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(100, 28)
        ComboBox1.TabIndex = 1
        ' 
        ' readbtn
        ' 
        readbtn.Location = New Point(51, 391)
        readbtn.Margin = New Padding(3, 2, 3, 2)
        readbtn.Name = "readbtn"
        readbtn.Size = New Size(113, 33)
        readbtn.TabIndex = 2
        readbtn.Text = "Read"
        readbtn.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(12, 137)
        DataGridView1.Margin = New Padding(3, 2, 3, 2)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(594, 249)
        DataGridView1.TabIndex = 3
        ' 
        ' finalsbtn
        ' 
        finalsbtn.Location = New Point(218, 391)
        finalsbtn.Margin = New Padding(3, 2, 3, 2)
        finalsbtn.Name = "finalsbtn"
        finalsbtn.Size = New Size(113, 33)
        finalsbtn.TabIndex = 72
        finalsbtn.Text = "Winners"
        finalsbtn.UseVisualStyleBackColor = True
        ' 
        ' ComboBox2
        ' 
        ComboBox2.Font = New Font("Century", 12F)
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(303, 66)
        ComboBox2.Margin = New Padding(3, 2, 3, 2)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(163, 28)
        ComboBox2.TabIndex = 74
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century", 12F)
        Label2.Location = New Point(218, 69)
        Label2.Name = "Label2"
        Label2.Size = New Size(81, 20)
        Label2.TabIndex = 75
        Label2.Text = "Category:"
        ' 
        ' overallbtn
        ' 
        overallbtn.Location = New Point(516, 64)
        overallbtn.Margin = New Padding(3, 2, 3, 2)
        overallbtn.Name = "overallbtn"
        overallbtn.Size = New Size(113, 33)
        overallbtn.TabIndex = 76
        overallbtn.Text = "Overall"
        overallbtn.UseVisualStyleBackColor = True
        ' 
        ' progresslabel
        ' 
        progresslabel.AutoSize = True
        progresslabel.Font = New Font("Century", 12F)
        progresslabel.Location = New Point(12, 103)
        progresslabel.Name = "progresslabel"
        progresslabel.Size = New Size(73, 20)
        progresslabel.TabIndex = 77
        progresslabel.Text = "Progress"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.RoyalBlue
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Button1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(659, 38)
        Panel1.TabIndex = 78
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(303, 9)
        Label7.Name = "Label7"
        Label7.Size = New Size(73, 20)
        Label7.TabIndex = 6
        Label7.Text = "Ranking"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(51, 23)
        Label3.Name = "Label3"
        Label3.Size = New Size(41, 15)
        Label3.TabIndex = 4
        Label3.Text = "VMUF"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Lucida Bright", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(7, 6)
        Label6.Name = "Label6"
        Label6.Size = New Size(89, 18)
        Label6.TabIndex = 3
        Label6.Text = "PAGEANT"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Red
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial Rounded MT Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(612, 3)
        Button1.Margin = New Padding(3, 2, 3, 2)
        Button1.Name = "Button1"
        Button1.Size = New Size(44, 33)
        Button1.TabIndex = 0
        Button1.Text = "X"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' printbtn
        ' 
        printbtn.Location = New Point(516, 391)
        printbtn.Name = "printbtn"
        printbtn.Size = New Size(113, 33)
        printbtn.TabIndex = 79
        printbtn.Text = "Print"
        printbtn.UseVisualStyleBackColor = True
        ' 
        ' Form12
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.AppWorkspace
        ClientSize = New Size(659, 449)
        Controls.Add(printbtn)
        Controls.Add(Panel1)
        Controls.Add(progresslabel)
        Controls.Add(overallbtn)
        Controls.Add(Label2)
        Controls.Add(ComboBox2)
        Controls.Add(finalsbtn)
        Controls.Add(DataGridView1)
        Controls.Add(readbtn)
        Controls.Add(ComboBox1)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        Name = "Form12"
        Text = "Results"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents readbtn As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents finalsbtn As Button
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents overallbtn As Button
    Friend WithEvents progresslabel As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents printbtn As Button
End Class
