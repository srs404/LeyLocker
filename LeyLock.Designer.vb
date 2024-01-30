<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LeyLock
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LeyLock))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.textanim = New System.Windows.Forms.Timer(Me.components)
        Me.title = New System.Windows.Forms.Label()
        Me.onbutton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TextBox1.Font = New System.Drawing.Font("Times New Roman", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Black
        Me.TextBox1.Location = New System.Drawing.Point(0, 491)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9760)
        Me.TextBox1.Size = New System.Drawing.Size(1040, 62)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBox1.Visible = False
        '
        'textanim
        '
        Me.textanim.Enabled = True
        Me.textanim.Interval = 200
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.BackColor = System.Drawing.Color.Transparent
        Me.title.Dock = System.Windows.Forms.DockStyle.Right
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.ForeColor = System.Drawing.Color.YellowGreen
        Me.title.Location = New System.Drawing.Point(1008, 0)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(32, 46)
        Me.title.TabIndex = 1
        Me.title.Text = " "
        '
        'onbutton
        '
        Me.onbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.onbutton.Location = New System.Drawing.Point(0, 0)
        Me.onbutton.Name = "onbutton"
        Me.onbutton.Size = New System.Drawing.Size(88, 43)
        Me.onbutton.TabIndex = 2
        Me.onbutton.Text = "Online"
        Me.onbutton.UseVisualStyleBackColor = True
        '
        'LeyLock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1040, 553)
        Me.ControlBox = False
        Me.Controls.Add(Me.onbutton)
        Me.Controls.Add(Me.title)
        Me.Controls.Add(Me.TextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LeyLock"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LeyLock"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents textanim As Timer
    Friend WithEvents title As Label
    Friend WithEvents onbutton As Button
End Class
