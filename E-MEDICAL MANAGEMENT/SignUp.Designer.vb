<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SignUp))
        Me.btnSignUp = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtAge = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtUserId = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rbtnMale = New System.Windows.Forms.RadioButton()
        Me.rbtnFemale = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtConfirm = New System.Windows.Forms.TextBox()
        Me.txtMatch = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnSignUp
        '
        Me.btnSignUp.BackColor = System.Drawing.Color.White
        Me.btnSignUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSignUp.Location = New System.Drawing.Point(266, 529)
        Me.btnSignUp.Name = "btnSignUp"
        Me.btnSignUp.Size = New System.Drawing.Size(138, 43)
        Me.btnSignUp.TabIndex = 25
        Me.btnSignUp.Text = "SIGN UP"
        Me.btnSignUp.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(258, 412)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(306, 31)
        Me.txtPassword.TabIndex = 24
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'txtPhone
        '
        Me.txtPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhone.Location = New System.Drawing.Point(258, 351)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(306, 31)
        Me.txtPhone.TabIndex = 23
        '
        'txtAge
        '
        Me.txtAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAge.Location = New System.Drawing.Point(258, 283)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Size = New System.Drawing.Size(60, 31)
        Me.txtAge.TabIndex = 22
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(258, 147)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(306, 31)
        Me.txtName.TabIndex = 20
        '
        'txtUserId
        '
        Me.txtUserId.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserId.Location = New System.Drawing.Point(258, 81)
        Me.txtUserId.Name = "txtUserId"
        Me.txtUserId.Size = New System.Drawing.Size(306, 31)
        Me.txtUserId.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(19, 409)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(180, 31)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "PASSWORD"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(27, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 31)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "USER ID"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(30, 280)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 31)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "AGE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(31, 211)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 31)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "SEX"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(27, 348)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 31)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "PHONE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(33, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 31)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "NAME"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label7.Location = New System.Drawing.Point(84, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(478, 42)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "VERTEXHUB E-MEDICAL"
        '
        'rbtnMale
        '
        Me.rbtnMale.AutoSize = True
        Me.rbtnMale.Location = New System.Drawing.Point(258, 215)
        Me.rbtnMale.Name = "rbtnMale"
        Me.rbtnMale.Size = New System.Drawing.Size(81, 29)
        Me.rbtnMale.TabIndex = 27
        Me.rbtnMale.TabStop = True
        Me.rbtnMale.Text = "Male"
        Me.rbtnMale.UseVisualStyleBackColor = True
        '
        'rbtnFemale
        '
        Me.rbtnFemale.AutoSize = True
        Me.rbtnFemale.Location = New System.Drawing.Point(438, 215)
        Me.rbtnFemale.Name = "rbtnFemale"
        Me.rbtnFemale.Size = New System.Drawing.Size(107, 29)
        Me.rbtnFemale.TabIndex = 28
        Me.rbtnFemale.TabStop = True
        Me.rbtnFemale.Text = "Female"
        Me.rbtnFemale.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(12, 472)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(323, 31)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "CONFIRM PASSWORD"
        '
        'txtConfirm
        '
        Me.txtConfirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirm.Location = New System.Drawing.Point(354, 472)
        Me.txtConfirm.Name = "txtConfirm"
        Me.txtConfirm.Size = New System.Drawing.Size(306, 31)
        Me.txtConfirm.TabIndex = 30
        Me.txtConfirm.UseSystemPasswordChar = True
        '
        'txtMatch
        '
        Me.txtMatch.BackColor = System.Drawing.SystemColors.ControlDark
        Me.txtMatch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMatch.Location = New System.Drawing.Point(680, 472)
        Me.txtMatch.Name = "txtMatch"
        Me.txtMatch.ReadOnly = True
        Me.txtMatch.Size = New System.Drawing.Size(157, 24)
        Me.txtMatch.TabIndex = 31
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnClose.Location = New System.Drawing.Point(517, 521)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(110, 51)
        Me.btnClose.TabIndex = 32
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'SignUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(849, 585)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtMatch)
        Me.Controls.Add(Me.txtConfirm)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.rbtnFemale)
        Me.Controls.Add(Me.rbtnMale)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnSignUp)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.txtAge)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtUserId)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Name = "SignUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SIGN UP"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSignUp As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents txtAge As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtUserId As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents rbtnMale As RadioButton
    Friend WithEvents rbtnFemale As RadioButton
    Friend WithEvents Label8 As Label
    Friend WithEvents txtConfirm As TextBox
    Friend WithEvents txtMatch As TextBox
    Friend WithEvents btnClose As Button
End Class
