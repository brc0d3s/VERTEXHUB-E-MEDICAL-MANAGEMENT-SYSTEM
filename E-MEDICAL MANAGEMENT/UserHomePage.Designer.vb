<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserHomePage
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.llLogOut = New System.Windows.Forms.LinkLabel()
        Me.lblName = New System.Windows.Forms.Label()
        Me.btnMedicalStore = New System.Windows.Forms.Button()
        Me.btnLaboratories = New System.Windows.Forms.Button()
        Me.btnDiagnosis = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Location = New System.Drawing.Point(241, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(612, 39)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "VERTEXHUB  E-MEDICAL SYSTEM"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 116)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1078, 11)
        Me.Panel1.TabIndex = 8
        '
        'llLogOut
        '
        Me.llLogOut.AutoSize = True
        Me.llLogOut.BackColor = System.Drawing.Color.Transparent
        Me.llLogOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llLogOut.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llLogOut.LinkColor = System.Drawing.Color.Yellow
        Me.llLogOut.Location = New System.Drawing.Point(990, 158)
        Me.llLogOut.Name = "llLogOut"
        Me.llLogOut.Size = New System.Drawing.Size(73, 20)
        Me.llLogOut.TabIndex = 16
        Me.llLogOut.TabStop = True
        Me.llLogOut.Text = "Log Out"
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.Font = New System.Drawing.Font("Harrington", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.Lime
        Me.lblName.Location = New System.Drawing.Point(822, 70)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(241, 31)
        Me.lblName.TabIndex = 17
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnMedicalStore
        '
        Me.btnMedicalStore.BackgroundImage = Global.E_MEDICAL_MANAGEMENT.My.Resources.Resources.b_logo5
        Me.btnMedicalStore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMedicalStore.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMedicalStore.Location = New System.Drawing.Point(78, 449)
        Me.btnMedicalStore.Name = "btnMedicalStore"
        Me.btnMedicalStore.Size = New System.Drawing.Size(389, 181)
        Me.btnMedicalStore.TabIndex = 15
        Me.btnMedicalStore.UseVisualStyleBackColor = True
        '
        'btnLaboratories
        '
        Me.btnLaboratories.BackgroundImage = Global.E_MEDICAL_MANAGEMENT.My.Resources.Resources.vector_laboratory_chemical_medical_test_logo_icon_colorful_modern_design_bulbs_bottles_49926491__2_
        Me.btnLaboratories.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLaboratories.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLaboratories.Location = New System.Drawing.Point(593, 206)
        Me.btnLaboratories.Name = "btnLaboratories"
        Me.btnLaboratories.Size = New System.Drawing.Size(389, 181)
        Me.btnLaboratories.TabIndex = 14
        Me.btnLaboratories.UseVisualStyleBackColor = True
        '
        'btnDiagnosis
        '
        Me.btnDiagnosis.BackgroundImage = Global.E_MEDICAL_MANAGEMENT.My.Resources.Resources.diagnosis_microsoft_image
        Me.btnDiagnosis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDiagnosis.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDiagnosis.Location = New System.Drawing.Point(78, 206)
        Me.btnDiagnosis.Name = "btnDiagnosis"
        Me.btnDiagnosis.Size = New System.Drawing.Size(389, 183)
        Me.btnDiagnosis.TabIndex = 12
        Me.btnDiagnosis.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.E_MEDICAL_MANAGEMENT.My.Resources.Resources.Logo
        Me.PictureBox1.Location = New System.Drawing.Point(28, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(118, 98)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'UserHomePage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(1075, 659)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.llLogOut)
        Me.Controls.Add(Me.btnMedicalStore)
        Me.Controls.Add(Me.btnLaboratories)
        Me.Controls.Add(Me.btnDiagnosis)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Name = "UserHomePage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UserHomePage"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnDiagnosis As Button
    Friend WithEvents btnLaboratories As Button
    Friend WithEvents btnMedicalStore As Button
    Friend WithEvents llLogOut As LinkLabel
    Friend WithEvents lblName As Label
End Class
