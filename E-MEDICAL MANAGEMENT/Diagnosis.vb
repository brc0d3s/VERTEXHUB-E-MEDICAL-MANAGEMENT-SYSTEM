Imports Npgsql

Public Class Diagnosis
    Public gen As New DataTable()
    Private connection As New NpgsqlConnection(GetConnectionString())

    Public Sub Diagnosis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblName1.Text = StartPage.userName.ToString()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        UserHomePage.Show()
    End Sub

    Private Sub Diagnosis_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub ExecuteQueryAndDisplayResults(type As String, displayText As String)
        Try
            gen.Clear()
            Dim query As String = "SELECT * FROM diagnosis WHERE TYPE = @name"
            Using cmd As New NpgsqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@name", type)
                connection.Open()
                Using reader As NpgsqlDataReader = cmd.ExecuteReader()
                    ' Load data into the gen DataTable
                    gen.Load(reader)

                    ' Clear ListBox before adding new items
                    Dispaly.lstName.Items.Clear()

                    ' Add items to Dispaly.lstName using gen DataTable
                   ' Start from the second column (index 1)
                    For i As Integer = 1 To gen.Columns.Count - 1
                        Dispaly.lstName.Items.Add(row(i).ToString())
                        Dispaly.lstName.Items.Add(vbNewLine)
                    Next
                End Using
            End Using
            Dispaly.grpDetails.Text = displayText
            Dispaly.result(gen) ' Pass the DataTable to the result method
            Dispaly.Show()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub llGeneralPhysician_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llGeneralPhysician.LinkClicked
        ExecuteQueryAndDisplayResults("GEN", "GENERAL PHYSICIAN")
    End Sub

    Private Sub llENTSpecialists_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llENTSpecialists.LinkClicked
        ExecuteQueryAndDisplayResults("ENT", "ENT SPECIALISTS")
    End Sub

    Private Sub llEyeSpecialists_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llEyeSpecialists.LinkClicked
        ExecuteQueryAndDisplayResults("EYE", "EYE SPECIALISTS")
    End Sub

    Private Sub llBoneSpecialists_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llBoneSpecialists.LinkClicked
        ExecuteQueryAndDisplayResults("BONE", "BONE SPECIALISTS")
    End Sub

    Private Sub lleethSpecialists_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llteethSpecialists.LinkClicked
        ExecuteQueryAndDisplayResults("TEETH", "TEETH SPECIALISTS")
    End Sub

    Private Sub llAllegySpecialists_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llAllegySpecialists.LinkClicked
        ExecuteQueryAndDisplayResults("ALLERGY", "ALLERGY SPECIALISTS")
    End Sub

    Private Sub llHeartSpecialists_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llHeartSpecialists.LinkClicked
        ExecuteQueryAndDisplayResults("HEART", "HEART SPECIALISTS")
    End Sub

    Private Sub llNeuroSpecialists_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llNeuroSpecialists.LinkClicked
        ExecuteQueryAndDisplayResults("NEURO", "NEURO SPECIALISTS")
    End Sub

    Private Sub llLogOut_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llLogOut.LinkClicked
        ' Log logout time
        LogLogoutTime()
        Me.Close()
        StartPage.Show()
    End Sub
End Class
