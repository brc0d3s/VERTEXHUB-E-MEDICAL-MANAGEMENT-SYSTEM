Imports Npgsql

Public Class Dispaly
    Public Property i As Integer = 0
    Dim test As Integer = 0
    Dim general As New DataTable
    Private connection As New NpgsqlConnection(GetConnectionString())

    Private Sub Dispaly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblName1.Text = StartPage.userName.ToString()
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

    Private Sub btnBook_Click(sender As Object, e As EventArgs) Handles btnBook.Click
        'Printing to be implemented after booking
        Try
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
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

End Class