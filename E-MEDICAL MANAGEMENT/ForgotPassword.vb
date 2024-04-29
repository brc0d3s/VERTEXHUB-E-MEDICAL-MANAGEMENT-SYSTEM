Imports Npgsql

Public Class ForgotPassword
    Dim ResetPasswordHash As String
    Dim connection As New NpgsqlConnection(GetConnectionString())

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        Try
            ' Check for internet connectivity
            If Not My.Computer.Network.IsAvailable Then
                MessageBox.Show("Please connect to the internet to use the system.", "No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If


            If txtName.Text = "" Or txtPhone.Text = "" Or txtUserId.Text = "" Then
                MsgBox("Please fill in all the fields.", MsgBoxStyle.Exclamation)
                txtUserId.Text = ""
                txtPhone.Text = ""
                txtName.Text = ""
            Else
                connection.Open()
                Using command As New NpgsqlCommand("SELECT * FROM SignUpPage WHERE UserId=@UserId and Name=@Name and Phone=@Phone", connection)
                    command.Parameters.AddWithValue("@UserId", txtUserId.Text)
                    command.Parameters.AddWithValue("@Name", txtName.Text)
                    command.Parameters.AddWithValue("@Phone", txtPhone.Text)
                    Dim reader As NpgsqlDataReader = command.ExecuteReader()

                    If reader.Read() Then
                        MsgBox("Verified")
                        Me.Height = 500
                        btnVerify.Visible = False
                        btnClose.Visible = False
                        lblPassword.Visible = True
                        lblConfirmPassword.Visible = True
                        btnChange.Visible = True
                        txtConfirmPassword.Visible = True
                        txtPassword.Visible = True
                    Else
                        MsgBox("Please enter valid information", MsgBoxStyle.Exclamation)
                        connection.Close()
                    End If
                End Using
            End If
        Catch ex As Exception
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
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
            ElseIf Not IsValidPassword(txtPassword.Text) Then
                MsgBox("Password must be at least 8 characters long and contain a mixture of letters, numbers, and special characters.", MsgBoxStyle.Exclamation)
            Else
                If txtPassword.Text = txtConfirmPassword.Text Then
                    Using cmd As New NpgsqlCommand("UPDATE SignUpPage SET Password = @Password WHERE UserId = @UserId and Name = @Name and Phone = @Phone", connection)
                        cmd.Parameters.AddWithValue("@Password", ResetPasswordHash)
                        cmd.Parameters.AddWithValue("@UserId", txtUserId.Text)
                        cmd.Parameters.AddWithValue("@Name", txtName.Text)
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                        If (i > 0) Then
                            MsgBox("Password has been changed", MsgBoxStyle.Information)
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
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Function IsValidPassword(password As String) As Boolean
        ' Password must be at least 8 characters long and contain a mixture of letters, numbers, and special characters
        If password.Length < 8 Then
            Return False
        End If

        Dim hasLetter As Boolean = False
        Dim hasNumber As Boolean = False
        Dim hasSpecialChar As Boolean = False

        For Each c As Char In password
            If Char.IsLetter(c) Then
                hasLetter = True
            ElseIf Char.IsDigit(c) Then
                hasNumber = True
            ElseIf Not Char.IsLetterOrDigit(c) Then
                hasSpecialChar = True
            End If
        Next

        Return hasLetter AndAlso hasNumber AndAlso hasSpecialChar
    End Function

    Private Sub txtConfirmPassword_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmPassword.TextChanged
        If txtPassword.Text = txtConfirmPassword.Text Then
            txtMatch.Text = "Match"
            txtMatch.ForeColor = Color.Green

        Else
            txtMatch.Text = "Not match"
            txtMatch.ForeColor = Color.Red
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        StartPage.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        StartPage.Show()
    End Sub
End Class
