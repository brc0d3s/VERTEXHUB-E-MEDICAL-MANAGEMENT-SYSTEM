<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StartPage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StartPage))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.llSignUp = New System.Windows.Forms.LinkLabel()
        Me.GrpBx = New System.Windows.Forms.GroupBox()
        Me.cmbUserType = New System.Windows.Forms.ComboBox()
        Me.lblUserType = New System.Windows.Forms.Label()
        Me.lblForgotPassword = New System.Windows.Forms.LinkLabel()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GrpBx.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Location = New System.Drawing.Point(169, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(862, 29)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "WELCOME TO THE VERTEXHUB  E-MEDICAL MANAGEMENT SYSTEM"
        '
        'llSignUp
        '
        Me.llSignUp.AutoSize = True
        Me.llSignUp.BackColor = System.Drawing.Color.Transparent
        Me.llSignUp.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llSignUp.LinkColor = System.Drawing.Color.Yellow
        Me.llSignUp.Location = New System.Drawing.Point(506, 27)
        Me.llSignUp.Name = "llSignUp"
        Me.llSignUp.Size = New System.Drawing.Size(104, 25)
        Me.llSignUp.TabIndex = 8
        Me.llSignUp.TabStop = True
        Me.llSignUp.Text = "SIGN UP"
        '
        'GrpBx
        '
        Me.GrpBx.BackColor = System.Drawing.Color.Transparent
        Me.GrpBx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.GrpBx.Controls.Add(Me.cmbUserType)
        Me.GrpBx.Controls.Add(Me.lblUserType)
        Me.GrpBx.Controls.Add(Me.lblForgotPassword)
        Me.GrpBx.Controls.Add(Me.llSignUp)
        Me.GrpBx.Controls.Add(Me.btnLogin)
        Me.GrpBx.Controls.Add(Me.txtPassword)
        Me.GrpBx.Controls.Add(Me.txtUserID)
        Me.GrpBx.Controls.Add(Me.lblPassword)
        Me.GrpBx.Controls.Add(Me.lblID)
        Me.GrpBx.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpBx.ForeColor = System.Drawing.Color.IndianRed
        Me.GrpBx.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.GrpBx.Location = New System.Drawing.Point(214, 99)
        Me.GrpBx.Name = "GrpBx"
        Me.GrpBx.Size = New System.Drawing.Size(695, 511)
        Me.GrpBx.TabIndex = 9
        Me.GrpBx.TabStop = False
        Me.GrpBx.Text = "LOG IN"
        '
        'cmbUserType
        '
        Me.cmbUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUserType.FormattingEnabled = True
        Me.cmbUserType.Items.AddRange(New Object() {"USER", "ADMIN"})
        Me.cmbUserType.Location = New System.Drawing.Point(282, 72)
        Me.cmbUserType.Name = "cmbUserType"
        Me.cmbUserType.Size = New System.Drawing.Size(379, 33)
        Me.cmbUserType.TabIndex = 14
        '
        'lblUserType
        '
        Me.lblUserType.AutoSize = True
        Me.lblUserType.BackColor = System.Drawing.Color.Transparent
        Me.lblUserType.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserType.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblUserType.Location = New System.Drawing.Point(35, 72)
        Me.lblUserType.Name = "lblUserType"
        Me.lblUserType.Size = New System.Drawing.Size(188, 33)
        Me.lblUserType.TabIndex = 13
        Me.lblUserType.Text = "USER TYPE"
        '
        'lblForgotPassword
        '
        Me.lblForgotPassword.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblForgotPassword.AutoSize = True
        Me.lblForgotPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblForgotPassword.ForeColor = System.Drawing.Color.Lime
        Me.lblForgotPassword.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblForgotPassword.Location = New System.Drawing.Point(202, 412)
        Me.lblForgotPassword.Name = "lblForgotPassword"
        Me.lblForgotPassword.Size = New System.Drawing.Size(189, 25)
        Me.lblForgotPassword.TabIndex = 12
        Me.lblForgotPassword.TabStop = True
        Me.lblForgotPassword.Text = "Forgot Password"
        Me.lblForgotPassword.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.Color.Black
        Me.btnLogin.Location = New System.Drawing.Point(431, 392)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(179, 58)
        Me.btnLogin.TabIndex = 11
        Me.btnLogin.Text = "Log In"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(282, 283)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(379, 40)
        Me.txtPassword.TabIndex = 10
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'txtUserID
        '
        Me.txtUserID.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserID.Location = New System.Drawing.Point(282, 168)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(379, 40)
        Me.txtUserID.TabIndex = 9
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold)
        Me.lblPassword.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblPassword.Location = New System.Drawing.Point(35, 283)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(191, 33)
        Me.lblPassword.TabIndex = 8
        Me.lblPassword.Text = "PASSWORD"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.BackColor = System.Drawing.Color.Transparent
        Me.lblID.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblID.Location = New System.Drawing.Point(35, 171)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(139, 33)
        Me.lblID.TabIndex = 7
        Me.lblID.Text = "USER ID"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.E_MEDICAL_MANAGEMENT.My.Resources.Resources.Logo
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(118, 98)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'StartPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1071, 655)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GrpBx)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Name = "StartPage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "E-MEDICAL MANAGEMENT"
        Me.GrpBx.ResumeLayout(False)
        Me.GrpBx.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents llSignUp As LinkLabel
    Friend WithEvents lblForgotPassword As LinkLabel
    Friend WithEvents btnLogin As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUserID As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblID As Label
    Friend WithEvents GrpBx As GroupBox
    Friend WithEvents lblUserType As Label
    Friend WithEvents cmbUserType As ComboBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
