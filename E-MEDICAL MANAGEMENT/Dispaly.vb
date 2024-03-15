Imports System.Drawing.Printing
Imports Npgsql

Public Class Dispaly
    Public Property i As Integer = 0
    Dim test As Integer = 0
    Dim general As New DataTable
    Private connection As New NpgsqlConnection(GetConnectionString())

    'Printing variables
    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Dim Longpaper As Integer

    Private Sub Dispaly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblName1.Text = StartPage.userName.ToString()
        dtpkConsult.Value = DateTime.Today
    End Sub

    Private Sub Dispaly_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Hide()
    End Sub
    Public Sub result(table As DataTable)
        Try
            txtName.Text = table.Rows(i)(1).ToString
            txtAddress.Text = table.Rows(i)(2).ToString
            txtPhone.Text = table.Rows(i)(3).ToString
            txtTime.Text = table.Rows(i)(4).ToString
            general = table
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        End Try

    End Sub
    Private Sub lstName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstName.SelectedIndexChanged
        Try
            i = lstName.SelectedIndex
            i = Math.Floor(i / 2)
            result(general)
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub llLogOut_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llLogOut.LinkClicked
        ' Log logout time
        LogLogoutTime()
        Me.Close()
        StartPage.Show()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub

    ' Print functionalities
    Private Sub PD_BeginPrint(sender As Object, e As Printing.PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 500, 700) ' Adjusted paper size
        PD.DefaultPageSettings = pagesetup
    End Sub

    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
        Dim f14 As New Font("Calibri", 14, FontStyle.Bold)

        Dim leftmargin As Integer = 50 ' Adjusted left margin

        ' Booking data
        Dim bookingDate As DateTime = DateTime.Now
        Dim service As String = grpDetails.Text
        Dim DocCenterName As String = txtName.Text
        Dim consultDate As Date = dtpkConsult.Value
        Dim Address As String = txtAddress.Text
        Dim Phone As String = txtPhone.Text
        Dim Ohours As String = txtTime.Text

        ' Define string formats for alignment
        Dim leftFormat As New StringFormat()
        leftFormat.Alignment = StringAlignment.Near

        ' Define spacing between lines
        Dim lineHeight As Integer = 20
        Dim startY As Integer = 50 ' Starting position for drawing

        ' Draw Header
        e.Graphics.DrawString("VertexHub E-Medical", f14, Brushes.RoyalBlue, leftmargin, startY)
        startY += lineHeight
        e.Graphics.DrawString("Medical Appointment Receipt", f14, Brushes.Black, leftmargin, startY)
        startY += lineHeight * 2 ' Add extra space after header

        ' Draw User Information
        e.Graphics.DrawString("User ID: " & StartPage.userID, f10b, Brushes.Black, leftmargin, startY)
        startY += lineHeight
        e.Graphics.DrawString("User Name: " & StartPage.userName, f10b, Brushes.Black, leftmargin, startY)
        startY += lineHeight * 2 ' Add extra space after user info

        ' Draw Booking Information
        e.Graphics.DrawString("Booking Date: " & bookingDate.ToString("dd/MM/yyyy"), f10b, Brushes.Black, leftmargin, startY)
        startY += lineHeight
        e.Graphics.DrawString("Consultation Date: " & consultDate.ToString("dd/MM/yyyy"), f10b, Brushes.Black, leftmargin, startY)
        startY += lineHeight
        e.Graphics.DrawString("Service: " & service, f10b, Brushes.Black, leftmargin, startY)
        startY += lineHeight
        e.Graphics.DrawString("Doctor/Facility Name: " & DocCenterName, f10b, Brushes.Black, leftmargin, startY)
        startY += lineHeight
        e.Graphics.DrawString("Doctor/Facility Address: " & Address, f10b, Brushes.Black, leftmargin, startY)
        startY += lineHeight
        e.Graphics.DrawString("Phone: " & Phone, f10b, Brushes.Black, leftmargin, startY)
        startY += lineHeight
        e.Graphics.DrawString("Operation Hours: " & Ohours, f10b, Brushes.Black, leftmargin, startY)
    End Sub


    Private Sub btnBook_Click(sender As Object, e As EventArgs) Handles btnBook.Click
        'Printing to be implemented after booking
        Try
            If ValidateConsultationDate() Then
                'Booking data
                Dim bookingDate As DateTime = DateTime.Now
                Dim service As String = grpDetails.Text
                Dim DocCenterName As String = txtName.Text
                Dim consultDate As Date = dtpkConsult.Value
                Dim Address As String = txtAddress.Text
                Dim Phone As String = txtPhone.Text
                Dim Ohours As String = txtTime.Text

                connection.Open()
                Using cmd As New NpgsqlCommand("INSERT INTO bookings(booking_date, user_id, user_name, service, doctor_or_center, consultation_date,  address, operation_hours, phone) VALUES(@bookingDate, @UserId, @Name, @service, @DocCenterName, @consultDate, @Address, @OperationHours, @Phone)", connection)
                    cmd.Parameters.AddWithValue("@bookingDate", bookingDate)
                    cmd.Parameters.AddWithValue("@UserId", StartPage.userID)
                    cmd.Parameters.AddWithValue("@Name", StartPage.userName)
                    cmd.Parameters.AddWithValue("@service", service)
                    cmd.Parameters.AddWithValue("@DocCenterName", DocCenterName)
                    cmd.Parameters.AddWithValue("@consultDate", consultDate)
                    cmd.Parameters.AddWithValue("@Address", Address)
                    cmd.Parameters.AddWithValue("@OperationHours", Ohours)
                    cmd.Parameters.AddWithValue("@Phone", Phone)

                    i = cmd.ExecuteNonQuery()
                End Using

                If (i > 0) Then
                    MsgBox("Service Successfully Booked! Please Wait Printing your Receipt")
                    PPD.Document = PD
                    PPD.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    'Consultation date setting
    Private Function ValidateConsultationDate() As Boolean
        If dtpkConsult.Value < DateTime.Today Then
            MessageBox.Show("Please select a date from today onwards.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpkConsult.Value = DateTime.Today ' Reset the value to today
            Return False
        Else
            Return True
        End If
    End Function
End Class