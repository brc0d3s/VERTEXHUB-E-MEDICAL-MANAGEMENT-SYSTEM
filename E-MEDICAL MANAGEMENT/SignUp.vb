Imports Npgsql

Public Class SignUp
    Dim sex As String
    Dim passwordHash As String

    Dim connection As New NpgsqlConnection(GetConnectionString())

    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        ' Check if all details are filled
        If Not AreTextBoxesFilled() Then
            MsgBox("Fill all the Information", MsgBoxStyle.Exclamation)
            Return
        End If

        ' Hash the password before storing it in the database
        passwordHash = PasswordUtility.HashPassword(txtPassword.Text)

        If rbtnMale.Checked = True Then
            sex = "M"
        ElseIf rbtnFemale.Checked Then
            sex = "F"
        End If

        Try
            connection.Open() ' Open the connection here

            ' Check if user already exists
            If UserExists(txtUserId.Text) Then
                MsgBox("User ID already exists. Please Login to continue.", MsgBoxStyle.Exclamation)
                Return
            End If

            ' Check if password meets criteria
            If Not IsValidPassword(txtPassword.Text) Then
                MsgBox("Password must be at least 8 characters long and contain a mixture of letters, numbers, and special characters.", MsgBoxStyle.Exclamation)
                Return
            End If

            Using cmd As New NpgsqlCommand("INSERT INTO SignUpPage(UserId, Name, Sex, Age, Phone, Password) VALUES(@UserId, @Name, @Sex, @Age, @Phone, @Password)", connection)
                cmd.Parameters.AddWithValue("@UserId", txtUserId.Text)
                cmd.Parameters.AddWithValue("@Name", txtName.Text)
                cmd.Parameters.AddWithValue("@Sex", sex)
                cmd.Parameters.AddWithValue("@Age", txtAge.Text)
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)
                cmd.Parameters.AddWithValue("@Password", passwordHash)
                Dim i As Integer = cmd.ExecuteNonQuery()
                If (i > 0) Then
                    MsgBox("Sign Up successful!!", MsgBoxStyle.Information)
                    ' Clear textboxes and deselect radio buttons
                    ClearForm()
                    StartPage.Show()
                    Me.Close()
                End If
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub ClearForm()
        ' Clear textboxes
        txtUserId.Clear()
        txtName.Clear()
        txtAge.Clear()
        txtPhone.Clear()
        txtPassword.Clear()

        ' Deselect radio buttons
        rbtnMale.Checked = False
        rbtnFemale.Checked = False
    End Sub

    Private Function AreTextBoxesFilled() As Boolean
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox AndAlso String.IsNullOrWhiteSpace(DirectCast(ctrl, TextBox).Text) Then
                Return False
            End If
        Next
        Return True
    End Function

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

    Private Function UserExists(userId As String) As Boolean
        Using cmd As New NpgsqlCommand("SELECT COUNT(*) FROM SignUpPage WHERE UserId = @UserId", connection)
            cmd.Parameters.AddWithValue("@UserId", userId)
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return count > 0
        End Using
    End Function
End Class
