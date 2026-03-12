<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Label3 = New Label()
        Label4 = New Label()
        Clearbtn = New Button()
        Insertbtn = New Button()
        Updatebtn = New Button()
        Viewbtn = New Button()
        Deletebtn = New Button()
        contestantnum = New TextBox()
        Label5 = New Label()
        programIDtxt = New ComboBox()
        GenderIDtxt = New ComboBox()
        PictureBox1 = New PictureBox()
        browsebtn = New Button()
        Panel1 = New Panel()
        Label7 = New Label()
        Label2 = New Label()
        Label6 = New Label()
        Button1 = New Button()
        fullnametxt = New TextBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(22, 104)
        Label1.Name = "Label1"
        Label1.Size = New Size(64, 15)
        Label1.TabIndex = 0
        Label1.Text = "Full Name:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(22, 207)
        Label3.Name = "Label3"
        Label3.Size = New Size(56, 15)
        Label3.TabIndex = 2
        Label3.Text = "Program:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(24, 155)
        Label4.Name = "Label4"
        Label4.Size = New Size(48, 15)
        Label4.TabIndex = 3
        Label4.Text = "Gender:"
        ' 
        ' Clearbtn
        ' 
        Clearbtn.Location = New Point(71, 287)
        Clearbtn.Margin = New Padding(3, 2, 3, 2)
        Clearbtn.Name = "Clearbtn"
        Clearbtn.Size = New Size(82, 22)
        Clearbtn.TabIndex = 9
        Clearbtn.Text = "Clear"
        Clearbtn.UseVisualStyleBackColor = True
        ' 
        ' Insertbtn
        ' 
        Insertbtn.Location = New Point(176, 287)
        Insertbtn.Margin = New Padding(3, 2, 3, 2)
        Insertbtn.Name = "Insertbtn"
        Insertbtn.Size = New Size(82, 22)
        Insertbtn.TabIndex = 10
        Insertbtn.Text = "Insert"
        Insertbtn.UseVisualStyleBackColor = True
        ' 
        ' Updatebtn
        ' 
        Updatebtn.Location = New Point(382, 287)
        Updatebtn.Margin = New Padding(3, 2, 3, 2)
        Updatebtn.Name = "Updatebtn"
        Updatebtn.Size = New Size(82, 22)
        Updatebtn.TabIndex = 11
        Updatebtn.Text = "Update"
        Updatebtn.UseVisualStyleBackColor = True
        ' 
        ' Viewbtn
        ' 
        Viewbtn.Location = New Point(577, 287)
        Viewbtn.Margin = New Padding(3, 2, 3, 2)
        Viewbtn.Name = "Viewbtn"
        Viewbtn.Size = New Size(82, 22)
        Viewbtn.TabIndex = 14
        Viewbtn.Text = "View"
        Viewbtn.UseVisualStyleBackColor = True
        ' 
        ' Deletebtn
        ' 
        Deletebtn.Location = New Point(277, 287)
        Deletebtn.Margin = New Padding(3, 2, 3, 2)
        Deletebtn.Name = "Deletebtn"
        Deletebtn.Size = New Size(82, 22)
        Deletebtn.TabIndex = 12
        Deletebtn.Text = "Delete"
        Deletebtn.UseVisualStyleBackColor = True
        ' 
        ' contestantnum
        ' 
        contestantnum.BackColor = SystemColors.Window
        contestantnum.Location = New Point(22, 69)
        contestantnum.Margin = New Padding(3, 2, 3, 2)
        contestantnum.Name = "contestantnum"
        contestantnum.Size = New Size(173, 23)
        contestantnum.TabIndex = 18
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(22, 52)
        Label5.Name = "Label5"
        Label5.Size = New Size(115, 15)
        Label5.TabIndex = 17
        Label5.Text = "Contestant Number:"
        ' 
        ' programIDtxt
        ' 
        programIDtxt.FormattingEnabled = True
        programIDtxt.Location = New Point(22, 233)
        programIDtxt.Margin = New Padding(3, 2, 3, 2)
        programIDtxt.Name = "programIDtxt"
        programIDtxt.Size = New Size(364, 23)
        programIDtxt.TabIndex = 19
        ' 
        ' GenderIDtxt
        ' 
        GenderIDtxt.FormattingEnabled = True
        GenderIDtxt.Location = New Point(22, 182)
        GenderIDtxt.Margin = New Padding(3, 2, 3, 2)
        GenderIDtxt.Name = "GenderIDtxt"
        GenderIDtxt.Size = New Size(173, 23)
        GenderIDtxt.TabIndex = 20
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Location = New Point(523, 52)
        PictureBox1.Margin = New Padding(3, 2, 3, 2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(102, 78)
        PictureBox1.TabIndex = 21
        PictureBox1.TabStop = False
        ' 
        ' browsebtn
        ' 
        browsebtn.Location = New Point(658, 52)
        browsebtn.Margin = New Padding(3, 2, 3, 2)
        browsebtn.Name = "browsebtn"
        browsebtn.Size = New Size(82, 22)
        browsebtn.TabIndex = 22
        browsebtn.Text = "Browse"
        browsebtn.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.RoyalBlue
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Button1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(775, 38)
        Panel1.TabIndex = 24
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(346, 9)
        Label7.Name = "Label7"
        Label7.Size = New Size(98, 20)
        Label7.TabIndex = 6
        Label7.Text = "Contestants"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(51, 23)
        Label2.Name = "Label2"
        Label2.Size = New Size(41, 15)
        Label2.TabIndex = 4
        Label2.Text = "VMUF"
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
        Button1.Location = New Point(731, 3)
        Button1.Margin = New Padding(3, 2, 3, 2)
        Button1.Name = "Button1"
        Button1.Size = New Size(44, 33)
        Button1.TabIndex = 0
        Button1.Text = "X"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' fullnametxt
        ' 
        fullnametxt.Location = New Point(22, 130)
        fullnametxt.Margin = New Padding(3, 2, 3, 2)
        fullnametxt.Name = "fullnametxt"
        fullnametxt.Size = New Size(364, 23)
        fullnametxt.TabIndex = 4
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.AppWorkspace
        ClientSize = New Size(775, 349)
        Controls.Add(programIDtxt)
        Controls.Add(contestantnum)
        Controls.Add(GenderIDtxt)
        Controls.Add(fullnametxt)
        Controls.Add(Panel1)
        Controls.Add(browsebtn)
        Controls.Add(PictureBox1)
        Controls.Add(Label5)
        Controls.Add(Viewbtn)
        Controls.Add(Deletebtn)
        Controls.Add(Updatebtn)
        Controls.Add(Insertbtn)
        Controls.Add(Clearbtn)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        Name = "Form2"
        Text = "Contestants"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Clearbtn As Button
    Friend WithEvents Insertbtn As Button
    Friend WithEvents Updatebtn As Button
    Friend WithEvents Viewbtn As Button
    Friend WithEvents Deletebtn As Button
    Friend WithEvents contestantnum As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents programIDtxt As ComboBox
    Friend WithEvents GenderIDtxt As ComboBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents browsebtn As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents fullnametxt As TextBox
End Class
