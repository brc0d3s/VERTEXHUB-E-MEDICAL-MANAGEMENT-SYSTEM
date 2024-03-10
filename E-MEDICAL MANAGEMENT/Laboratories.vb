Imports Npgsql
Imports System.Data

Public Class Laboratories
    Private gen As New DataTable()
    Private connection As New NpgsqlConnection(GetConnectionString())

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        StartPage.Show()
    End Sub

    Private Sub Laboratories_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub Laboratories_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblName1.Text = StartPage.str.ToString()
        llBloodTest.Visible = False
        llSugarTest.Visible = False
        llUrineTest.Visible = False
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        llBloodTest.Visible = True
        llSugarTest.Visible = True
        llUrineTest.Visible = True
    End Sub

    Private Sub DisplayLabResults(ByVal labType As String)
        Try
            gen.Clear()
            connection.Open()
            Dispaly.grpDetails.Text = labType
            Dim cmd As New NpgsqlCommand("SELECT * FROM Laboratories WHERE TYPE=@name", connection)
            cmd.Parameters.AddWithValue("@name", labType)
            Dim pd As New NpgsqlDataAdapter(cmd)
            pd.Fill(gen)
            For i = 0 To gen.Rows.Count - 1
                Dispaly.lstName.Items.Add(gen.Rows(i)(1).ToString)
                Dispaly.lstName.Items.Add(vbNewLine)
            Next
            Dispaly.result(gen)
            Dispaly.Show()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            connection.Close()
        End Try
        llBloodTest.Visible = False
        llSugarTest.Visible = False
        llUrineTest.Visible = False
    End Sub

    Private Sub llXRay_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llXRay.LinkClicked
        DisplayLabResults("X-Ray")
    End Sub

    Private Sub llMRIScan_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llMRIScan.LinkClicked
        DisplayLabResults("MRI")
    End Sub

    Private Sub llUltraSound_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llUltraSound.LinkClicked
        DisplayLabResults("Ultrasound")
    End Sub

    Private Sub llECGScan_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llECGScan.LinkClicked
        DisplayLabResults("ECG")
    End Sub

    Private Sub llUrineTest_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llUrineTest.LinkClicked
        DisplayLabResults("Urine Test")
    End Sub

    Private Sub llBloodTest_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llBloodTest.LinkClicked
        DisplayLabResults("Blood Test")
    End Sub

    Private Sub llSugarTest_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llSugarTest.LinkClicked
        DisplayLabResults("Sugar Test")
    End Sub

    Private Sub llLogOut_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llLogOut.LinkClicked
        Me.Hide()
        StartPage.Show()
    End Sub

    Private Sub lblName1_Click(sender As Object, e As EventArgs) Handles lblName1.Click

    End Sub
End Class
