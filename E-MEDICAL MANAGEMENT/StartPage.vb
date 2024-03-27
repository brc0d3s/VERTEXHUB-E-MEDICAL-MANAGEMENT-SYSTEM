﻿Imports Npgsql

Public Class StartPage
    Public Property userName As String
    Public Property userID As String

    Dim LoginPasswordHash As String
    Dim connection As New NpgsqlConnection(GetConnectionString())

    Private Sub StartPage_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub cmbUserType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUserType.SelectedIndexChanged
        If cmbUserType.Text.ToString().ToUpper() = "ADMIN" Then
            lblID.Text = "ADMIN ID"
            llSignUp.Visible = False
            lblForgotPassword.Visible = False
            llHelp.Visible = False
        Else
            lblID.Text = "USER ID"
            llSignUp.Visible = True
            lblForgotPassword.Visible = True
            llHelp.Visible = True
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Check for internet connectivity
        If Not My.Computer.Network.IsAvailable Then
            MessageBox.Show("Please connect to the internet to use the system.", "No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check if category is selected
        If String.IsNullOrEmpty(cmbUserType.Text) Then
            MsgBox("Please select your category.", MsgBoxStyle.Exclamation)
            Return
        End If

        ' Check if the fields have been filled
        If String.IsNullOrEmpty(txtUserID.Text) OrElse String.IsNullOrEmpty(txtPassword.Text) Then
            MsgBox("Please fill in all the fields.", MsgBoxStyle.Exclamation)
            Return
        End If

        ' Check if the id is integer
        If Not IsInteger(txtUserID.Text) Then
            MsgBox("Please enter an integer value for ID.", MsgBoxStyle.Exclamation)
            Return
        End If

        ' Check if the id exists and details are correct
        If cmbUserType.Text.ToUpper() = "ADMIN" Then
            adminLogin()
        Else
            userLogin()
        End If
    End Sub

    ' Check if the id is integer
    Private Function IsInteger(input As String) As Boolean
        Dim result As Integer
        Return Integer.TryParse(input, result)
    End Function

    Private Sub adminLogin()
        ' Hash the Entered password before comparison
        LoginPasswordHash = PasswordUtility.HashPassword(txtPassword.Text)

        Try
            connection.Open()
            Dim command As New NpgsqlCommand("SELECT * FROM administrator WHERE UserId = @UserId AND Password = @Password", connection)
            command.Parameters.AddWithValue("@UserId", txtUserID.Text)
            command.Parameters.AddWithValue("@Password", LoginPasswordHash)
            Dim adapter As New NpgsqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            If table.Rows.Count() <= 0 Then
                MsgBox("Incorrect ADMIN ID or password.", MsgBoxStyle.Exclamation)
                txtPassword.Text = ""
                txtUserID.Text = ""
            Else
                userID = table.Rows(0)("UserId").ToString() ' Store the UserId in userID property
                userName = table.Rows(0)("Name").ToString() ' Store the  adminName 
                ' Log login time
                LogLoginTime()
                Me.Hide()
                AdministratorPage.Show()
                ' Clear input fields
                txtPassword.Text = ""
                txtUserID.Text = ""
                cmbUserType.SelectedIndex = -1
            End If
        Catch ex As Exception
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub userLogin()
        ' Hash the Entered password before comparison
        LoginPasswordHash = PasswordUtility.HashPassword(txtPassword.Text)

        Try
            connection.Open()
            Dim command As New NpgsqlCommand("SELECT * FROM SignUpPage WHERE UserId = @UserId AND Password = @Password", connection)
            command.Parameters.AddWithValue("@UserId", txtUserID.Text)
            command.Parameters.AddWithValue("@Password", LoginPasswordHash)
            Dim table As New DataTable()
            Dim reader As NpgsqlDataReader = command.ExecuteReader()
            table.Load(reader)

            If table.Rows.Count() <= 0 Then
                MsgBox("Incorrect USER ID or password.", MsgBoxStyle.Exclamation)
                txtPassword.Text = ""
                txtUserID.Text = ""
            Else
                userID = table.Rows(0)("UserId").ToString() ' Store the UserId in userID property
                userName = table.Rows(0)("Name").ToString() ' Store the UserName in userName property
                ' Log login time
                LogLoginTime()
                Me.Hide()
                UserHomePage.Show()
                ' Clear input fields
                txtPassword.Text = ""
                txtUserID.Text = ""
                cmbUserType.SelectedIndex = -1
            End If
        Catch ex As Exception
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub lblForgotPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblForgotPassword.LinkClicked
        ForgotPassword.Show()
    End Sub

    Private Sub llSignUp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llSignUp.LinkClicked
        SignUp.Show()
    End Sub

    Private Sub llHelp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llHelp.LinkClicked
        Help.Show()
    End Sub

    Private Sub btnEXIT_Click(sender As Object, e As EventArgs) Handles btnEXIT.Click
        Application.Exit()
    End Sub
End Class
