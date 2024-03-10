Imports Npgsql
Imports System.Data

Public Class StartPage
    Public Property str As String
    Dim SignupPasswordHash As String
    Dim connection As New NpgsqlConnection(GetConnectionString())

    Private Sub llSignUp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llSignUp.LinkClicked
        SignUp.Show()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        'Hash the Entered password before comparison
        SignupPasswordHash = PasswordUtility.HashPassword(txtPassword.Text)

        Try
            connection.Open()
            Dim commandText As String = "SELECT * FROM SignUpPage WHERE UserId = @UserId AND Password = @Password"
            Dim command As New NpgsqlCommand(commandText, connection)
            command.Parameters.AddWithValue("@UserId", txtUser.Text)
            command.Parameters.AddWithValue("@Password", SignupPasswordHash)
            Dim table As New DataTable()
            Dim reader As NpgsqlDataReader = command.ExecuteReader()
            table.Load(reader)

            If table.Rows.Count() <= 0 Then
                MsgBox("Invalid Username or Password")
                txtPassword.Text = ""
                txtUser.Text = ""
            Else
                Me.Hide()
                UserHomePage.Show()
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


End Class
