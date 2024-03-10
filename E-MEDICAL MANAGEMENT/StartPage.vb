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
                lblName.Text = table.Rows(0)(1).ToString()
                str = lblName.Text
                GrpBx.Visible = False
                btnLaboratories.Visible = True
                btnDiagnosis.Visible = True
                btnMedicalStore.Visible = True
                llLogOut.Visible = True
                llAdministrator.Visible = False
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

    Private Sub StartPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnLaboratories.Visible = False
        btnDiagnosis.Visible = False
        btnMedicalStore.Visible = False
        llLogOut.Visible = False
    End Sub

    Private Sub btnDiagnosis_Click(sender As Object, e As EventArgs) Handles btnDiagnosis.Click
        Me.Hide()
        Diagnosis.Show()
    End Sub

    Private Sub btnLaboratories_Click(sender As Object, e As EventArgs) Handles btnLaboratories.Click
        Me.Hide()
        Laboratories.Show()
    End Sub

    Private Sub btnMedicalStore_Click(sender As Object, e As EventArgs) Handles btnMedicalStore.Click
        Me.Hide()
        MedicalStore.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llLogOut.LinkClicked
        GrpBx.Visible = True
        btnLaboratories.Visible = False
        btnDiagnosis.Visible = False
        btnMedicalStore.Visible = False
        lblName.Text = ""
        txtPassword.Text = ""
        txtUser.Text = ""
        llLogOut.Visible = False
        llAdministrator.Visible = True
    End Sub

    Private Sub llAdministrator_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llAdministrator.LinkClicked
        Me.Hide()
        AdministratorPage.txtUser.Text = ""
        AdministratorPage.txtPassword.Text = ""
        AdministratorPage.Show()
        AdministratorPage.GrpBx.Visible = True
        AdministratorPage.llLogOut.Visible = False
        AdministratorPage.lblName.Text = ""
        AdministratorPage.llMedicalStore.Visible = False
        AdministratorPage.llSpecializedStore.Visible = False
        AdministratorPage.llPreventiveStore.Visible = False
        AdministratorPage.llGeneralStore.Visible = False
        AdministratorPage.llLaboratories.Visible = False
        AdministratorPage.llDiagnosis.Visible = False
        AdministratorPage.llUsersDetails.Visible = False
        AdministratorPage.llAdministrators.Visible = False
    End Sub
End Class
