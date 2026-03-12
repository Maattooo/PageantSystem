<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form9
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
        loadbtn = New Button()
        Clearbtn = New Button()
        DataGridView1 = New DataGridView()
        criteriacmb = New ComboBox()
        Panel1 = New Panel()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Button1 = New Button()
        gendercmbb = New ComboBox()
        Label2 = New Label()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 182)
        Label1.Name = "Label1"
        Label1.Size = New Size(48, 15)
        Label1.TabIndex = 89
        Label1.Text = "Criteria:"
        ' 
        ' loadbtn
        ' 
        loadbtn.Location = New Point(153, 331)
        loadbtn.Margin = New Padding(3, 2, 3, 2)
        loadbtn.Name = "loadbtn"
        loadbtn.Size = New Size(113, 33)
        loadbtn.TabIndex = 82
        loadbtn.Text = "Load"
        loadbtn.UseVisualStyleBackColor = True
        ' 
        ' Clearbtn
        ' 
        Clearbtn.Location = New Point(359, 331)
        Clearbtn.Margin = New Padding(3, 2, 3, 2)
        Clearbtn.Name = "Clearbtn"
        Clearbtn.Size = New Size(113, 33)
        Clearbtn.TabIndex = 78
        Clearbtn.Text = "Clear"
        Clearbtn.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(242, 52)
        DataGridView1.Margin = New Padding(3, 2, 3, 2)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(635, 275)
        DataGridView1.TabIndex = 77
        ' 
        ' criteriacmb
        ' 
        criteriacmb.FormattingEnabled = True
        criteriacmb.Location = New Point(12, 199)
        criteriacmb.Margin = New Padding(3, 2, 3, 2)
        criteriacmb.Name = "criteriacmb"
        criteriacmb.Size = New Size(190, 23)
        criteriacmb.TabIndex = 98
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.RoyalBlue
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(Label8)
        Panel1.Controls.Add(Button1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(889, 38)
        Panel1.TabIndex = 99
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(437, 3)
        Label6.Name = "Label6"
        Label6.Size = New Size(56, 20)
        Label6.TabIndex = 5
        Label6.Text = "Scores"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Century", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(51, 23)
        Label7.Name = "Label7"
        Label7.Size = New Size(41, 15)
        Label7.TabIndex = 4
        Label7.Text = "VMUF"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Lucida Bright", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(7, 6)
        Label8.Name = "Label8"
        Label8.Size = New Size(89, 18)
        Label8.TabIndex = 3
        Label8.Text = "PAGEANT"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Red
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial Rounded MT Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(842, 3)
        Button1.Margin = New Padding(3, 2, 3, 2)
        Button1.Name = "Button1"
        Button1.Size = New Size(44, 33)
        Button1.TabIndex = 0
        Button1.Text = "X"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' gendercmbb
        ' 
        gendercmbb.FormattingEnabled = True
        gendercmbb.Location = New Point(12, 98)
        gendercmbb.Margin = New Padding(3, 2, 3, 2)
        gendercmbb.Name = "gendercmbb"
        gendercmbb.Size = New Size(190, 23)
        gendercmbb.TabIndex = 101
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 81)
        Label2.Name = "Label2"
        Label2.Size = New Size(48, 15)
        Label2.TabIndex = 100
        Label2.Text = "Gender:"
        ' 
        ' Form9
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.AppWorkspace
        ClientSize = New Size(889, 456)
        Controls.Add(gendercmbb)
        Controls.Add(Label2)
        Controls.Add(Panel1)
        Controls.Add(criteriacmb)
        Controls.Add(Label1)
        Controls.Add(loadbtn)
        Controls.Add(Clearbtn)
        Controls.Add(DataGridView1)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        Name = "Form9"
        Text = "Scores"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents loadbtn As Button
    Friend WithEvents Clearbtn As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents criteriacmb As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents gendercmbb As ComboBox
    Friend WithEvents Label2 As Label
End Class
