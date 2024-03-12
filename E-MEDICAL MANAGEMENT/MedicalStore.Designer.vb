<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MedicalStore
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
        Me.btnGeneral = New System.Windows.Forms.Button()
        Me.btnPreventive = New System.Windows.Forms.Button()
        Me.btnSpecialized = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.llGeneral = New System.Windows.Forms.LinkLabel()
        Me.llPreventive = New System.Windows.Forms.LinkLabel()
        Me.llSpecialized = New System.Windows.Forms.LinkLabel()
        Me.lblName = New System.Windows.Forms.Label()
        Me.llLogOut = New System.Windows.Forms.LinkLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblName1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGeneral
        '
        Me.btnGeneral.BackgroundImage = Global.E_MEDICAL_MANAGEMENT.My.Resources.Resources.GeneralMedicine
        Me.btnGeneral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGeneral.Location = New System.Drawing.Point(25, 176)
        Me.btnGeneral.Name = "btnGeneral"
        Me.btnGeneral.Size = New System.Drawing.Size(389, 181)
        Me.btnGeneral.TabIndex = 0
        Me.btnGeneral.UseVisualStyleBackColor = True
        '
        'btnPreventive
        '
        Me.btnPreventive.BackgroundImage = Global.E_MEDICAL_MANAGEMENT.My.Resources.Resources.PreventiveMedicine
        Me.btnPreventive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPreventive.Location = New System.Drawing.Point(653, 176)
        Me.btnPreventive.Name = "btnPreventive"
        Me.btnPreventive.Size = New System.Drawing.Size(389, 181)
        Me.btnPreventive.TabIndex = 1
        Me.btnPreventive.UseVisualStyleBackColor = True
        '
        'btnSpecialized
        '
        Me.btnSpecialized.BackgroundImage = Global.E_MEDICAL_MANAGEMENT.My.Resources.Resources.SpecializedMedicine
        Me.btnSpecialized.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSpecialized.Location = New System.Drawing.Point(322, 409)
        Me.btnSpecialized.Name = "btnSpecialized"
        Me.btnSpecialized.Size = New System.Drawing.Size(389, 181)
        Me.btnSpecialized.TabIndex = 2
        Me.btnSpecialized.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Red
        Me.btnBack.Font = New System.Drawing.Font("Niagara Engraved", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.Location = New System.Drawing.Point(25, 106)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(93, 37)
        Me.btnBack.TabIndex = 6
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Mistral", 36.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(361, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(307, 57)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "MEDICAL STORES"
        '
        'llGeneral
        '
        Me.llGeneral.AutoSize = True
        Me.llGeneral.BackColor = System.Drawing.Color.Transparent
        Me.llGeneral.Font = New System.Drawing.Font("Segoe Script", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llGeneral.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llGeneral.LinkColor = System.Drawing.Color.Yellow
        Me.llGeneral.Location = New System.Drawing.Point(90, 360)
        Me.llGeneral.Name = "llGeneral"
        Me.llGeneral.Size = New System.Drawing.Size(201, 53)
        Me.llGeneral.TabIndex = 8
        Me.llGeneral.TabStop = True
        Me.llGeneral.Text = "GENERAL"
        '
        'llPreventive
        '
        Me.llPreventive.AutoSize = True
        Me.llPreventive.BackColor = System.Drawing.Color.Transparent
        Me.llPreventive.Font = New System.Drawing.Font("Segoe Script", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llPreventive.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llPreventive.LinkColor = System.Drawing.Color.Yellow
        Me.llPreventive.Location = New System.Drawing.Point(737, 360)
        Me.llPreventive.Name = "llPreventive"
        Me.llPreventive.Size = New System.Drawing.Size(256, 53)
        Me.llPreventive.TabIndex = 9
        Me.llPreventive.TabStop = True
        Me.llPreventive.Text = "PREVENTIVE"
        '
        'llSpecialized
        '
        Me.llSpecialized.AutoSize = True
        Me.llSpecialized.BackColor = System.Drawing.Color.Transparent
        Me.llSpecialized.Font = New System.Drawing.Font("Segoe Script", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llSpecialized.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llSpecialized.LinkColor = System.Drawing.Color.Yellow
        Me.llSpecialized.Location = New System.Drawing.Point(395, 593)
        Me.llSpecialized.Name = "llSpecialized"
        Me.llSpecialized.Size = New System.Drawing.Size(263, 53)
        Me.llSpecialized.TabIndex = 10
        Me.llSpecialized.TabStop = True
        Me.llSpecialized.Text = "SPECIALIZED"
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.Font = New System.Drawing.Font("Harrington", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.Indigo
        Me.lblName.Location = New System.Drawing.Point(1098, 64)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(252, 31)
        Me.lblName.TabIndex = 11
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'llLogOut
        '
        Me.llLogOut.AutoSize = True
        Me.llLogOut.BackColor = System.Drawing.Color.Transparent
        Me.llLogOut.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llLogOut.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llLogOut.LinkColor = System.Drawing.Color.Lime
        Me.llLogOut.Location = New System.Drawing.Point(959, 106)
        Me.llLogOut.Name = "llLogOut"
        Me.llLogOut.Size = New System.Drawing.Size(83, 21)
        Me.llLogOut.TabIndex = 16
        Me.llLogOut.TabStop = True
        Me.llLogOut.Text = "Log Out"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel1.Controls.Add(Me.lblName1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1071, 103)
        Me.Panel1.TabIndex = 17
        '
        'lblName1
        '
        Me.lblName1.BackColor = System.Drawing.Color.Transparent
        Me.lblName1.Font = New System.Drawing.Font("Harrington", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblName1.Location = New System.Drawing.Point(816, 69)
        Me.lblName1.Name = "lblName1"
        Me.lblName1.Size = New System.Drawing.Size(226, 31)
        Me.lblName1.TabIndex = 21
        Me.lblName1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.E_MEDICAL_MANAGEMENT.My.Resources.Resources.Logo
        Me.PictureBox1.Location = New System.Drawing.Point(12, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(118, 98)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Location = New System.Drawing.Point(226, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(612, 39)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "VERTEXHUB  E-MEDICAL SYSTEM"
        '
        'MedicalStore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.E_MEDICAL_MANAGEMENT.My.Resources.Resources.I_Pharmacy_by_Marketing_Jazz_Sevilla_Spain
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1071, 655)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.llLogOut)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.llSpecialized)
        Me.Controls.Add(Me.llPreventive)
        Me.Controls.Add(Me.llGeneral)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnSpecialized)
        Me.Controls.Add(Me.btnPreventive)
        Me.Controls.Add(Me.btnGeneral)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "MedicalStore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MEDICAL STORE"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnGeneral As Button
    Friend WithEvents btnPreventive As Button
    Friend WithEvents btnSpecialized As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents llGeneral As LinkLabel
    Friend WithEvents llPreventive As LinkLabel
    Friend WithEvents llSpecialized As LinkLabel
    Friend WithEvents lblName As Label
    Friend WithEvents llLogOut As LinkLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblName1 As Label
End Class
