Imports Npgsql

Public Class SignUp
    Dim sex As String
    Dim passwordHash As String

    Dim connection As New NpgsqlConnection(GetConnectionString())

    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        Dim i As Integer

        ' Hash the password before storing it in the database
        passwordHash = PasswordUtility.HashPassword(txtPassword.Text)

        If rbtnMale.Checked = True Then
            sex = "M"
        ElseIf rbtnFemale.Checked Then
            sex = "F"
        End If


        Try
            connection.Open()
            If Not AreTextBoxesFilled() Then
                MsgBox("Fill all the Information")
            Else
                Using cmd As New NpgsqlCommand("INSERT INTO SignUpPage(UserId, Name, Sex, Age, Phone, Password) VALUES(@UserId, @Name, @Sex, @Age, @Phone, @Password)", connection)
                    cmd.Parameters.AddWithValue("@UserId", txtUserId.Text)
                    cmd.Parameters.AddWithValue("@Name", txtName.Text)
                    cmd.Parameters.AddWithValue("@Sex", sex)
                    cmd.Parameters.AddWithValue("@Age", txtAge.Text)
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)
                    cmd.Parameters.AddWithValue("@Password", passwordHash)
                    i = cmd.ExecuteNonQuery()
                End Using
                If (i > 0) Then
                    MsgBox("Sign Up successful!!")
                    StartPage.Show()
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Function AreTextBoxesFilled() As Boolean
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox AndAlso String.IsNullOrWhiteSpace(DirectCast(ctrl, TextBox).Text) Then
                Return False
            End If
        Next
        Return True
    End Function
End Class
