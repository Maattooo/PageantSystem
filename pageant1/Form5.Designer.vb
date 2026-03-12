<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
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
        programnametxt = New TextBox()
        departmentIDtxt = New ComboBox()
        Panel1 = New Panel()
        Label1 = New Label()
        Label2 = New Label()
        Label6 = New Label()
        Button1 = New Button()
        Panel4 = New Panel()
        Panel2 = New Panel()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel4.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(51, 303)
        Label4.Name = "Label4"
        Label4.Size = New Size(91, 15)
        Label4.TabIndex = 72
        Label4.Text = "Program Name:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(51, 362)
        Label3.Name = "Label3"
        Label3.Size = New Size(73, 15)
        Label3.TabIndex = 71
        Label3.Text = "Department:"
        ' 
        ' Deletebtn
        ' 
        Deletebtn.BackColor = SystemColors.Window
        Deletebtn.Location = New Point(631, 352)
        Deletebtn.Margin = New Padding(3, 2, 3, 2)
        Deletebtn.Name = "Deletebtn"
        Deletebtn.Size = New Size(99, 25)
        Deletebtn.TabIndex = 66
        Deletebtn.Text = "Delete"
        Deletebtn.UseVisualStyleBackColor = False
        ' 
        ' Updatebtn
        ' 
        Updatebtn.BackColor = SystemColors.Window
        Updatebtn.Location = New Point(755, 352)
        Updatebtn.Margin = New Padding(3, 2, 3, 2)
        Updatebtn.Name = "Updatebtn"
        Updatebtn.Size = New Size(99, 25)
        Updatebtn.TabIndex = 65
        Updatebtn.Text = "Update"
        Updatebtn.UseVisualStyleBackColor = False
        ' 
        ' Insertbtn
        ' 
        Insertbtn.BackColor = SystemColors.Window
        Insertbtn.Location = New Point(511, 352)
        Insertbtn.Margin = New Padding(3, 2, 3, 2)
        Insertbtn.Name = "Insertbtn"
        Insertbtn.Size = New Size(99, 25)
        Insertbtn.TabIndex = 64
        Insertbtn.Text = "Insert"
        Insertbtn.UseVisualStyleBackColor = False
        ' 
        ' Clearbtn
        ' 
        Clearbtn.BackColor = SystemColors.Window
        Clearbtn.Location = New Point(386, 353)
        Clearbtn.Margin = New Padding(3, 2, 3, 2)
        Clearbtn.Name = "Clearbtn"
        Clearbtn.Size = New Size(99, 25)
        Clearbtn.TabIndex = 63
        Clearbtn.Text = "Clear"
        Clearbtn.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(25, 58)
        DataGridView1.Margin = New Padding(3, 2, 3, 2)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(849, 243)
        DataGridView1.TabIndex = 62
        ' 
        ' programnametxt
        ' 
        programnametxt.Location = New Point(3, 2)
        programnametxt.Margin = New Padding(3, 2, 3, 2)
        programnametxt.Name = "programnametxt"
        programnametxt.Size = New Size(274, 23)
        programnametxt.TabIndex = 76
        ' 
        ' departmentIDtxt
        ' 
        departmentIDtxt.FormattingEnabled = True
        departmentIDtxt.Location = New Point(4, 2)
        departmentIDtxt.Margin = New Padding(3, 2, 3, 2)
        departmentIDtxt.Name = "departmentIDtxt"
        departmentIDtxt.Size = New Size(274, 23)
        departmentIDtxt.TabIndex = 77
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.RoyalBlue
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Button1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(902, 38)
        Panel1.TabIndex = 78
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(390, 7)
        Label1.Name = "Label1"
        Label1.Size = New Size(81, 20)
        Label1.TabIndex = 6
        Label1.Text = "Programs"
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
        Button1.Location = New Point(853, 0)
        Button1.Margin = New Padding(3, 2, 3, 2)
        Button1.Name = "Button1"
        Button1.Size = New Size(44, 33)
        Button1.TabIndex = 0
        Button1.Text = "X"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = SystemColors.Window
        Panel4.Controls.Add(departmentIDtxt)
        Panel4.Location = New Point(51, 379)
        Panel4.Margin = New Padding(3, 2, 3, 2)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(280, 25)
        Panel4.TabIndex = 79
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.Window
        Panel2.Controls.Add(programnametxt)
        Panel2.Location = New Point(51, 323)
        Panel2.Margin = New Padding(3, 2, 3, 2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(280, 25)
        Panel2.TabIndex = 80
        ' 
        ' Form5
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.AppWorkspace
        ClientSize = New Size(902, 432)
        Controls.Add(Panel2)
        Controls.Add(Panel4)
        Controls.Add(Panel1)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Deletebtn)
        Controls.Add(Updatebtn)
        Controls.Add(Insertbtn)
        Controls.Add(Clearbtn)
        Controls.Add(DataGridView1)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        Name = "Form5"
        Text = "Programs"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
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
    Friend WithEvents programnametxt As TextBox
    Friend WithEvents departmentIDtxt As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
End Class
