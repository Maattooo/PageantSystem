<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form6
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
        Deletebtn = New Button()
        Updatebtn = New Button()
        Insertbtn = New Button()
        Clearbtn = New Button()
        DataGridView1 = New DataGridView()
        departmentnametxt = New TextBox()
        Panel1 = New Panel()
        Label1 = New Label()
        Label2 = New Label()
        Label6 = New Label()
        Button1 = New Button()
        Panel3 = New Panel()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(28, 143)
        Label4.Name = "Label4"
        Label4.Size = New Size(136, 20)
        Label4.TabIndex = 56
        Label4.Text = "Department Name:"
        ' 
        ' Deletebtn
        ' 
        Deletebtn.Location = New Point(385, 326)
        Deletebtn.Name = "Deletebtn"
        Deletebtn.Size = New Size(113, 33)
        Deletebtn.TabIndex = 50
        Deletebtn.Text = "Delete"
        Deletebtn.UseVisualStyleBackColor = True
        ' 
        ' Updatebtn
        ' 
        Updatebtn.Location = New Point(521, 326)
        Updatebtn.Name = "Updatebtn"
        Updatebtn.Size = New Size(113, 33)
        Updatebtn.TabIndex = 49
        Updatebtn.Text = "Update"
        Updatebtn.UseVisualStyleBackColor = True
        ' 
        ' Insertbtn
        ' 
        Insertbtn.Location = New Point(250, 326)
        Insertbtn.Name = "Insertbtn"
        Insertbtn.Size = New Size(113, 33)
        Insertbtn.TabIndex = 48
        Insertbtn.Text = "Insert"
        Insertbtn.UseVisualStyleBackColor = True
        ' 
        ' Clearbtn
        ' 
        Clearbtn.Location = New Point(117, 326)
        Clearbtn.Name = "Clearbtn"
        Clearbtn.Size = New Size(113, 33)
        Clearbtn.TabIndex = 47
        Clearbtn.Text = "Clear"
        Clearbtn.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(370, 96)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(371, 178)
        DataGridView1.TabIndex = 46
        ' 
        ' departmentnametxt
        ' 
        departmentnametxt.Location = New Point(3, 3)
        departmentnametxt.Name = "departmentnametxt"
        departmentnametxt.Size = New Size(313, 27)
        departmentnametxt.TabIndex = 59
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
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(753, 50)
        Panel1.TabIndex = 79
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(300, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(132, 23)
        Label1.TabIndex = 5
        Label1.Text = "Departments"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(58, 31)
        Label2.Name = "Label2"
        Label2.Size = New Size(48, 16)
        Label2.TabIndex = 4
        Label2.Text = "VMUF"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Lucida Bright", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(8, 8)
        Label6.Name = "Label6"
        Label6.Size = New Size(109, 23)
        Label6.TabIndex = 3
        Label6.Text = "PAGEANT"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Red
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial Rounded MT Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(700, 3)
        Button1.Name = "Button1"
        Button1.Size = New Size(50, 44)
        Button1.TabIndex = 0
        Button1.Text = "X"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.Window
        Panel3.Controls.Add(departmentnametxt)
        Panel3.Location = New Point(28, 175)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(320, 33)
        Panel3.TabIndex = 80
        ' 
        ' Form6
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.AppWorkspace
        ClientSize = New Size(753, 409)
        Controls.Add(Panel3)
        Controls.Add(Panel1)
        Controls.Add(Label4)
        Controls.Add(Deletebtn)
        Controls.Add(Updatebtn)
        Controls.Add(Insertbtn)
        Controls.Add(Clearbtn)
        Controls.Add(DataGridView1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Form6"
        Text = "Departments"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label4 As Label
    Friend WithEvents Deletebtn As Button
    Friend WithEvents Updatebtn As Button
    Friend WithEvents Insertbtn As Button
    Friend WithEvents Clearbtn As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents departmentnametxt As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
End Class
