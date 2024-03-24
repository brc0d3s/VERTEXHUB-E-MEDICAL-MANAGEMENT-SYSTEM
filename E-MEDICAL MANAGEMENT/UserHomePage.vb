Imports Npgsql

Public Class UserHomePage
    Private connection As New NpgsqlConnection(GetConnectionString())

    Private lastTickTime As DateTime = DateTime.Now


    Private Sub UserHomePage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblName.Text = StartPage.userName.ToString()
        Timer1.Interval = 10 ' Adjust this value to control the smoothness of the animation
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim currentTime As DateTime = DateTime.Now
        Dim elapsedTime As TimeSpan = currentTime - lastTickTime
        Dim pixelsToMove As Integer = CInt(elapsedTime.TotalMilliseconds / 10) ' Adjust the division factor to control the speed

        ' Move the label horizontally by the calculated number of pixels
        Label1.Left -= pixelsToMove

        ' Check if the label has moved out of the form's bounds
        If Label1.Right < 0 Then
            ' If it has, reset its position to the right edge of the form
            Label1.Left = Me.ClientSize.Width
        End If

        ' Update the last tick time for the next iteration
        lastTickTime = currentTime
    End Sub

    Private Sub btnLaboratories_Click(sender As Object, e As EventArgs) Handles btnLaboratories.Click
        Me.Close()
        Laboratories.Show()
    End Sub

    Private Sub btnDiagnosis_Click(sender As Object, e As EventArgs) Handles btnDiagnosis.Click
        Me.Close()
        Diagnosis.Show()
    End Sub

    Private Sub btnMedicalStore_Click(sender As Object, e As EventArgs) Handles btnMedicalStore.Click
        Me.Close()
        MedicalStore.Show()
    End Sub

    Private Sub llLogOut_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llLogOut.LinkClicked
        ' Log logout time
        LogLogoutTime()
        Me.Close()
        StartPage.Show()
    End Sub

    Private Sub btnAppointments_Click(sender As Object, e As EventArgs) Handles btnAppointments.Click
        Try
            ' Check if there are any appointments available
            Dim sql As String = "SELECT COUNT(*) FROM bookings WHERE user_id = @userId AND consultation_date >= @today"
            Using cmd As New NpgsqlCommand(sql, connection)
                cmd.Parameters.AddWithValue("userId", StartPage.userID)
                cmd.Parameters.AddWithValue("today", DateTime.Today)
                connection.Open()
                Dim count As Integer = CInt(cmd.ExecuteScalar())
                If count > 0 Then
                    ' If appointments are available, close the UserHomePage form and open the BookedAppointments form
                    Me.Close()
                    BookedAppointments.Show()
                Else
                    ' If no appointments are available, show a message
                    MessageBox.Show("You have no appointments booked.", "No Appointments", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            ' Ensure the connection is properly closed
            connection.Close()
        End Try
    End Sub

End Class