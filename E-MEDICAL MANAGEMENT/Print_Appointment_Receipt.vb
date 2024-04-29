Imports System.IO

Public Class Print_Appointment_Receipt
    ' Define the default name for the PDF
    Dim pdfName As String = $"{StartPage.userName}_{DateTime.Now:yyyyMMdd}.pdf"

    ' Define the default file path
    Dim filePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), pdfName)


    Friend service, DocCenterName, consultDate, Address, Phone, Ohours As String
    'Dim simpleConsultDate As String = consultDate.ToString("dd/MM/yyyy")

    Private Sub Print_Appointment_Receipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPrint.BackColor = Color.WhiteSmoke
        txtPrint.Text = "                                                 VERTEXHUB E-MEDICAL                                "
        txtPrint.Text &= Chr(13) & "                                                    "
        txtPrint.Text &= Chr(13) & "                                                     "
        txtPrint.Text &= Chr(13) & "                                                  Medical Appointment Receipt"
        txtPrint.Text &= Chr(13) & "      ----------------------------------------------------------------------------------------------------------------"
        txtPrint.Text &= Chr(13) & "                                                                                    Issued On: " & DateTime.Now
        txtPrint.Text &= Chr(13) & "             NOT TRANSFERABLE" & Chr(13) & Chr(13)
        txtPrint.Text &= Chr(13) & Chr(13) & "   User ID. : " & StartPage.userID & "                                                                                    User Name: " & StartPage.userName
        txtPrint.Text &= Chr(13) & Chr(13) & "                                                                                                         "
        txtPrint.Text &= Chr(13) & Chr(13) & "   Consultation Date: " & consultDate
        txtPrint.Text &= Chr(13) & Chr(13) & "   Service : " & service
        txtPrint.Text &= Chr(13) & Chr(13) & "   Doctor/Facility Name : " & DocCenterName
        txtPrint.Text &= Chr(13) & Chr(13) & "   Doctor/Facility Address : " & Address
        txtPrint.Text &= Chr(13) & Chr(13) & "   Phone :" & Phone
        txtPrint.Text &= Chr(13) & Chr(13) & "   Operation Hours :" & Ohours
        txtPrint.Text &= Chr(13) & "------------------------------------------------------HAVE A GOOD DAY----------------------------------------------------"

        ' Save the PDF file
        SaveReceiptAsPDF(filePath, txtPrint.Text)
    End Sub

    Private Sub SaveReceiptAsPDF(filePath As String, receiptText As String)
        Try
            ' Write the receipt text to the PDF file
            File.WriteAllText(filePath, receiptText)
        Catch ex As Exception
            ' Handle any errors that may occur during file writing
            MessageBox.Show("Error occurred while saving PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        prndlgPrintReceipt.Document = prndocPrintReceipt
        Dim result As DialogResult = prndlgPrintReceipt.ShowDialog()
        If result = Windows.Forms.DialogResult.OK Then
            prndocPrintReceipt.Print()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        Dispaly.Show()
    End Sub

    Private Sub PrndocPrintReceipt_PrintPage(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs) Handles prndocPrintReceipt.PrintPage
        Try
            ' Draw the logo
            Dim logoImagePath As String = Path.Combine(Application.StartupPath, "Launcher.PNG")
            Dim logoImage As Image = Image.FromFile(logoImagePath)
            e.Graphics.DrawImage(logoImage, 145, 70) ' Adjust the coordinates as needed


            e.Graphics.DrawString(txtPrint.Text, New Font("Century Schoolbook", 10, FontStyle.Bold), Brushes.Black, 150, 125)
        Catch ex As Exception
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while printing your receipt. Please try again later.", MsgBoxStyle.Critical)
        End Try
    End Sub

End Class