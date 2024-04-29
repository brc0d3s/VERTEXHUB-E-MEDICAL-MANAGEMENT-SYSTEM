<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Print_Appointment_Receipt
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
        Me.txtPrint = New System.Windows.Forms.RichTextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.lblHealth = New System.Windows.Forms.Label()
        Me.prndocPrintReceipt = New System.Drawing.Printing.PrintDocument()
        Me.prndlgPrintReceipt = New System.Windows.Forms.PrintDialog()
        Me.SuspendLayout()
        '
        'txtPrint
        '
        Me.txtPrint.ForeColor = System.Drawing.Color.Black
        Me.txtPrint.Location = New System.Drawing.Point(81, 62)
        Me.txtPrint.Name = "txtPrint"
        Me.txtPrint.ReadOnly = True
        Me.txtPrint.Size = New System.Drawing.Size(582, 370)
        Me.txtPrint.TabIndex = 10
        Me.txtPrint.Text = ""
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnClose.Location = New System.Drawing.Point(473, 465)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(110, 43)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.Red
        Me.btnPrint.Location = New System.Drawing.Point(151, 465)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(110, 43)
        Me.btnPrint.TabIndex = 11
        Me.btnPrint.Text = "&Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'lblHealth
        '
        Me.lblHealth.AutoSize = True
        Me.lblHealth.BackColor = System.Drawing.Color.Transparent
        Me.lblHealth.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHealth.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblHealth.Location = New System.Drawing.Point(124, 17)
        Me.lblHealth.Name = "lblHealth"
        Me.lblHealth.Size = New System.Drawing.Size(477, 33)
        Me.lblHealth.TabIndex = 23
        Me.lblHealth.Text = "PRINT APPOINTMENT RECEIPT"
        '
        'prndocPrintReceipt
        '
        '
        'prndlgPrintReceipt
        '
        Me.prndlgPrintReceipt.Document = Me.prndocPrintReceipt
        Me.prndlgPrintReceipt.UseEXDialog = True
        '
        'Print_Appointment_Receipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(772, 535)
        Me.Controls.Add(Me.lblHealth)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.txtPrint)
        Me.Name = "Print_Appointment_Receipt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print_Appointment_Receipt"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtPrint As RichTextBox
    Friend WithEvents btnClose As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents lblHealth As Label
    Friend WithEvents prndocPrintReceipt As Printing.PrintDocument
    Friend WithEvents prndlgPrintReceipt As PrintDialog
End Class
