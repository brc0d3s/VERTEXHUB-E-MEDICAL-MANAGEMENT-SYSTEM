Imports Npgsql

Public Class ForgotPassword
    Dim ResetPasswordHash As String
    Dim connection As New NpgsqlConnection(GetConnectionString())

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        Try
            connection.Open()
            If txtName.Text = "" Or txtPhone.Text = "" Or txtUserId.Text = "" Then
                MsgBox("Please enter all the fields", MsgBoxStyle.Exclamation)
                txtUserId.Text = ""
                txtPhone.Text = ""
                txtName.Text = ""
            Else
                Using command As New NpgsqlCommand("SELECT * FROM SignUpPage WHERE UserId=@UserId and Name=@Name and Phone=@Phone", connection)
                    command.Parameters.AddWithValue("@UserId", txtUserId.Text)
                    command.Parameters.AddWithValue("@Name", txtName.Text)
                    command.Parameters.AddWithValue("@Phone", txtPhone.Text)
                    Dim reader As NpgsqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        MsgBox("Verified")
                        Me.Height = 500
                        btnVerify.Visible = False
                        lblPassword.Visible = True
                        lblConfirmPassword.Visible = True
                        btnChange.Visible = True
                        txtConfirmPassword.Visible = True
                        txtPassword.Visible = True
                    Else
                        MsgBox("Please enter valid information", MsgBoxStyle.Exclamation)
                    End If
                End Using
            End If
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub ForgotPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = 368
        lblPassword.Visible = False
        lblConfirmPassword.Visible = False
        btnChange.Visible = False
        txtConfirmPassword.Visible = False
        txtPassword.Visible = False
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click

        'Hash Password before storing
        ResetPasswordHash = PasswordUtility.HashPassword(txtPassword.Text)
        Try
            connection.Open()
            If txtPassword.Text = "" Or txtConfirmPassword.Text = "" Then
                MsgBox("Please enter password", MsgBoxStyle.Exclamation)
            Else
                If txtPassword.Text = txtConfirmPassword.Text Then
                    Using cmd As New NpgsqlCommand("UPDATE SignUpPage SET Password = @Password WHERE UserId = @UserId and Name = @Name and Phone = @Phone", connection)
                        cmd.Parameters.AddWithValue("@Password", ResetPasswordHash)
                        cmd.Parameters.AddWithValue("@UserId", txtUserId.Text)
                        cmd.Parameters.AddWithValue("@Name", txtName.Text)
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                        If (i > 0) Then
                            MsgBox("Password has been changed")
                            Me.Close()
                        Else
                            MsgBox("No records updated. Please check your information.", MsgBoxStyle.Exclamation)
                            txtPassword.Text = ""
                            txtConfirmPassword.Text = ""
                        End If
                    End Using
                Else
                    MsgBox("Passwords do not match", MsgBoxStyle.Exclamation)
                End If
            End If
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub
End Class
