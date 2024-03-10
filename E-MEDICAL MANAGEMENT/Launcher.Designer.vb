<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Launcher
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Launcher))
        Me.pbar = New CircularProgressBar.CircularProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbar
        '
        Me.pbar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner
        Me.pbar.AnimationSpeed = 500
        Me.pbar.BackColor = System.Drawing.Color.Transparent
        Me.pbar.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Bold)
        Me.pbar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pbar.InnerColor = System.Drawing.Color.Transparent
        Me.pbar.InnerMargin = 2
        Me.pbar.InnerWidth = -1
        Me.pbar.Location = New System.Drawing.Point(221, 229)
        Me.pbar.MarqueeAnimationSpeed = 2000
        Me.pbar.Name = "pbar"
        Me.pbar.OuterColor = System.Drawing.Color.White
        Me.pbar.OuterMargin = -25
        Me.pbar.OuterWidth = 26
        Me.pbar.ProgressColor = System.Drawing.Color.DarkBlue
        Me.pbar.ProgressWidth = 18
        Me.pbar.SecondaryFont = New System.Drawing.Font("Microsoft Sans Serif", 36.0!)
        Me.pbar.Size = New System.Drawing.Size(309, 295)
        Me.pbar.StartAngle = 270
        Me.pbar.Step = 5
        Me.pbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbar.SubscriptColor = System.Drawing.Color.Teal
        Me.pbar.SubscriptMargin = New System.Windows.Forms.Padding(10, -35, 0, 0)
        Me.pbar.SubscriptText = ".23"
        Me.pbar.SuperscriptColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.pbar.SuperscriptMargin = New System.Windows.Forms.Padding(10, 35, 0, 0)
        Me.pbar.SuperscriptText = ""
        Me.pbar.TabIndex = 1
        Me.pbar.TextMargin = New System.Windows.Forms.Padding(8, 8, 0, 0)
        Me.pbar.Value = 68
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.E_MEDICAL_MANAGEMENT.My.Resources.Resources.Launcher
        Me.PictureBox1.Location = New System.Drawing.Point(143, -14)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(506, 226)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Panel1.Location = New System.Drawing.Point(0, 544)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(815, 60)
        Me.Panel1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Stencil", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(100, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(639, 42)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "EMPOWERING HEALTHCARE DIGITALY"
        '
        'Launcher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.BackgroundImage = Global.E_MEDICAL_MANAGEMENT.My.Resources.Resources.stethoscope_840125_640
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(815, 604)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.pbar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Launcher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Launcher"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbar As CircularProgressBar.CircularProgressBar
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
End Class
