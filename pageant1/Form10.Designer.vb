<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form10
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
        passwordtxt = New TextBox()
        Label2 = New Label()
        Label4 = New Label()
        fullnametxt = New ComboBox()
        loginbtn = New Button()
        Label1 = New Label()
        Panel1 = New Panel()
        Label6 = New Label()
        Panel4 = New Panel()
        Panel3 = New Panel()
        Panel2 = New Panel()
        Label3 = New Label()
        Label5 = New Label()
        PictureBox1 = New PictureBox()
        Panel1.SuspendLayout()
        Panel4.SuspendLayout()
        Panel3.SuspendLayout()
        Panel2.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' passwordtxt
        ' 
        passwordtxt.Location = New Point(3, 4)
        passwordtxt.Margin = New Padding(3, 2, 3, 2)
        passwordtxt.Name = "passwordtxt"
        passwordtxt.Size = New Size(232, 23)
        passwordtxt.TabIndex = 67
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(45, 256)
        Label2.Name = "Label2"
        Label2.Size = New Size(82, 20)
        Label2.TabIndex = 66
        Label2.Text = "Password:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(45, 182)
        Label4.Name = "Label4"
        Label4.Size = New Size(92, 20)
        Label4.TabIndex = 64
        Label4.Text = "Full Name:"
        ' 
        ' fullnametxt
        ' 
        fullnametxt.FormattingEnabled = True
        fullnametxt.Location = New Point(3, 2)
        fullnametxt.Margin = New Padding(3, 2, 3, 2)
        fullnametxt.Name = "fullnametxt"
        fullnametxt.Size = New Size(232, 23)
        fullnametxt.TabIndex = 68
        ' 
        ' loginbtn
        ' 
        loginbtn.BackColor = SystemColors.ActiveCaptionText
        loginbtn.FlatAppearance.BorderSize = 0
        loginbtn.FlatStyle = FlatStyle.Flat
        loginbtn.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        loginbtn.ForeColor = SystemColors.ControlLightLight
        loginbtn.Location = New Point(45, 346)
        loginbtn.Margin = New Padding(3, 2, 3, 2)
        loginbtn.Name = "loginbtn"
        loginbtn.Size = New Size(240, 29)
        loginbtn.TabIndex = 69
        loginbtn.Text = "Log In"
        loginbtn.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(114, 130)
        Label1.Name = "Label1"
        Label1.Size = New Size(95, 28)
        Label1.TabIndex = 71
        Label1.Text = "LOG IN"
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Panel4)
        Panel1.Controls.Add(Panel3)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(loginbtn)
        Panel1.Dock = DockStyle.Right
        Panel1.Location = New Point(347, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(325, 499)
        Panel1.TabIndex = 72
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(281, 470)
        Label6.Name = "Label6"
        Label6.Size = New Size(41, 20)
        Label6.TabIndex = 7
        Label6.Text = "Exit"
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = SystemColors.Window
        Panel4.Controls.Add(fullnametxt)
        Panel4.Location = New Point(45, 205)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(240, 29)
        Panel4.TabIndex = 73
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.Window
        Panel3.Controls.Add(passwordtxt)
        Panel3.Location = New Point(45, 283)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(240, 29)
        Panel3.TabIndex = 72
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.CadetBlue
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(Label5)
        Panel2.Controls.Add(PictureBox1)
        Panel2.Dock = DockStyle.Left
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(350, 499)
        Panel2.TabIndex = 73
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(242, 182)
        Label3.Name = "Label3"
        Label3.Size = New Size(78, 25)
        Label3.TabIndex = 6
        Label3.Text = "VMUF"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Lucida Bright", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(151, 146)
        Label5.Name = "Label5"
        Label5.Size = New Size(180, 36)
        Label5.TabIndex = 5
        Label5.Text = "PAGEANT"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.bigcrown
        PictureBox1.Location = New Point(15, 139)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(130, 130)
        PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
        PictureBox1.TabIndex = 4
        PictureBox1.TabStop = False
        ' 
        ' Form10
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonShadow
        ClientSize = New Size(672, 499)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        Name = "Form10"
        Text = "Log In"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents passwordtxt As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents fullnametxt As ComboBox
    Friend WithEvents loginbtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class
