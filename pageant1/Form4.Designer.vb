<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Deletebtn = New Button()
        Updatebtn = New Button()
        Insertbtn = New Button()
        Clearbtn = New Button()
        DataGridView1 = New DataGridView()
        Label3 = New Label()
        gendertxt = New TextBox()
        Panel1 = New Panel()
        Label2 = New Label()
        Label6 = New Label()
        Button1 = New Button()
        Panel4 = New Panel()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' Deletebtn
        ' 
        Deletebtn.BackColor = SystemColors.Window
        Deletebtn.Location = New Point(280, 195)
        Deletebtn.Margin = New Padding(3, 2, 3, 2)
        Deletebtn.Name = "Deletebtn"
        Deletebtn.Size = New Size(96, 22)
        Deletebtn.TabIndex = 21
        Deletebtn.Text = "Delete"
        Deletebtn.UseVisualStyleBackColor = False
        ' 
        ' Updatebtn
        ' 
        Updatebtn.BackColor = SystemColors.Window
        Updatebtn.Location = New Point(400, 195)
        Updatebtn.Margin = New Padding(3, 2, 3, 2)
        Updatebtn.Name = "Updatebtn"
        Updatebtn.Size = New Size(96, 22)
        Updatebtn.TabIndex = 20
        Updatebtn.Text = "Update"
        Updatebtn.UseVisualStyleBackColor = False
        ' 
        ' Insertbtn
        ' 
        Insertbtn.BackColor = SystemColors.Window
        Insertbtn.Location = New Point(158, 195)
        Insertbtn.Margin = New Padding(3, 2, 3, 2)
        Insertbtn.Name = "Insertbtn"
        Insertbtn.Size = New Size(96, 22)
        Insertbtn.TabIndex = 19
        Insertbtn.Text = "Insert"
        Insertbtn.UseVisualStyleBackColor = False
        ' 
        ' Clearbtn
        ' 
        Clearbtn.BackColor = SystemColors.Window
        Clearbtn.Location = New Point(38, 195)
        Clearbtn.Margin = New Padding(3, 2, 3, 2)
        Clearbtn.Name = "Clearbtn"
        Clearbtn.Size = New Size(96, 22)
        Clearbtn.TabIndex = 18
        Clearbtn.Text = "Clear"
        Clearbtn.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(267, 68)
        DataGridView1.Margin = New Padding(3, 2, 3, 2)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(256, 92)
        DataGridView1.TabIndex = 17
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(19, 106)
        Label3.Name = "Label3"
        Label3.Size = New Size(48, 15)
        Label3.TabIndex = 26
        Label3.Text = "Gender:"
        ' 
        ' gendertxt
        ' 
        gendertxt.Location = New Point(3, 2)
        gendertxt.Margin = New Padding(3, 2, 3, 2)
        gendertxt.Name = "gendertxt"
        gendertxt.Size = New Size(174, 23)
        gendertxt.TabIndex = 31
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.RoyalBlue
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Button1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(534, 38)
        Panel1.TabIndex = 32
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
        Button1.Location = New Point(487, 2)
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
        Panel4.Controls.Add(gendertxt)
        Panel4.Location = New Point(77, 101)
        Panel4.Margin = New Padding(3, 2, 3, 2)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(178, 25)
        Panel4.TabIndex = 33
        ' 
        ' Form4
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.AppWorkspace
        ClientSize = New Size(534, 255)
        Controls.Add(Panel4)
        Controls.Add(Panel1)
        Controls.Add(Label3)
        Controls.Add(Deletebtn)
        Controls.Add(Updatebtn)
        Controls.Add(Insertbtn)
        Controls.Add(Clearbtn)
        Controls.Add(DataGridView1)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        Name = "Form4"
        Text = "Genders"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Deletebtn As Button
    Friend WithEvents Updatebtn As Button
    Friend WithEvents Insertbtn As Button
    Friend WithEvents Clearbtn As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents gendertxt As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel4 As Panel
End Class
