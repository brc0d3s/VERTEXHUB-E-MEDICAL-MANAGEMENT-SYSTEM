<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdministratorPage
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdministratorPage))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.llLogOut = New System.Windows.Forms.LinkLabel()
        Me.lblName = New System.Windows.Forms.Label()
        Me.llMedicalStore = New System.Windows.Forms.LinkLabel()
        Me.llGeneralStore = New System.Windows.Forms.LinkLabel()
        Me.llSpecializedStore = New System.Windows.Forms.LinkLabel()
        Me.llPreventiveStore = New System.Windows.Forms.LinkLabel()
        Me.llLaboratories = New System.Windows.Forms.LinkLabel()
        Me.llDiagnosis = New System.Windows.Forms.LinkLabel()
        Me.llUsersDetails = New System.Windows.Forms.LinkLabel()
        Me.llAdministrators = New System.Windows.Forms.LinkLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.llblSystemLogs = New System.Windows.Forms.LinkLabel()
        Me.llblBookings = New System.Windows.Forms.LinkLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Mistral", 48.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(313, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(317, 76)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "ADMIN PAGE"
        '
        'llLogOut
        '
        Me.llLogOut.AutoSize = True
        Me.llLogOut.BackColor = System.Drawing.Color.Transparent
        Me.llLogOut.Font = New System.Drawing.Font("Lucida Calligraphy", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llLogOut.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llLogOut.LinkColor = System.Drawing.Color.Yellow
        Me.llLogOut.Location = New System.Drawing.Point(980, 19)
        Me.llLogOut.Name = "llLogOut"
        Me.llLogOut.Size = New System.Drawing.Size(83, 21)
        Me.llLogOut.TabIndex = 16
        Me.llLogOut.TabStop = True
        Me.llLogOut.Text = "Log Out"
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.Font = New System.Drawing.Font("Harrington", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.Lime
        Me.lblName.Location = New System.Drawing.Point(811, 70)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(252, 31)
        Me.lblName.TabIndex = 15
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'llMedicalStore
        '
        Me.llMedicalStore.AutoSize = True
        Me.llMedicalStore.BackColor = System.Drawing.Color.Transparent
        Me.llMedicalStore.Font = New System.Drawing.Font("Monotype Corsiva", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llMedicalStore.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llMedicalStore.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.llMedicalStore.Location = New System.Drawing.Point(12, 219)
        Me.llMedicalStore.Name = "llMedicalStore"
        Me.llMedicalStore.Size = New System.Drawing.Size(301, 45)
        Me.llMedicalStore.TabIndex = 18
        Me.llMedicalStore.TabStop = True
        Me.llMedicalStore.Text = "MEDICAL STORE"
        '
        'llGeneralStore
        '
        Me.llGeneralStore.AutoSize = True
        Me.llGeneralStore.BackColor = System.Drawing.Color.Transparent
        Me.llGeneralStore.Font = New System.Drawing.Font("Monotype Corsiva", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llGeneralStore.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llGeneralStore.LinkColor = System.Drawing.Color.Gold
        Me.llGeneralStore.Location = New System.Drawing.Point(27, 264)
        Me.llGeneralStore.Name = "llGeneralStore"
        Me.llGeneralStore.Size = New System.Drawing.Size(305, 45)
        Me.llGeneralStore.TabIndex = 19
        Me.llGeneralStore.TabStop = True
        Me.llGeneralStore.Text = "GENERAL STORE"
        '
        'llSpecializedStore
        '
        Me.llSpecializedStore.AutoSize = True
        Me.llSpecializedStore.BackColor = System.Drawing.Color.Transparent
        Me.llSpecializedStore.Font = New System.Drawing.Font("Monotype Corsiva", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llSpecializedStore.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llSpecializedStore.LinkColor = System.Drawing.Color.Gold
        Me.llSpecializedStore.Location = New System.Drawing.Point(27, 322)
        Me.llSpecializedStore.Name = "llSpecializedStore"
        Me.llSpecializedStore.Size = New System.Drawing.Size(371, 45)
        Me.llSpecializedStore.TabIndex = 20
        Me.llSpecializedStore.TabStop = True
        Me.llSpecializedStore.Text = "SPECIALIZED STORE"
        '
        'llPreventiveStore
        '
        Me.llPreventiveStore.AutoSize = True
        Me.llPreventiveStore.BackColor = System.Drawing.Color.Transparent
        Me.llPreventiveStore.Font = New System.Drawing.Font("Monotype Corsiva", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llPreventiveStore.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llPreventiveStore.LinkColor = System.Drawing.Color.Gold
        Me.llPreventiveStore.Location = New System.Drawing.Point(27, 380)
        Me.llPreventiveStore.Name = "llPreventiveStore"
        Me.llPreventiveStore.Size = New System.Drawing.Size(365, 45)
        Me.llPreventiveStore.TabIndex = 19
        Me.llPreventiveStore.TabStop = True
        Me.llPreventiveStore.Text = "PREVENTIVE STORE"
        '
        'llLaboratories
        '
        Me.llLaboratories.AutoSize = True
        Me.llLaboratories.BackColor = System.Drawing.Color.Transparent
        Me.llLaboratories.Font = New System.Drawing.Font("Monotype Corsiva", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llLaboratories.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llLaboratories.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.llLaboratories.Location = New System.Drawing.Point(12, 572)
        Me.llLaboratories.Name = "llLaboratories"
        Me.llLaboratories.Size = New System.Drawing.Size(282, 45)
        Me.llLaboratories.TabIndex = 19
        Me.llLaboratories.TabStop = True
        Me.llLaboratories.Text = "LABORATORIES"
        '
        'llDiagnosis
        '
        Me.llDiagnosis.AutoSize = True
        Me.llDiagnosis.BackColor = System.Drawing.Color.Transparent
        Me.llDiagnosis.Font = New System.Drawing.Font("Monotype Corsiva", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llDiagnosis.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llDiagnosis.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.llDiagnosis.Location = New System.Drawing.Point(12, 466)
        Me.llDiagnosis.Name = "llDiagnosis"
        Me.llDiagnosis.Size = New System.Drawing.Size(211, 45)
        Me.llDiagnosis.TabIndex = 21
        Me.llDiagnosis.TabStop = True
        Me.llDiagnosis.Text = "DIAGNOSIS"
        '
        'llUsersDetails
        '
        Me.llUsersDetails.AutoSize = True
        Me.llUsersDetails.BackColor = System.Drawing.Color.Transparent
        Me.llUsersDetails.Font = New System.Drawing.Font("Monotype Corsiva", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llUsersDetails.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llUsersDetails.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.llUsersDetails.Location = New System.Drawing.Point(754, 466)
        Me.llUsersDetails.Name = "llUsersDetails"
        Me.llUsersDetails.Size = New System.Drawing.Size(290, 45)
        Me.llUsersDetails.TabIndex = 22
        Me.llUsersDetails.TabStop = True
        Me.llUsersDetails.Text = "USERS DETAILS"
        '
        'llAdministrators
        '
        Me.llAdministrators.AutoSize = True
        Me.llAdministrators.BackColor = System.Drawing.Color.Transparent
        Me.llAdministrators.Font = New System.Drawing.Font("Monotype Corsiva", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llAdministrators.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llAdministrators.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.llAdministrators.Location = New System.Drawing.Point(754, 572)
        Me.llAdministrators.Name = "llAdministrators"
        Me.llAdministrators.Size = New System.Drawing.Size(329, 45)
        Me.llAdministrators.TabIndex = 23
        Me.llAdministrators.TabStop = True
        Me.llAdministrators.Text = "ADMINISTRATORS"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(-4, 113)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1078, 11)
        Me.Panel1.TabIndex = 39
        '
        'llblSystemLogs
        '
        Me.llblSystemLogs.AutoSize = True
        Me.llblSystemLogs.BackColor = System.Drawing.Color.Transparent
        Me.llblSystemLogs.Font = New System.Drawing.Font("Monotype Corsiva", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblSystemLogs.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llblSystemLogs.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.llblSystemLogs.Location = New System.Drawing.Point(754, 344)
        Me.llblSystemLogs.Name = "llblSystemLogs"
        Me.llblSystemLogs.Size = New System.Drawing.Size(250, 45)
        Me.llblSystemLogs.TabIndex = 40
        Me.llblSystemLogs.TabStop = True
        Me.llblSystemLogs.Text = "SYSTEM LOGS"
        '
        'llblBookings
        '
        Me.llblBookings.AutoSize = True
        Me.llblBookings.BackColor = System.Drawing.Color.Transparent
        Me.llblBookings.Font = New System.Drawing.Font("Monotype Corsiva", 27.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblBookings.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llblBookings.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.llblBookings.Location = New System.Drawing.Point(754, 219)
        Me.llblBookings.Name = "llblBookings"
        Me.llblBookings.Size = New System.Drawing.Size(198, 45)
        Me.llblBookings.TabIndex = 41
        Me.llblBookings.TabStop = True
        Me.llblBookings.Text = "BOOKINGS"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Location = New System.Drawing.Point(-4, 171)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1078, 11)
        Me.Panel2.TabIndex = 42
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Stencil", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Label1.Location = New System.Drawing.Point(51, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(993, 42)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "With great privileges comes great responsibilities"
        '
        'Timer1
        '
        '
        'AdministratorPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1075, 659)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.llblBookings)
        Me.Controls.Add(Me.llblSystemLogs)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.llAdministrators)
        Me.Controls.Add(Me.llUsersDetails)
        Me.Controls.Add(Me.llDiagnosis)
        Me.Controls.Add(Me.llLaboratories)
        Me.Controls.Add(Me.llPreventiveStore)
        Me.Controls.Add(Me.llSpecializedStore)
        Me.Controls.Add(Me.llGeneralStore)
        Me.Controls.Add(Me.llMedicalStore)
        Me.Controls.Add(Me.llLogOut)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.Label3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AdministratorPage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADMINISTRATOR"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents llLogOut As LinkLabel
    Friend WithEvents lblName As Label
    Friend WithEvents llMedicalStore As LinkLabel
    Friend WithEvents llGeneralStore As LinkLabel
    Friend WithEvents llSpecializedStore As LinkLabel
    Friend WithEvents llPreventiveStore As LinkLabel
    Friend WithEvents llLaboratories As LinkLabel
    Friend WithEvents llDiagnosis As LinkLabel
    Friend WithEvents llUsersDetails As LinkLabel
    Friend WithEvents llAdministrators As LinkLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents llblSystemLogs As LinkLabel
    Friend WithEvents llblBookings As LinkLabel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
End Class
