Public Class Launcher
    Private Sub Launcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            pbar.Increment(1)

            If pbar.Value = 100 Then
                Me.Hide()
                StartPage.Show()
                Timer1.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        End Try
    End Sub
End Class
