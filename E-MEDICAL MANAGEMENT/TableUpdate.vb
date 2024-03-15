Imports System.Drawing.Printing
Imports Npgsql

Public Class TableUpdate
    Private connection As New NpgsqlConnection(GetConnectionString())

    'Printing variables
    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Dim Longpaper As Integer

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
            dgvAdmin.DataSource = table
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
        Me.Close()
        AdministratorPage.Show()
        txt3.Clear()
        txt1.Clear()
        txt2.Clear()
        txt4.Clear()
        txt5.Clear()
        txt6.Clear()
    End Sub


    ' Print functionalities
    Private Sub PD_BeginPrint(sender As Object, e As Printing.PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 1900, 1000) ' Adjusted paper size
        PD.DefaultPageSettings = pagesetup
    End Sub

    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
        Dim f14 As New Font("Calibri", 14, FontStyle.Bold)

        Dim leftmargin As Integer = 50 ' Adjusted left margin

        ' Define string formats for alignment
        Dim leftFormat As New StringFormat()
        leftFormat.Alignment = StringAlignment.Near

        ' Define spacing between lines
        Dim lineHeight As Integer = 20
        Dim startY As Integer = 50 ' Starting position for drawing

        'Get time of printing the record
        Dim PrintingTime As DateTime = DateTime.Now
        Dim tableHeader As String = lblTableName.Text

        ' Draw Header
        e.Graphics.DrawString("VertexHub E-Medical", f14, Brushes.RoyalBlue, leftmargin, startY)
        startY += lineHeight
        e.Graphics.DrawString(tableHeader, f14, Brushes.Black, leftmargin, startY)
        startY += lineHeight * 2 ' Add extra space after header

        ' Draw ADMIN Information
        e.Graphics.DrawString("User ID: " & StartPage.userID, f10b, Brushes.Black, leftmargin, startY)
        startY += lineHeight
        e.Graphics.DrawString("User Name: " & StartPage.userName, f10b, Brushes.Black, leftmargin, startY)
        startY += lineHeight * 2 ' Add extra space after user info

        ' Draw Printing Date
        e.Graphics.DrawString("Booking Date: " & PrintingTime.ToString("dd/MM/yyyy"), f10b, Brushes.Black, leftmargin, startY)
        startY += lineHeight

        ' Draw Data table (Data Grid View) dgv
        Dim dgv As DataGridView = dgvAdmin ' Assuming "dvg" is the name of your DataGridView
        Dim columnLeft As Integer = leftmargin ' Start drawing from the left margin
        Dim rowTop As Integer = startY ' Start drawing from the current Y position

        ' Loop through each column in the DataGridView
        For Each column As DataGridViewColumn In dgv.Columns
            ' Draw column header
            e.Graphics.DrawString(column.HeaderText, f10b, Brushes.Black, columnLeft, rowTop)
            columnLeft += column.Width ' Move to the right based on column width
        Next

        rowTop += lineHeight ' Move to the next row
        columnLeft = leftmargin ' Reset drawing position to the left margin

        ' Loop through each row in the DataGridView
        For Each row As DataGridViewRow In dgv.Rows
            ' Loop through each cell in the row
            For Each cell As DataGridViewCell In row.Cells
                ' Draw cell content
                e.Graphics.DrawString(cell.FormattedValue.ToString(), f10, Brushes.Black, columnLeft, rowTop)
                columnLeft += dgv.Columns(cell.ColumnIndex).Width ' Move to the right based on column width
            Next
            rowTop += lineHeight ' Move to the next row
            columnLeft = leftmargin ' Reset drawing position to the left margin
        Next
    End Sub

    Private Sub btnPrintData_Click(sender As Object, e As EventArgs) Handles btnPrintData.Click
        MsgBox("Printing Started! Please Wait ")
        PPD.Document = PD
        PPD.ShowDialog()
    End Sub
End Class
