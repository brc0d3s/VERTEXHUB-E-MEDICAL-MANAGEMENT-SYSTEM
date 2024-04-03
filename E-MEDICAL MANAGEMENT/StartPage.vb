Imports Npgsql

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

    Private Sub pictEXIT_Click(sender As Object, e As EventArgs) Handles pictEXIT.Click
        Application.Exit()
    End Sub

    Private Sub StartPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set button properties
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.FlatAppearance.BorderSize = 1
        btnLogin.FlatAppearance.BorderColor = Color.RoyalBlue ' Border color set to royal blue

        ' Add code for button shape customization here
        Dim radius As Integer = 20 ' Adjust the radius for desired roundness
        Dim path As New Drawing2D.GraphicsPath()
        path.AddArc(New Rectangle(0, 0, radius * 2, radius * 2), 180, 90)
        path.AddLine(radius, 0, btnLogin.Width - radius, 0)
        path.AddArc(New Rectangle(btnLogin.Width - 2 * radius, 0, radius * 2, radius * 2), -90, 90)
        path.AddLine(btnLogin.Width, radius, btnLogin.Width, btnLogin.Height - radius)
        path.AddArc(New Rectangle(btnLogin.Width - 2 * radius, btnLogin.Height - 2 * radius, radius * 2, radius * 2), 0, 90)
        path.AddLine(btnLogin.Width - radius, btnLogin.Height, radius, btnLogin.Height)
        path.AddArc(New Rectangle(0, btnLogin.Height - 2 * radius, radius * 2, radius * 2), 90, 90)
        path.AddLine(0, btnLogin.Height - radius, 0, radius)
        btnLogin.Region = New Region(path)

        ' Add event handlers for smooth color transitions
        AddHandler btnLogin.MouseEnter, AddressOf btnLogin_MouseEnter
        AddHandler btnLogin.MouseLeave, AddressOf btnLogin_MouseLeave
    End Sub

    Private Sub btnLogin_MouseEnter(sender As Object, e As EventArgs)
        ' Smooth transition for hover effect
        Dim hoverColor As Color = Color.FromArgb(220, 150, 150) ' Adjusted background color
        CType(sender, Button).BackColor = hoverColor
    End Sub

    Private Sub btnLogin_MouseLeave(sender As Object, e As EventArgs)
        ' Smooth transition for hover effect
        Dim originalColor As Color = Color.FromArgb(255, 128, 128) ' Original background color
        CType(sender, Button).BackColor = originalColor
    End Sub
End Class
