<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form11
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
        Judgeinfo = New Label()
        contestantcmbb = New ComboBox()
        contestantname = New Label()
        assignedgender = New Label()
        program = New Label()
        PictureBox1 = New PictureBox()
        savebtn = New Button()
        prebtn = New Button()
        nextbtn = New Button()
        progresslabel = New Label()
        Panel1 = New Panel()
        category = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Button1 = New Button()
        Panel2 = New Panel()
        PictureBox2 = New PictureBox()
        Panel3 = New Panel()
        Panel8 = New Panel()
        max3 = New Label()
        Label1 = New Label()
        min1 = New Label()
        Label4 = New Label()
        min3 = New Label()
        max2 = New Label()
        min2 = New Label()
        max1 = New Label()
        Panel4 = New Panel()
        Panel5 = New Panel()
        score3 = New TextBox()
        Label2 = New Label()
        Panel6 = New Panel()
        score2 = New TextBox()
        sub1 = New Label()
        Panel7 = New Panel()
        score1 = New TextBox()
        Label3 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        Panel8.SuspendLayout()
        Panel4.SuspendLayout()
        Panel5.SuspendLayout()
        Panel6.SuspendLayout()
        Panel7.SuspendLayout()
        SuspendLayout()
        ' 
        ' Judgeinfo
        ' 
        Judgeinfo.AutoSize = True
        Judgeinfo.Font = New Font("Century", 12F)
        Judgeinfo.Location = New Point(12, 5)
        Judgeinfo.Name = "Judgeinfo"
        Judgeinfo.Size = New Size(54, 20)
        Judgeinfo.TabIndex = 0
        Judgeinfo.Text = "Judge"
        ' 
        ' contestantcmbb
        ' 
        contestantcmbb.Font = New Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        contestantcmbb.FormattingEnabled = True
        contestantcmbb.Location = New Point(27, 137)
        contestantcmbb.Margin = New Padding(3, 2, 3, 2)
        contestantcmbb.Name = "contestantcmbb"
        contestantcmbb.Size = New Size(92, 33)
        contestantcmbb.TabIndex = 1
        ' 
        ' contestantname
        ' 
        contestantname.AutoSize = True
        contestantname.Font = New Font("Century", 12F)
        contestantname.Location = New Point(189, 58)
        contestantname.Name = "contestantname"
        contestantname.Size = New Size(91, 20)
        contestantname.TabIndex = 7
        contestantname.Text = "Contestant"
        ' 
        ' assignedgender
        ' 
        assignedgender.AutoSize = True
        assignedgender.Font = New Font("Century", 12F)
        assignedgender.Location = New Point(12, 25)
        assignedgender.Name = "assignedgender"
        assignedgender.Size = New Size(59, 20)
        assignedgender.TabIndex = 10
        assignedgender.Text = "Assign"
        ' 
        ' program
        ' 
        program.AutoSize = True
        program.Font = New Font("Century", 12F)
        program.Location = New Point(189, 111)
        program.Name = "program"
        program.Size = New Size(74, 20)
        program.TabIndex = 11
        program.Text = "Program"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Location = New Point(27, 13)
        PictureBox1.Margin = New Padding(3, 2, 3, 2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(92, 73)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 12
        PictureBox1.TabStop = False
        ' 
        ' savebtn
        ' 
        savebtn.Location = New Point(374, 446)
        savebtn.Margin = New Padding(3, 2, 3, 2)
        savebtn.Name = "savebtn"
        savebtn.Size = New Size(90, 28)
        savebtn.TabIndex = 25
        savebtn.Text = "Save"
        savebtn.UseVisualStyleBackColor = True
        ' 
        ' prebtn
        ' 
        prebtn.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        prebtn.Location = New Point(249, 446)
        prebtn.Margin = New Padding(3, 2, 3, 2)
        prebtn.Name = "prebtn"
        prebtn.Size = New Size(90, 28)
        prebtn.TabIndex = 26
        prebtn.Text = "<--"
        prebtn.UseVisualStyleBackColor = True
        ' 
        ' nextbtn
        ' 
        nextbtn.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        nextbtn.Location = New Point(501, 446)
        nextbtn.Margin = New Padding(3, 2, 3, 2)
        nextbtn.Name = "nextbtn"
        nextbtn.Size = New Size(90, 28)
        nextbtn.TabIndex = 27
        nextbtn.Text = "-->"
        nextbtn.UseVisualStyleBackColor = True
        ' 
        ' progresslabel
        ' 
        progresslabel.AutoSize = True
        progresslabel.Font = New Font("Century", 11.25F)
        progresslabel.Location = New Point(604, 12)
        progresslabel.Name = "progresslabel"
        progresslabel.Size = New Size(74, 18)
        progresslabel.TabIndex = 28
        progresslabel.Text = "Progress:"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.CadetBlue
        Panel1.Controls.Add(category)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(progresslabel)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(Judgeinfo)
        Panel1.Controls.Add(assignedgender)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(776, 45)
        Panel1.TabIndex = 81
        ' 
        ' category
        ' 
        category.AutoSize = True
        category.Font = New Font("Century", 11.25F)
        category.Location = New Point(208, 15)
        category.Name = "category"
        category.Size = New Size(72, 18)
        category.TabIndex = 29
        category.Text = "Category"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Century", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(425, 24)
        Label6.Name = "Label6"
        Label6.Size = New Size(41, 15)
        Label6.TabIndex = 4
        Label6.Text = "VMUF"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Lucida Bright", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(381, 7)
        Label7.Name = "Label7"
        Label7.Size = New Size(89, 18)
        Label7.TabIndex = 3
        Label7.Text = "PAGEANT"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Red
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial Rounded MT Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(724, 2)
        Button1.Margin = New Padding(3, 2, 3, 2)
        Button1.Name = "Button1"
        Button1.Size = New Size(44, 33)
        Button1.TabIndex = 0
        Button1.Text = "X"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.CadetBlue
        Panel2.Controls.Add(PictureBox1)
        Panel2.Controls.Add(contestantcmbb)
        Panel2.Dock = DockStyle.Left
        Panel2.Location = New Point(0, 45)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(161, 477)
        Panel2.TabIndex = 82
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Location = New Point(640, 50)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(100, 100)
        PictureBox2.TabIndex = 88
        PictureBox2.TabStop = False
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.ActiveBorder
        Panel3.Controls.Add(Panel8)
        Panel3.Controls.Add(Panel4)
        Panel3.Location = New Point(220, 174)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(391, 238)
        Panel3.TabIndex = 89
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = SystemColors.ButtonShadow
        Panel8.Controls.Add(max3)
        Panel8.Controls.Add(Label1)
        Panel8.Controls.Add(min1)
        Panel8.Controls.Add(Label4)
        Panel8.Controls.Add(min3)
        Panel8.Controls.Add(max2)
        Panel8.Controls.Add(min2)
        Panel8.Controls.Add(max1)
        Panel8.Dock = DockStyle.Right
        Panel8.Location = New Point(242, 0)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(149, 238)
        Panel8.TabIndex = 99
        ' 
        ' max3
        ' 
        max3.AutoSize = True
        max3.Font = New Font("Century", 9.75F)
        max3.Location = New Point(96, 173)
        max3.Name = "max3"
        max3.Size = New Size(33, 16)
        max3.TabIndex = 95
        max3.Text = "Max"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century", 11.25F)
        Label1.Location = New Point(91, 16)
        Label1.Name = "Label1"
        Label1.Size = New Size(38, 18)
        Label1.TabIndex = 98
        Label1.Text = "Max"
        ' 
        ' min1
        ' 
        min1.AutoSize = True
        min1.Font = New Font("Century", 9.75F)
        min1.Location = New Point(11, 56)
        min1.Name = "min1"
        min1.Size = New Size(31, 16)
        min1.TabIndex = 91
        min1.Text = "Min"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century", 11.25F)
        Label4.Location = New Point(6, 16)
        Label4.Name = "Label4"
        Label4.Size = New Size(36, 18)
        Label4.TabIndex = 97
        Label4.Text = "Min"
        ' 
        ' min3
        ' 
        min3.AutoSize = True
        min3.Font = New Font("Century", 9.75F)
        min3.Location = New Point(11, 173)
        min3.Name = "min3"
        min3.Size = New Size(31, 16)
        min3.TabIndex = 92
        min3.Text = "Min"
        ' 
        ' max2
        ' 
        max2.AutoSize = True
        max2.Font = New Font("Century", 9.75F)
        max2.Location = New Point(96, 113)
        max2.Name = "max2"
        max2.Size = New Size(33, 16)
        max2.TabIndex = 96
        max2.Text = "Max"
        ' 
        ' min2
        ' 
        min2.AutoSize = True
        min2.Font = New Font("Century", 9.75F)
        min2.Location = New Point(11, 113)
        min2.Name = "min2"
        min2.Size = New Size(31, 16)
        min2.TabIndex = 93
        min2.Text = "Min"
        ' 
        ' max1
        ' 
        max1.AutoSize = True
        max1.Font = New Font("Century", 9.75F)
        max1.Location = New Point(96, 56)
        max1.Name = "max1"
        max1.Size = New Size(33, 16)
        max1.TabIndex = 94
        max1.Text = "Max"
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = SystemColors.ButtonShadow
        Panel4.Controls.Add(Panel5)
        Panel4.Controls.Add(Label2)
        Panel4.Controls.Add(Panel6)
        Panel4.Controls.Add(sub1)
        Panel4.Controls.Add(Panel7)
        Panel4.Controls.Add(Label3)
        Panel4.Dock = DockStyle.Left
        Panel4.Location = New Point(0, 0)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(212, 238)
        Panel4.TabIndex = 0
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = SystemColors.Window
        Panel5.Controls.Add(score3)
        Panel5.Location = New Point(27, 163)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(92, 27)
        Panel5.TabIndex = 101
        ' 
        ' score3
        ' 
        score3.Location = New Point(2, 2)
        score3.Margin = New Padding(3, 2, 3, 2)
        score3.Name = "score3"
        score3.Size = New Size(88, 23)
        score3.TabIndex = 17
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century", 9.75F)
        Label2.Location = New Point(24, 85)
        Label2.Name = "Label2"
        Label2.Size = New Size(37, 16)
        Label2.TabIndex = 89
        Label2.Text = "Sub2"
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = SystemColors.Window
        Panel6.Controls.Add(score2)
        Panel6.Location = New Point(27, 103)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(92, 27)
        Panel6.TabIndex = 100
        ' 
        ' score2
        ' 
        score2.Location = New Point(2, 2)
        score2.Margin = New Padding(3, 2, 3, 2)
        score2.Name = "score2"
        score2.Size = New Size(87, 23)
        score2.TabIndex = 15
        ' 
        ' sub1
        ' 
        sub1.AutoSize = True
        sub1.Font = New Font("Century", 9.75F)
        sub1.Location = New Point(24, 28)
        sub1.Name = "sub1"
        sub1.Size = New Size(37, 16)
        sub1.TabIndex = 88
        sub1.Text = "Sub1"
        ' 
        ' Panel7
        ' 
        Panel7.BackColor = SystemColors.Window
        Panel7.Controls.Add(score1)
        Panel7.Location = New Point(27, 46)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(92, 27)
        Panel7.TabIndex = 99
        ' 
        ' score1
        ' 
        score1.Location = New Point(3, 2)
        score1.Margin = New Padding(3, 2, 3, 2)
        score1.Name = "score1"
        score1.Size = New Size(87, 23)
        score1.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century", 9.75F)
        Label3.Location = New Point(27, 145)
        Label3.Name = "Label3"
        Label3.Size = New Size(37, 16)
        Label3.TabIndex = 90
        Label3.Text = "Sub3"
        ' 
        ' Form11
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.GrayText
        ClientSize = New Size(776, 522)
        Controls.Add(Panel3)
        Controls.Add(PictureBox2)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(nextbtn)
        Controls.Add(prebtn)
        Controls.Add(savebtn)
        Controls.Add(program)
        Controls.Add(contestantname)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        Name = "Form11"
        Text = "Scoring"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        Panel7.ResumeLayout(False)
        Panel7.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Judgeinfo As Label
    Friend WithEvents contestantcmbb As ComboBox
    Friend WithEvents contestantname As Label
    Friend WithEvents assignedgender As Label
    Friend WithEvents program As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents savebtn As Button
    Friend WithEvents prebtn As Button
    Friend WithEvents nextbtn As Button
    Friend WithEvents progresslabel As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents max3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents min1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents min3 As Label
    Friend WithEvents max2 As Label
    Friend WithEvents min2 As Label
    Friend WithEvents max1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents score3 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents score2 As TextBox
    Friend WithEvents sub1 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents score1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents category As Label
End Class
