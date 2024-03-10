Imports Npgsql
Imports System.Data

Public Class AdministratorPage
    Public Property str1 As String = StartPage.adminName.ToString()
    Public Property TName As String
    Dim connection As New NpgsqlConnection(GetConnectionString())

    Private Sub AdministratorPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblName.Text = str1
    End Sub

    Private Sub AdministratorPage_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Hide()
        StartPage.Show()
    End Sub


    Private Sub llLogOut_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llLogOut.LinkClicked
        Me.Hide()
        StartPage.Show()
    End Sub

    Private Sub llMedicalStore_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llMedicalStore.LinkClicked
        Try
            llPreventiveStore.Visible = True
            llGeneralStore.Visible = True
            llSpecializedStore.Visible = True
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub llLaboratories_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llLaboratories.LinkClicked
        Try
            TName = "Laboratories"
            Dim cmd As New NpgsqlCommand("SELECT * FROM Laboratories", connection)
            Dim ad As New NpgsqlDataAdapter(cmd)
            Dim table As New DataTable
            ad.Fill(table)
            TableUpdate.dgv.DataSource = table
            TableUpdate.lbl1.Text = "TYPE"
            TableUpdate.txt1.Width = 391
            TableUpdate.Show()
            Me.Hide()
            TableUpdate.lblName.Text = str1
            llPreventiveStore.Visible = False
            llGeneralStore.Visible = False
            llSpecializedStore.Visible = False
            TableUpdate.lbl6.Visible = False
            TableUpdate.txt6.Visible = False
            TableUpdate.lblTableName.Text = "LABORATORIES TABLE"
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
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
            TableUpdate.dgv.DataSource = table
            TableUpdate.lbl1.Text = "TYPE"
            TableUpdate.txt1.Width = 391
            TableUpdate.Show()
            Me.Hide()
            TableUpdate.lblName.Text = str1
            llPreventiveStore.Visible = False
            llGeneralStore.Visible = False
            llSpecializedStore.Visible = False
            TableUpdate.lbl6.Visible = False
            TableUpdate.txt6.Visible = False
            TableUpdate.lblTableName.Text = "DIAGNOSIS TABLE"
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
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
            TableUpdate.dgv.DataSource = table
            TableUpdate.Show()
            Me.Hide()
            TableUpdate.lblName.Text = str1
            llPreventiveStore.Visible = False
            llGeneralStore.Visible = False
            llSpecializedStore.Visible = False
            TableUpdate.lbl1.Text = "USER ID"
            TableUpdate.lbl2.Text = "USER NAME"
            TableUpdate.lbl3.Text = "SEX"
            TableUpdate.lbl4.Text = "AGE"
            TableUpdate.lbl5.Text = "PHONE"
            TableUpdate.txt1.Width = 391
            TableUpdate.txt3.Width = 99
            TableUpdate.txt4.Width = 99
            TableUpdate.lblTableName.Text = "USERS DETAILS"
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
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
            TableUpdate.dgv.DataSource = table
            TableUpdate.Show()
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
            TableUpdate.lbl1.Text = "USER ID"
            TableUpdate.lbl2.Text = "USER NAME"
            TableUpdate.lbl3.Text = "PASSWORD"
            TableUpdate.txt1.Width = 391
            TableUpdate.txt2.Width = 391
            TableUpdate.txt3.Width = 391
            TableUpdate.lblTableName.Text = "ADMINISTRATOR TABLE"
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
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
            TableUpdate.dgv.DataSource = table
            TableUpdate.lblTableName.Text = "GENERAL STORE TABLE"
            TableUpdate.Show()
            Me.Hide()
            TableUpdate.lblName.Text = str1
            TableUpdate.lbl6.Visible = False
            TableUpdate.txt6.Visible = False
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
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
            TableUpdate.dgv.DataSource = table
            TableUpdate.lblTableName.Text = "SPECIALIZED STORE TABLE"
            TableUpdate.Show()
            Me.Hide()
            TableUpdate.lblName.Text = str1
            TableUpdate.lbl6.Visible = False
            TableUpdate.txt6.Visible = False
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
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
            TableUpdate.dgv.DataSource = table
            TableUpdate.lblTableName.Text = "PREVENTIVE STORE TABLE"
            TableUpdate.Show()
            Me.Hide()
            TableUpdate.lblName.Text = str1
            TableUpdate.lbl6.Visible = False
            TableUpdate.txt6.Visible = False
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        End Try
        If connection.State = ConnectionState.Open Then
            connection.Close()
        End If
    End Sub

End Class