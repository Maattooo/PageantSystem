<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form14
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
        School = New Button()
        Panel2 = New Panel()
        Panel5 = New Panel()
        Panel4 = New Panel()
        Panel3 = New Panel()
        Finals = New Button()
        Formal = New Button()
        Shorts = New Button()
        Panel1 = New Panel()
        Button1 = New Button()
        PictureBox1 = New PictureBox()
        Label3 = New Label()
        Label1 = New Label()
        judge = New Label()
        Panel2.SuspendLayout()
        Panel5.SuspendLayout()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' School
        ' 
        School.BackColor = SystemColors.ControlDark
        School.FlatAppearance.BorderColor = Color.DarkSlateGray
        School.FlatAppearance.MouseDownBackColor = Color.Red
        School.FlatAppearance.MouseOverBackColor = Color.Salmon
        School.FlatStyle = FlatStyle.Flat
        School.Font = New Font("Century", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        School.ForeColor = Color.DarkSlateGray
        School.Location = New Point(71, 17)
        School.Margin = New Padding(3, 2, 3, 2)
        School.Name = "School"
        School.Size = New Size(500, 67)
        School.TabIndex = 0
        School.Text = "SCHOOL WEAR"
        School.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Panel5)
        Panel2.Controls.Add(Panel1)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(645, 420)
        Panel2.TabIndex = 7
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = SystemColors.AppWorkspace
        Panel5.Controls.Add(Panel4)
        Panel5.Controls.Add(Panel3)
        Panel5.Controls.Add(Finals)
        Panel5.Controls.Add(Formal)
        Panel5.Controls.Add(Shorts)
        Panel5.Controls.Add(School)
        Panel5.Dock = DockStyle.Fill
        Panel5.Location = New Point(0, 55)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(645, 365)
        Panel5.TabIndex = 10
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = SystemColors.ControlDarkDark
        Panel4.Dock = DockStyle.Right
        Panel4.Location = New Point(577, 0)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(68, 365)
        Panel4.TabIndex = 9
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.ControlDarkDark
        Panel3.Dock = DockStyle.Left
        Panel3.Location = New Point(0, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(65, 365)
        Panel3.TabIndex = 8
        ' 
        ' Finals
        ' 
        Finals.BackColor = SystemColors.ControlDark
        Finals.FlatAppearance.MouseDownBackColor = Color.Gold
        Finals.FlatAppearance.MouseOverBackColor = Color.DarkCyan
        Finals.FlatStyle = FlatStyle.Flat
        Finals.Font = New Font("Century", 21.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Finals.ForeColor = Color.DarkSlateGray
        Finals.Location = New Point(71, 273)
        Finals.Margin = New Padding(3, 2, 3, 2)
        Finals.Name = "Finals"
        Finals.Size = New Size(500, 90)
        Finals.TabIndex = 7
        Finals.Text = "FINALS"
        Finals.UseVisualStyleBackColor = False
        ' 
        ' Formal
        ' 
        Formal.BackColor = SystemColors.ControlDark
        Formal.FlatAppearance.MouseDownBackColor = Color.Blue
        Formal.FlatAppearance.MouseOverBackColor = Color.RoyalBlue
        Formal.FlatStyle = FlatStyle.Flat
        Formal.Font = New Font("Century", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Formal.ForeColor = Color.DarkSlateGray
        Formal.Location = New Point(71, 184)
        Formal.Margin = New Padding(3, 2, 3, 2)
        Formal.Name = "Formal"
        Formal.Size = New Size(500, 67)
        Formal.TabIndex = 6
        Formal.Text = "FORMAL WEAR"
        Formal.UseVisualStyleBackColor = False
        ' 
        ' Shorts
        ' 
        Shorts.BackColor = SystemColors.ControlDark
        Shorts.FlatAppearance.MouseDownBackColor = Color.Green
        Shorts.FlatAppearance.MouseOverBackColor = Color.PaleGreen
        Shorts.FlatStyle = FlatStyle.Flat
        Shorts.Font = New Font("Century", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Shorts.ForeColor = Color.DarkSlateGray
        Shorts.Location = New Point(71, 99)
        Shorts.Margin = New Padding(3, 2, 3, 2)
        Shorts.Name = "Shorts"
        Shorts.Size = New Size(500, 67)
        Shorts.TabIndex = 5
        Shorts.Text = "SHORTS WEAR"
        Shorts.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.DarkCyan
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(judge)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(645, 55)
        Panel1.TabIndex = 7
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Red
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial Rounded MT Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(579, 3)
        Button1.Margin = New Padding(3, 2, 3, 2)
        Button1.Name = "Button1"
        Button1.Size = New Size(63, 48)
        Button1.TabIndex = 9
        Button1.Text = "X"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.crown
        PictureBox1.Location = New Point(12, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(53, 51)
        PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
        PictureBox1.TabIndex = 8
        PictureBox1.TabStop = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(105, 26)
        Label3.Name = "Label3"
        Label3.Size = New Size(41, 15)
        Label3.TabIndex = 7
        Label3.Text = "VMUF"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Lucida Bright", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(61, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(89, 18)
        Label1.TabIndex = 6
        Label1.Text = "PAGEANT"
        ' 
        ' judge
        ' 
        judge.AutoSize = True
        judge.Font = New Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        judge.Location = New Point(258, 21)
        judge.Name = "judge"
        judge.Size = New Size(54, 20)
        judge.TabIndex = 5
        judge.Text = "Judge"
        ' 
        ' Form14
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaption
        ClientSize = New Size(645, 420)
        Controls.Add(Panel2)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        Name = "Form14"
        Text = "Criteria"
        Panel2.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents School As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents judge As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Finals As Button
    Friend WithEvents Formal As Button
    Friend WithEvents Shorts As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
End Class
