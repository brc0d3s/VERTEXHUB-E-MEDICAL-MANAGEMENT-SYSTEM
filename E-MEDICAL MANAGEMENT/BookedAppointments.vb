Imports Npgsql
Public Class BookedAppointments

    Private connection As New NpgsqlConnection(GetConnectionString())

    Private Sub BookedAppointments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblName1.Text = StartPage.userName
        RefreshAppointmentsDisplay()
    End Sub

    Public Sub RefreshAppointmentsDisplay()
        Try
            ' Clear existing columns
            DataGridViewAppointments.Columns.Clear()

            Dim sql As String = "SELECT booking_id, booking_date, service, doctor_or_center, consultation_date, address FROM bookings WHERE user_id = @userId AND consultation_date >= @today"
            Using cmd As New NpgsqlCommand(sql, connection)
                cmd.Parameters.AddWithValue("userId", StartPage.userID)
                cmd.Parameters.AddWithValue("today", DateTime.Today)
                Dim adapter As New NpgsqlDataAdapter(cmd)
                Dim dataTable As New DataTable()
                adapter.Fill(dataTable)

                If dataTable.Rows.Count = 0 Then
                    MessageBox.Show("You have no appointments booked.", "No Appointments", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                    UserHomePage.Show()
                Else
                    DataGridViewAppointments.DataSource = dataTable

                    ' Adjust column widths
                    DataGridViewAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None ' Disable auto-sizing
                    DataGridViewAppointments.Columns("booking_date").Width = 135 ' Set width for each column as needed
                    DataGridViewAppointments.Columns("service").Width = 165
                    DataGridViewAppointments.Columns("doctor_or_center").Width = 200
                    DataGridViewAppointments.Columns("consultation_date").Width = 135
                    DataGridViewAppointments.Columns("address").Width = 175

                    ' Add cancel button column
                    Dim cancelButtonColumn As New DataGridViewButtonColumn()
                    cancelButtonColumn.Text = "Cancel"
                    cancelButtonColumn.Name = "cancelButtonColumn"
                    cancelButtonColumn.UseColumnTextForButtonValue = True
                    cancelButtonColumn.DefaultCellStyle.ForeColor = Color.Red ' Set the button color to red
                    DataGridViewAppointments.Columns.Add(cancelButtonColumn)

                    ' Remove the header for the cancel button column
                    DataGridViewAppointments.Columns("cancelButtonColumn").HeaderText = ""
                End If
            End Using
        Catch ex As Exception
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
        Finally
            connection.Close()
        End Try
    End Sub



    Private Sub DataGridViewAppointments_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewAppointments.CellContentClick
        Try
            If e.ColumnIndex = DataGridViewAppointments.Columns("cancelButtonColumn").Index AndAlso e.RowIndex >= 0 Then
                Dim result As DialogResult = MessageBox.Show("Are you sure you want to cancel this appointment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    Dim bookingId As Integer = CInt(DataGridViewAppointments.Rows(e.RowIndex).Cells("booking_id").Value)

                    Try
                        Dim sql As String = "DELETE FROM bookings WHERE booking_id = @bookingId"
                        Using cmd As New NpgsqlCommand(sql, connection)
                            cmd.Parameters.AddWithValue("bookingId", bookingId)
                            connection.Open()
                            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                            If rowsAffected > 0 Then
                                MessageBox.Show("Appointment cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                ' Refresh the appointments display
                                RefreshAppointmentsDisplay()
                            Else
                                MessageBox.Show("Failed to cancel appointment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End Using
                    Catch ex As Exception
                        ' Log the error to console
                        Console.WriteLine("Error: " & ex.Message)
                        ' Display user-friendly error message
                        MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
                    End Try
                End If
            End If
        Catch ex As Exception
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        UserHomePage.Show()
    End Sub

    Private Sub llLogOut_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llLogOut.LinkClicked
        ' Log logout time
        LogLogoutTime()
        Me.Close()
        StartPage.Show()
    End Sub
End Class
