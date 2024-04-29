Imports Npgsql

Public Class AdministratorPage
    Public Property str1 As String = StartPage.userName.ToString()
    Public Property TName As String
    Dim connection As New NpgsqlConnection(GetConnectionString())

    Private lastTickTime As DateTime = DateTime.Now

    Private Sub AdministratorPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblName.Text = str1
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

    Private Sub llLogOut_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llLogOut.LinkClicked
        ' Log logout time
        LogLogoutTime()
        Me.Close()
        StartPage.Show()
    End Sub

    Private Sub llMedicalStore_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llMedicalStore.LinkClicked
        Try
            llPreventiveStore.Visible = True
            llGeneralStore.Visible = True
            llSpecializedStore.Visible = True
        Catch ex As Exception
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub llLaboratories_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llLaboratories.LinkClicked
        Try
            TName = "Laboratories"
            Dim cmd As New NpgsqlCommand("SELECT * FROM Laboratories", connection)
            Dim ad As New NpgsqlDataAdapter(cmd)
            Dim table As New DataTable
            ad.Fill(table)
            TableUpdate.dgvAdmin.DataSource = table
            TableUpdate.lbl1.Text = "TYPE"
            TableUpdate.ShowDialog()
            Me.Hide()
            TableUpdate.lblName.Text = str1
            llPreventiveStore.Visible = False
            llGeneralStore.Visible = False
            llSpecializedStore.Visible = False
            TableUpdate.lbl1.Text = "ID"
            TableUpdate.lbl2.Text = "TYPE"
            TableUpdate.lbl3.Text = "NAME"
            TableUpdate.lbl4.Text = "ADDRESS"
            TableUpdate.lbl5.Text = "PHONE"
            TableUpdate.lbl6.Text = "TIME"
            TableUpdate.lblTableName.Text = "LABORATORIES TABLE"
        Catch ex As Exception
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
        End Try
        If connection.State = ConnectionState.Open Then
            connection.Close()
        End If
    End Sub

    Private Sub llDiagnosis_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llDiagnosis.LinkClicked
        Try
            TName = "diagnosis"
            Dim cmd As New NpgsqlCommand("SELECT * FROM diagnosis", connection)
            Dim ad As New NpgsqlDataAdapter(cmd)
            Dim table As New DataTable
            ad.Fill(table)
            TableUpdate.dgvAdmin.DataSource = table
            TableUpdate.lbl1.Text = "TYPE"
            TableUpdate.ShowDialog()
            Me.Hide()
            TableUpdate.lblName.Text = str1
            llPreventiveStore.Visible = False
            llGeneralStore.Visible = False
            llSpecializedStore.Visible = False
            TableUpdate.lbl1.Text = "ID"
            TableUpdate.lbl2.Text = "TYPE"
            TableUpdate.lbl3.Text = "NAME"
            TableUpdate.lbl4.Text = "ADDRESS"
            TableUpdate.lbl5.Text = "PHONE"
            TableUpdate.lbl6.Text = "TIME"
            TableUpdate.lblTableName.Text = "DIAGNOSIS TABLE"
        Catch ex As Exception
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
        End Try
        If connection.State = ConnectionState.Open Then
            connection.Close()
        End If
    End Sub

    Private Sub llUsersDetails_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llUsersDetails.LinkClicked
        Try
            TName = "SignUpPage"
            Dim cmd As New NpgsqlCommand("SELECT * FROM SignUpPage", connection)
            Dim ad As New NpgsqlDataAdapter(cmd)
            Dim table As New DataTable
            ad.Fill(table)
            TableUpdate.dgvAdmin.DataSource = table
            TableUpdate.ShowDialog()
            Me.Hide()
            TableUpdate.lblName.Text = str1
            llPreventiveStore.Visible = False
            llGeneralStore.Visible = False
            llSpecializedStore.Visible = False
            TableUpdate.lbl1.Text = "USER ID"
            TableUpdate.lbl2.Text = "NAME"
            TableUpdate.lbl3.Text = "SEX"
            TableUpdate.lbl4.Text = "AGE"
            TableUpdate.lbl5.Text = "PHONE"
            TableUpdate.lbl6.Text = "PASSWORD"
            TableUpdate.txt6.UseSystemPasswordChar = True
            TableUpdate.lblTableName.Text = "USERS DETAILS"
        Catch ex As Exception
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
        End Try
        If connection.State = ConnectionState.Open Then
            connection.Close()
        End If
    End Sub

    Private Sub llAdministrators_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llAdministrators.LinkClicked
        Try
            TName = "administrator"
            Dim cmd As New NpgsqlCommand("SELECT * FROM administrator", connection)
            Dim ad As New NpgsqlDataAdapter(cmd)
            Dim table As New DataTable
            ad.Fill(table)
            TableUpdate.dgvAdmin.DataSource = table
            TableUpdate.ShowDialog()
            Me.Hide()
            TableUpdate.lblName.Text = str1
            llPreventiveStore.Visible = False
            llGeneralStore.Visible = False
            llSpecializedStore.Visible = False
            TableUpdate.lbl4.Visible = False
            TableUpdate.txt4.Visible = False
            TableUpdate.lbl5.Visible = False
            TableUpdate.txt5.Visible = False
            TableUpdate.lbl6.Visible = False
            TableUpdate.txt6.Visible = False
            TableUpdate.lbl1.Text = "ID"
            TableUpdate.lbl2.Text = "NAME"
            TableUpdate.lbl3.Text = "PASSWORD"
            TableUpdate.txt3.UseSystemPasswordChar = True
            TableUpdate.lblTableName.Text = "ADMINISTRATOR TABLE"
        Catch ex As Exception
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
        End Try
        If connection.State = ConnectionState.Open Then
            connection.Close()
        End If
    End Sub

    Private Sub llGeneralStore_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llGeneralStore.LinkClicked
        Try
            TName = "General"
            Dim cmd As New NpgsqlCommand("SELECT * FROM General", connection)
            Dim ad As New NpgsqlDataAdapter(cmd)
            Dim table As New DataTable
            ad.Fill(table)
            TableUpdate.dgvAdmin.DataSource = table
            TableUpdate.lblTableName.Text = "GENERAL STORE TABLE"
            TableUpdate.ShowDialog()
            Me.Hide()
            TableUpdate.lblName.Text = str1
            TableUpdate.lbl6.Visible = False
            TableUpdate.txt6.Visible = False
        Catch ex As Exception
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
        End Try
        If connection.State = ConnectionState.Open Then
            connection.Close()
        End If
    End Sub

    Private Sub llSpecializedStore_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llSpecializedStore.LinkClicked
        Try
            TName = "Specialized"
            Dim cmd As New NpgsqlCommand("SELECT * FROM Specialized", connection)
            Dim ad As New NpgsqlDataAdapter(cmd)
            Dim table As New DataTable
            ad.Fill(table)
            TableUpdate.dgvAdmin.DataSource = table
            TableUpdate.lblTableName.Text = "SPECIALIZED STORE TABLE"
            TableUpdate.ShowDialog()
            Me.Hide()
            TableUpdate.lblName.Text = str1
            TableUpdate.lbl6.Visible = False
            TableUpdate.txt6.Visible = False
        Catch ex As Exception
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
        End Try
        If connection.State = ConnectionState.Open Then
            connection.Close()
        End If
    End Sub

    Private Sub llPreventiveStore_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llPreventiveStore.LinkClicked
        Try
            TName = "Preventive"
            Dim cmd As New NpgsqlCommand("SELECT * FROM Preventive", connection)
            Dim ad As New NpgsqlDataAdapter(cmd)
            Dim table As New DataTable
            ad.Fill(table)
            TableUpdate.dgvAdmin.DataSource = table
            TableUpdate.lblTableName.Text = "PREVENTIVE STORE TABLE"
            TableUpdate.ShowDialog()
            Me.Hide()
            TableUpdate.lblName.Text = str1
            TableUpdate.lbl6.Visible = False
            TableUpdate.txt6.Visible = False
        Catch ex As Exception
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
        End Try
        If connection.State = ConnectionState.Open Then
            connection.Close()
        End If
    End Sub

    Private Sub llblBookings_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblBookings.LinkClicked
        Try
            TName = "bookings"
            Dim cmd As New NpgsqlCommand("SELECT * FROM bookings", connection)
            Dim ad As New NpgsqlDataAdapter(cmd)
            Dim table As New DataTable
            ad.Fill(table)
            TableUpdate.dgvAdmin.DataSource = table
            TableUpdate.lbl1.Text = "TYPE"
            TableUpdate.ShowDialog()
            Me.Hide()
            TableUpdate.lblName.Text = str1
            llPreventiveStore.Visible = False
            llGeneralStore.Visible = False
            llSpecializedStore.Visible = False
            TableUpdate.btnAddNew.Visible = False
            TableUpdate.lbl1.Text = "BK ID"
            TableUpdate.lbl2.Text = "USER ID"
            TableUpdate.lbl3.Text = "SERVICE"
            TableUpdate.lbl4.Text = "DOC NAME"
            TableUpdate.lbl5.Text = "CON. DATE"
            TableUpdate.lbl6.Text = "ADDRESS"
            TableUpdate.lblTableName.Text = "USER BOOKINGS TABLE"
        Catch ex As Exception
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
        End Try
        If connection.State = ConnectionState.Open Then
            connection.Close()
        End If
    End Sub

    Private Sub llblSystemLogs_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblSystemLogs.LinkClicked
        Try
            TName = "sys_log"
            Dim cmd As New NpgsqlCommand("SELECT * FROM sys_log", connection)
            Dim ad As New NpgsqlDataAdapter(cmd)
            Dim table As New DataTable
            ad.Fill(table)
            TableUpdate.dgvAdmin.DataSource = table
            TableUpdate.ShowDialog()
            Me.Hide()
            TableUpdate.lblName.Text = str1
            llPreventiveStore.Visible = False
            llGeneralStore.Visible = False
            llSpecializedStore.Visible = False
            TableUpdate.lbl2.Visible = False
            TableUpdate.txt2.Visible = False
            TableUpdate.lbl3.Visible = False
            TableUpdate.txt3.Visible = False
            TableUpdate.lbl4.Visible = False
            TableUpdate.txt4.Visible = False
            TableUpdate.lbl5.Visible = False
            TableUpdate.txt5.Visible = False
            TableUpdate.lbl6.Visible = False
            TableUpdate.txt6.Visible = False
            TableUpdate.btnAddNew.Visible = False
            TableUpdate.btnUpdate.Visible = False
            TableUpdate.lbl1.Text = "LOG ID"
            TableUpdate.lblTableName.Text = "SYSTEM LOGS"
        Catch ex As Exception
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
        End Try
        If connection.State = ConnectionState.Open Then
            connection.Close()
        End If
    End Sub
End Class
