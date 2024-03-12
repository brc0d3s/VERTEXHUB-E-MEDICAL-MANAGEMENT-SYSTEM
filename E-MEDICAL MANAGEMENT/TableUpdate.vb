Imports Npgsql

Public Class TableUpdate
    Private connection As New NpgsqlConnection(GetConnectionString())

    Private Sub llLogOut_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llLogOut.LinkClicked
        ' Log logout time
        LogLogoutTime()
        Me.Close()
        StartPage.Show()
    End Sub

    Private Sub TableUpdate_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        AdministratorPage.Show()
        Me.Hide()
    End Sub

    Private Sub ExecuteQueryAndLoadData(query As String)
        Try
            connection.Open()
            Dim cmd As New NpgsqlCommand(query, connection)
            Dim ad As New NpgsqlDataAdapter(cmd)
            Dim table As New DataTable
            ad.Fill(table)
            dgv.DataSource = table
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Try
            Dim query As String = ""

            If AdministratorPage.TName = "Laboratories" Then
                query = "insert into Laboratories(TYPE,NAME,ADDRESS,PHONE,TIME) VALUES ('" & txt1.Text & "','" & txt2.Text & "','" & txt3.Text & "','" & txt4.Text & "','" & txt5.Text & "')"
            ElseIf {"General", "Specialized", "Preventive", "diagnosis"}.Contains(AdministratorPage.TName) Then
                query = "insert into " & AdministratorPage.TName & "(S.NO,NAME,ADDRESS,PHONE,TIME) VALUES ('" & txt1.Text & "','" & txt2.Text & "','" & txt3.Text & "','" & txt4.Text & "','" & txt5.Text & "')"
            ElseIf AdministratorPage.TName = "administrator" Then
                query = "insert into administrator(USERS_ID,USERS_NAME,PASSWORD) VALUES ('" & txt1.Text & "','" & txt2.Text & "','" & txt3.Text & "')"
            ElseIf AdministratorPage.TName = "SignUpPage" Then
                query = "insert into SignUpPage(UserId,Name,Sex,Age,Phone,Password) VALUES ('" & txt1.Text & "','" & txt2.Text & "','" & txt3.Text & "','" & txt4.Text & "','" & txt5.Text & "','" & txt6.Text & "')"
            End If

            ExecuteQueryAndLoadData(query)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Dim query As String = ""

            If AdministratorPage.TName = "Laboratories" Then
                query = "select * from Laboratories where TYPE='" & txt1.Text & "' and NAME='" & txt2.Text & "'"
            ElseIf {"General", "Specialized", "Preventive", "diagnosis"}.Contains(AdministratorPage.TName) Then
                query = "select * from " & AdministratorPage.TName & " where S_NO='" & txt1.Text & "' and NAME='" & txt2.Text & "'"
            ElseIf AdministratorPage.TName = "administrator" Then
                query = "select * from administrator where USERS_ID='" & txt1.Text & "'"
            ElseIf AdministratorPage.TName = "SignUpPage" Then
                query = "select * from SignUpPage where UserId='" & txt1.Text & "'"
            End If

            ExecuteQueryAndLoadData(query)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim query As String = ""

            If AdministratorPage.TName = "Laboratories" Then
                query = "update Laboratories set ADDRESS='" & txt3.Text & "',PHONE='" & txt4.Text & "',TIME='" & txt5.Text & "' where TYPE='" & txt1.Text & "' and NAME='" & txt2.Text & "'"
            ElseIf {"General", "Specialized", "Preventive", "diagnosis"}.Contains(AdministratorPage.TName) Then
                query = "update " & AdministratorPage.TName & " set ADDRESS='" & txt3.Text & "',PHONE='" & txt4.Text & "',TIME='" & txt5.Text & "' where S_NO='" & txt1.Text & "' and NAME='" & txt2.Text & "'"
            ElseIf AdministratorPage.TName = "administrator" Then
                query = "update administrator set PASSWORD='" & txt3.Text & "' where USERS_ID='" & txt1.Text & "' and USERS_NAME='" & txt2.Text & "'"
            ElseIf AdministratorPage.TName = "SignUpPage" Then
                query = "update SignUpPage set Age='" & txt4.Text & "',Phone='" & txt5.Text & "',Password='" & txt6.Text & "' where UserId='" & txt1.Text & "' and Name='" & txt2.Text & "' and Sex='" & txt3.Text & "'"
            End If

            ExecuteQueryAndLoadData(query)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Dim query As String = ""

            If AdministratorPage.TName = "Laboratories" Then
                query = "delete from Laboratories where TYPE='" & txt1.Text & "' and NAME='" & txt2.Text & "'"
            ElseIf {"General", "Specialized", "Preventive", "diagnosis"}.Contains(AdministratorPage.TName) Then
                query = "delete from " & AdministratorPage.TName & " where S_NO='" & txt1.Text & "' and NAME='" & txt2.Text & "'"
            ElseIf AdministratorPage.TName = "administrator" Then
                query = "delete from administrator where USERS_ID='" & txt1.Text & "'"
            ElseIf AdministratorPage.TName = "SignUpPage" Then
                query = "delete from SignUpPage where UserId='" & txt1.Text & "'"
            End If

            ExecuteQueryAndLoadData(query)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnBak_Click(sender As Object, e As EventArgs) Handles btnBak.Click
        Me.Hide()
        AdministratorPage.Show()
        txt3.Clear()
        txt1.Clear()
        txt2.Clear()
        txt4.Clear()
        txt5.Clear()
        txt6.Clear()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

    End Sub

    Private Sub btnPriview_Click(sender As Object, e As EventArgs) Handles btnPriview.Click

    End Sub
End Class
