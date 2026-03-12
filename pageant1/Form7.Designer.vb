<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
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
        Label4 = New Label()
        Label3 = New Label()
        Deletebtn = New Button()
        Updatebtn = New Button()
        Insertbtn = New Button()
        Clearbtn = New Button()
        DataGridView1 = New DataGridView()
        fullnametxt = New TextBox()
        passwordtxt = New TextBox()
        Label2 = New Label()
        gendercmbb = New ComboBox()
        Panel1 = New Panel()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Button1 = New Button()
        Panel3 = New Panel()
        Panel2 = New Panel()
        Panel4 = New Panel()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        Panel2.SuspendLayout()
        Panel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 72)
        Label4.Name = "Label4"
        Label4.Size = New Size(79, 20)
        Label4.TabIndex = 56
        Label4.Text = "Full Name:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(15, 232)
        Label3.Name = "Label3"
        Label3.Size = New Size(121, 20)
        Label3.TabIndex = 55
        Label3.Text = "Gender to Judge:"
        ' 
        ' Deletebtn
        ' 
        Deletebtn.Location = New Point(414, 344)
        Deletebtn.Name = "Deletebtn"
        Deletebtn.Size = New Size(113, 33)
        Deletebtn.TabIndex = 50
        Deletebtn.Text = "Delete"
        Deletebtn.UseVisualStyleBackColor = True
        ' 
        ' Updatebtn
        ' 
        Updatebtn.Location = New Point(554, 344)
        Updatebtn.Name = "Updatebtn"
        Updatebtn.Size = New Size(113, 33)
        Updatebtn.TabIndex = 49
        Updatebtn.Text = "Update"
        Updatebtn.UseVisualStyleBackColor = True
        ' 
        ' Insertbtn
        ' 
        Insertbtn.Location = New Point(272, 344)
        Insertbtn.Name = "Insertbtn"
        Insertbtn.Size = New Size(113, 33)
        Insertbtn.TabIndex = 48
        Insertbtn.Text = "Insert"
        Insertbtn.UseVisualStyleBackColor = True
        ' 
        ' Clearbtn
        ' 
        Clearbtn.Location = New Point(132, 344)
        Clearbtn.Name = "Clearbtn"
        Clearbtn.Size = New Size(113, 33)
        Clearbtn.TabIndex = 47
        Clearbtn.Text = "Clear"
        Clearbtn.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(331, 72)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(461, 225)
        DataGridView1.TabIndex = 46
        ' 
        ' fullnametxt
        ' 
        fullnametxt.Location = New Point(3, 3)
        fullnametxt.Name = "fullnametxt"
        fullnametxt.Size = New Size(265, 27)
        fullnametxt.TabIndex = 61
        ' 
        ' passwordtxt
        ' 
        passwordtxt.Location = New Point(3, 3)
        passwordtxt.Name = "passwordtxt"
        passwordtxt.Size = New Size(265, 27)
        passwordtxt.TabIndex = 63
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 154)
        Label2.Name = "Label2"
        Label2.Size = New Size(73, 20)
        Label2.TabIndex = 62
        Label2.Text = "Password:"
        ' 
        ' gendercmbb
        ' 
        gendercmbb.FormattingEnabled = True
        gendercmbb.Location = New Point(4, 3)
        gendercmbb.Name = "gendercmbb"
        gendercmbb.Size = New Size(166, 28)
        gendercmbb.TabIndex = 64
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.RoyalBlue
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(Button1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(805, 50)
        Panel1.TabIndex = 80
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(358, 8)
        Label5.Name = "Label5"
        Label5.Size = New Size(74, 23)
        Label5.TabIndex = 5
        Label5.Text = "Judges"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Century", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(58, 31)
        Label6.Name = "Label6"
        Label6.Size = New Size(48, 16)
        Label6.TabIndex = 4
        Label6.Text = "VMUF"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Lucida Bright", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(8, 8)
        Label7.Name = "Label7"
        Label7.Size = New Size(109, 23)
        Label7.TabIndex = 3
        Label7.Text = "PAGEANT"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Red
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial Rounded MT Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(752, 3)
        Button1.Name = "Button1"
        Button1.Size = New Size(50, 44)
        Button1.TabIndex = 0
        Button1.Text = "X"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.Window
        Panel3.Controls.Add(fullnametxt)
        Panel3.Location = New Point(11, 105)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(271, 33)
        Panel3.TabIndex = 81
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.Window
        Panel2.Controls.Add(passwordtxt)
        Panel2.Location = New Point(12, 186)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(271, 33)
        Panel2.TabIndex = 82
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = SystemColors.Window
        Panel4.Controls.Add(gendercmbb)
        Panel4.Location = New Point(11, 266)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(173, 33)
        Panel4.TabIndex = 83
        ' 
        ' Form7
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.AppWorkspace
        ClientSize = New Size(805, 407)
        Controls.Add(Panel4)
        Controls.Add(Panel2)
        Controls.Add(Panel3)
        Controls.Add(Panel1)
        Controls.Add(Label2)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Deletebtn)
        Controls.Add(Updatebtn)
        Controls.Add(Insertbtn)
        Controls.Add(Clearbtn)
        Controls.Add(DataGridView1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Form7"
        Text = "Judges"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel4.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Deletebtn As Button
    Friend WithEvents Updatebtn As Button
    Friend WithEvents Insertbtn As Button
    Friend WithEvents Clearbtn As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents fullnametxt As TextBox
    Friend WithEvents passwordtxt As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents gendercmbb As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
End Class
