<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Button1 = New Button()
        Button2 = New Button()
        Panel1 = New Panel()
        exitbtn = New Button()
        scrbtn = New Button()
        crtbtn = New Button()
        judgbtn = New Button()
        genbtn = New Button()
        progbtn = New Button()
        deptbtn = New Button()
        contbtn = New Button()
        Panel4 = New Panel()
        Panel3 = New Panel()
        Panel2 = New Panel()
        PictureBox1 = New PictureBox()
        Label3 = New Label()
        Label1 = New Label()
        Panel5 = New Panel()
        Label2 = New Label()
        Label4 = New Label()
        Panel6 = New Panel()
        PictureBox2 = New PictureBox()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel6.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.BackColor = SystemColors.GrayText
        Button1.Dock = DockStyle.Left
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatAppearance.MouseOverBackColor = Color.CadetBlue
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(0, 0)
        Button1.Margin = New Padding(3, 2, 3, 2)
        Button1.Name = "Button1"
        Button1.Size = New Size(324, 104)
        Button1.TabIndex = 3
        Button1.Text = "Rankings"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = SystemColors.GrayText
        Button2.Dock = DockStyle.Right
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatAppearance.MouseOverBackColor = Color.CadetBlue
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(324, 0)
        Button2.Margin = New Padding(3, 2, 3, 2)
        Button2.Name = "Button2"
        Button2.Size = New Size(315, 104)
        Button2.TabIndex = 4
        Button2.Text = "LOG IN"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.CadetBlue
        Panel1.Controls.Add(exitbtn)
        Panel1.Controls.Add(scrbtn)
        Panel1.Controls.Add(crtbtn)
        Panel1.Controls.Add(judgbtn)
        Panel1.Controls.Add(genbtn)
        Panel1.Controls.Add(progbtn)
        Panel1.Controls.Add(deptbtn)
        Panel1.Controls.Add(contbtn)
        Panel1.Controls.Add(Panel4)
        Panel1.Controls.Add(Panel3)
        Panel1.Controls.Add(Panel2)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(216, 462)
        Panel1.TabIndex = 6
        ' 
        ' exitbtn
        ' 
        exitbtn.Dock = DockStyle.Bottom
        exitbtn.FlatAppearance.BorderSize = 0
        exitbtn.FlatStyle = FlatStyle.Flat
        exitbtn.Font = New Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        exitbtn.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        exitbtn.Location = New Point(13, 430)
        exitbtn.Margin = New Padding(3, 2, 3, 2)
        exitbtn.Name = "exitbtn"
        exitbtn.Size = New Size(190, 32)
        exitbtn.TabIndex = 10
        exitbtn.Text = "Exit"
        exitbtn.TextAlign = ContentAlignment.MiddleLeft
        exitbtn.UseVisualStyleBackColor = True
        ' 
        ' scrbtn
        ' 
        scrbtn.Dock = DockStyle.Top
        scrbtn.FlatAppearance.BorderSize = 0
        scrbtn.FlatStyle = FlatStyle.Flat
        scrbtn.Font = New Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        scrbtn.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        scrbtn.Location = New Point(13, 305)
        scrbtn.Margin = New Padding(3, 2, 3, 2)
        scrbtn.Name = "scrbtn"
        scrbtn.Size = New Size(190, 41)
        scrbtn.TabIndex = 9
        scrbtn.Text = "Scores"
        scrbtn.TextAlign = ContentAlignment.MiddleLeft
        scrbtn.UseVisualStyleBackColor = True
        ' 
        ' crtbtn
        ' 
        crtbtn.Dock = DockStyle.Top
        crtbtn.FlatAppearance.BorderSize = 0
        crtbtn.FlatStyle = FlatStyle.Flat
        crtbtn.Font = New Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        crtbtn.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        crtbtn.Location = New Point(13, 264)
        crtbtn.Margin = New Padding(3, 2, 3, 2)
        crtbtn.Name = "crtbtn"
        crtbtn.Size = New Size(190, 41)
        crtbtn.TabIndex = 8
        crtbtn.Text = "Criteria"
        crtbtn.TextAlign = ContentAlignment.MiddleLeft
        crtbtn.UseVisualStyleBackColor = True
        ' 
        ' judgbtn
        ' 
        judgbtn.Dock = DockStyle.Top
        judgbtn.FlatAppearance.BorderSize = 0
        judgbtn.FlatStyle = FlatStyle.Flat
        judgbtn.Font = New Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        judgbtn.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        judgbtn.Location = New Point(13, 223)
        judgbtn.Margin = New Padding(3, 2, 3, 2)
        judgbtn.Name = "judgbtn"
        judgbtn.Size = New Size(190, 41)
        judgbtn.TabIndex = 7
        judgbtn.Text = "Judges"
        judgbtn.TextAlign = ContentAlignment.MiddleLeft
        judgbtn.UseVisualStyleBackColor = True
        ' 
        ' genbtn
        ' 
        genbtn.Dock = DockStyle.Top
        genbtn.FlatAppearance.BorderSize = 0
        genbtn.FlatStyle = FlatStyle.Flat
        genbtn.Font = New Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        genbtn.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        genbtn.Location = New Point(13, 182)
        genbtn.Margin = New Padding(3, 2, 3, 2)
        genbtn.Name = "genbtn"
        genbtn.Size = New Size(190, 41)
        genbtn.TabIndex = 6
        genbtn.Text = "Genders"
        genbtn.TextAlign = ContentAlignment.MiddleLeft
        genbtn.UseVisualStyleBackColor = True
        ' 
        ' progbtn
        ' 
        progbtn.Dock = DockStyle.Top
        progbtn.FlatAppearance.BorderSize = 0
        progbtn.FlatStyle = FlatStyle.Flat
        progbtn.Font = New Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        progbtn.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        progbtn.Location = New Point(13, 141)
        progbtn.Margin = New Padding(3, 2, 3, 2)
        progbtn.Name = "progbtn"
        progbtn.Size = New Size(190, 41)
        progbtn.TabIndex = 5
        progbtn.Text = "Programs"
        progbtn.TextAlign = ContentAlignment.MiddleLeft
        progbtn.UseVisualStyleBackColor = True
        ' 
        ' deptbtn
        ' 
        deptbtn.Dock = DockStyle.Top
        deptbtn.FlatAppearance.BorderSize = 0
        deptbtn.FlatStyle = FlatStyle.Flat
        deptbtn.Font = New Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        deptbtn.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        deptbtn.Location = New Point(13, 100)
        deptbtn.Margin = New Padding(3, 2, 3, 2)
        deptbtn.Name = "deptbtn"
        deptbtn.Size = New Size(190, 41)
        deptbtn.TabIndex = 4
        deptbtn.Text = "Departments"
        deptbtn.TextAlign = ContentAlignment.MiddleLeft
        deptbtn.UseVisualStyleBackColor = True
        ' 
        ' contbtn
        ' 
        contbtn.Dock = DockStyle.Top
        contbtn.FlatAppearance.BorderSize = 0
        contbtn.FlatStyle = FlatStyle.Flat
        contbtn.Font = New Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        contbtn.ForeColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        contbtn.Location = New Point(13, 59)
        contbtn.Margin = New Padding(3, 2, 3, 2)
        contbtn.Name = "contbtn"
        contbtn.Size = New Size(190, 41)
        contbtn.TabIndex = 3
        contbtn.Text = "Contestants"
        contbtn.TextAlign = ContentAlignment.MiddleLeft
        contbtn.UseVisualStyleBackColor = True
        ' 
        ' Panel4
        ' 
        Panel4.Dock = DockStyle.Right
        Panel4.Location = New Point(203, 59)
        Panel4.Margin = New Padding(3, 2, 3, 2)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(13, 403)
        Panel4.TabIndex = 2
        ' 
        ' Panel3
        ' 
        Panel3.Dock = DockStyle.Left
        Panel3.Location = New Point(0, 59)
        Panel3.Margin = New Padding(3, 2, 3, 2)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(13, 403)
        Panel3.TabIndex = 1
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.DarkSlateGray
        Panel2.Controls.Add(PictureBox1)
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(Label1)
        Panel2.Dock = DockStyle.Top
        Panel2.ForeColor = Color.Yellow
        Panel2.Location = New Point(0, 0)
        Panel2.Margin = New Padding(3, 2, 3, 2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(216, 59)
        Panel2.TabIndex = 0
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.crown
        PictureBox1.Location = New Point(12, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(53, 51)
        PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
        PictureBox1.TabIndex = 3
        PictureBox1.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(105, 26)
        Label3.Name = "Label3"
        Label3.Size = New Size(41, 15)
        Label3.TabIndex = 2
        Label3.Text = "VMUF"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Lucida Bright", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(61, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(89, 18)
        Label1.TabIndex = 1
        Label1.Text = "PAGEANT"
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.DarkSlateGray
        Panel5.Dock = DockStyle.Top
        Panel5.Location = New Point(216, 0)
        Panel5.Margin = New Padding(3, 2, 3, 2)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(640, 59)
        Panel5.TabIndex = 7
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Lucida Bright", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(295, 113)
        Label2.Name = "Label2"
        Label2.Size = New Size(267, 54)
        Label2.TabIndex = 8
        Label2.Text = "PAGEANT"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century", 24F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(432, 164)
        Label4.Name = "Label4"
        Label4.Size = New Size(117, 38)
        Label4.TabIndex = 9
        Label4.Text = "VMUF"
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = SystemColors.GrayText
        Panel6.Controls.Add(Button1)
        Panel6.Controls.Add(Button2)
        Panel6.Location = New Point(216, 299)
        Panel6.Margin = New Padding(3, 2, 3, 2)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(639, 104)
        Panel6.TabIndex = 10
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.bigcrown
        PictureBox2.Location = New Point(555, 93)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(130, 130)
        PictureBox2.SizeMode = PictureBoxSizeMode.AutoSize
        PictureBox2.TabIndex = 5
        PictureBox2.TabStop = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.GrayText
        ClientSize = New Size(856, 462)
        Controls.Add(PictureBox2)
        Controls.Add(Panel6)
        Controls.Add(Label2)
        Controls.Add(Label4)
        Controls.Add(Panel5)
        Controls.Add(Panel1)
        ForeColor = SystemColors.ActiveCaptionText
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        Name = "Form1"
        Text = "PAGEANT"
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel6.ResumeLayout(False)
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents contbtn As Button
    Friend WithEvents crtbtn As Button
    Friend WithEvents judgbtn As Button
    Friend WithEvents genbtn As Button
    Friend WithEvents progbtn As Button
    Friend WithEvents deptbtn As Button
    Friend WithEvents scrbtn As Button
    Friend WithEvents exitbtn As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox

End Class
