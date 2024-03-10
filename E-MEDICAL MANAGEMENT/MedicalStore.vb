Imports Npgsql
Imports System.Data

Public Class MedicalStore
    Public gen As New DataTable()
    Private connection As New NpgsqlConnection(GetConnectionString())

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        UserHomePage.Show()
    End Sub

    Private Sub MedicalStore_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub MedicalStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblName1.Text = StartPage.userName.ToString()
    End Sub

    Private Sub ExecuteQueryAndDisplayResults(tableName As String, displayText As String)
        Try
            gen.Clear()
            Dim query As String = $"SELECT * FROM {tableName}"
            Using cmd As New NpgsqlCommand(query, connection)
                connection.Open()
                Using reader As NpgsqlDataReader = cmd.ExecuteReader()
                    ' Load data into the gen DataTable
                    gen.Load(reader)

                    ' Add items to Dispaly.lstName using gen DataTable
                    For Each row As DataRow In gen.Rows
                        Dispaly.lstName.Items.Add(row(1).ToString())
                        Dispaly.lstName.Items.Add(vbNewLine)
                    Next
                End Using
            End Using
            Dispaly.grpDetails.Text = displayText
            Dispaly.result(gen)
            Dispaly.Show()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub


    Private Sub btnGeneral_Click(sender As Object, e As EventArgs) Handles btnGeneral.Click
        ExecuteQueryAndDisplayResults("General", "GENERAL STORES")
    End Sub

    Private Sub llGeneral_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llGeneral.LinkClicked
        ExecuteQueryAndDisplayResults("General", "GENERAL STORES")
    End Sub

    Private Sub btnSpecialized_Click(sender As Object, e As EventArgs) Handles btnSpecialized.Click
        ExecuteQueryAndDisplayResults("Specialized", "SPECIALIZED STORE")
    End Sub

    Private Sub llSpecialized_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llSpecialized.LinkClicked
        ExecuteQueryAndDisplayResults("Specialized", "SPECIALIZED STORE")
    End Sub

    Private Sub btnPreventive_Click(sender As Object, e As EventArgs) Handles btnPreventive.Click
        ExecuteQueryAndDisplayResults("Preventive", "PREVENTIVE STORE")
    End Sub

    Private Sub llPreventive_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llPreventive.LinkClicked
        ExecuteQueryAndDisplayResults("Preventive", "PREVENTIVE STORE")
    End Sub

    Private Sub llLogOut_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llLogOut.LinkClicked
        Me.Hide()
        StartPage.Show()
    End Sub

    Private Sub lblName1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
