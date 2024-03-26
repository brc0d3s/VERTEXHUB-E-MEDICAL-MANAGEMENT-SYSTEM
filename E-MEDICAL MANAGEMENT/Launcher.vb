Public Class Launcher
    Dim totalSteps As Integer = 100 ' Total steps for completion
    Dim currentStep As Integer = 0 ' Current step count

    Private Sub Launcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Panel2.Width += CInt((Panel1.Width / totalSteps) / 2) ' Increment panel width by half of the original increment
            currentStep += 1 ' Increment current step count
            currentStep = Math.Min(currentStep, totalSteps) ' Ensure currentStep doesn't exceed totalSteps
            Dim percentage As Integer = CInt((currentStep / totalSteps) * 100) ' Calculate percentage
            If percentage = 100 Then
                Label2.Text = "Launching..."
            Else
                Label2.Text = "Loading... " & percentage.ToString() & "%" ' Update label with percentage
            End If

            If Panel2.Width >= Panel1.Width Then
                Timer1.Stop()
                StartPage.Show()
                Me.Hide()
                Timer1.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        End Try
    End Sub
End Class
