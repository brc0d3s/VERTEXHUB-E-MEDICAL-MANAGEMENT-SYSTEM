﻿Imports Npgsql

Public Class StartPage
    Public Property adminName As String
    Public Property userName As String
    Dim LoginPasswordHash As String
    Dim connection As New NpgsqlConnection(GetConnectionString())


    Private Sub cmbUserType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUserType.SelectedIndexChanged
        If cmbUserType.Text.ToString().ToUpper() = "ADMIN" Then
            llSignUp.Visible = False
            lblForgotPassword.Visible = False
        Else
            llSignUp.Visible = True
            lblForgotPassword.Visible = True
        End If
    End Sub


    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If cmbUserType.Text.ToString().ToUpper() = "ADMIN" Then
            adminLogin()
        Else
            userLogin()
        End If
    End Sub


    Private Sub adminLogin()

        'Hash the Entered password before comparison
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
                MsgBox("Incorrect username or password.")
                txtPassword.Text = ""
                txtUserID.Text = ""
            Else
                adminName = table.Rows(0)(1).ToString()
                Me.Hide()
                AdministratorPage.Show()
                ' Clear input fields
                txtPassword.Text = ""
                txtUserID.Text = ""
                cmbUserType.SelectedIndex = -1
            End If
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub userLogin()

        'Hash the Entered password before comparison
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
                MsgBox("Incorrect username or password.")
                txtPassword.Text = ""
                txtUserID.Text = ""
            Else
                userName = table.Rows(0)(1).ToString()
                Me.Hide()
                UserHomePage.Show()
                ' Clear input fields
                txtPassword.Text = ""
                txtUserID.Text = ""
                cmbUserType.SelectedIndex = -1
            End If
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
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

End Class
