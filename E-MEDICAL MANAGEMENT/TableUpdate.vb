Imports System.Drawing.Printing
Imports System.IO
Imports Npgsql

Public Class TableUpdate
    Private connection As New NpgsqlConnection(GetConnectionString())

    Dim fieldName As String

    Dim UserpassHash As String
    Dim AdminpassHash As String

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

            ' Common functionality outside conditionals
            Dim cmd As New NpgsqlCommand(query, connection)
            Dim ad As New NpgsqlDataAdapter(cmd)
            Dim table As New DataTable
            ad.Fill(table)
            dgvAdmin.DataSource = table
            MsgBox("Operation successful!", MsgBoxStyle.Information)
            'empty textboxes after a successful operation
            txt1.Clear()
            txt2.Clear()
            txt3.Clear()
            txt4.Clear()
            txt5.Clear()
            txt6.Clear()

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    'check if the id is integer
    Private Function IsInteger(input As String) As Boolean
        Dim result As Integer
        Return Integer.TryParse(input, result)
    End Function


    ' fUNCTION TO CHECK IF RECORD EXIST BEFORE EXECUTING QUERIES
    Private Function RecordExists(tableName As String, value As String) As Boolean

        If {"Laboratories", "diagnosis"}.Contains(AdministratorPage.TName) Then
            fieldName = "id"
        ElseIf {"General", "Specialized", "Preventive"}.Contains(AdministratorPage.TName) Then
            fieldName = "s_no"
        ElseIf {"administrator", "SignUpPage"}.Contains(AdministratorPage.TName) Then
            fieldName = "userid"
        ElseIf AdministratorPage.TName = "bookings" Then
            fieldName = "booking_id"
        ElseIf AdministratorPage.TName = "sys_log" Then
            fieldName = "syslog_id"
        End If

        Dim query As String = "SELECT COUNT(*) FROM " & tableName & " WHERE " & fieldName & "='" & value & "'"
        Dim recordCount As Integer = 0

        Try
            connection.Open()
            Dim cmd As New NpgsqlCommand(query, connection)
            recordCount = Convert.ToInt32(cmd.ExecuteScalar())
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            connection.Close()
        End Try

        Return recordCount > 0
    End Function


    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Try
            'Check if the fields are not empty
            If {"Laboratories", "diagnosis"}.Contains(AdministratorPage.TName) Then
                If txt2.Text.Trim() = "" OrElse txt3.Text.Trim() = "" OrElse txt4.Text.Trim() = "" OrElse txt5.Text.Trim() = "" OrElse txt6.Text.Trim() = "" Then
                    MsgBox("Please fill all the required fields.", MsgBoxStyle.Exclamation)
                    Return
                End If
            ElseIf {"General", "Specialized", "Preventive"}.Contains(AdministratorPage.TName) Then
                If txt2.Text.Trim() = "" OrElse txt3.Text.Trim() = "" OrElse txt4.Text.Trim() = "" OrElse txt5.Text.Trim() = "" Then
                    MsgBox("Please fill all the required fields.", MsgBoxStyle.Exclamation)
                    Return
                End If
            ElseIf AdministratorPage.TName = "administrator" Then
                If txt1.Text.Trim() = "" OrElse txt2.Text.Trim() = "" OrElse txt3.Text.Trim() = "" Then
                    MsgBox("Please fill all the required fields.", MsgBoxStyle.Exclamation)
                    Return
                End If
            ElseIf AdministratorPage.TName = "SignUpPage" Then
                If txt1.Text.Trim() = "" OrElse txt2.Text.Trim() = "" OrElse txt3.Text.Trim() = "" OrElse txt4.Text.Trim() = "" OrElse txt5.Text.Trim() = "" OrElse txt6.Text.Trim() = "" Then
                    MsgBox("Please fill all the required fields.", MsgBoxStyle.Exclamation)
                    Return
                End If
            End If

            If Not IsInteger(txt1.Text) Then
                MsgBox("Please enter a valid integer for ID/S.NO.", MsgBoxStyle.Exclamation)
                Return
            End If

            If RecordExists(AdministratorPage.TName, txt1.Text) Then
                MsgBox("Record with ID/S.NO " & txt1.Text & " already exists.", MsgBoxStyle.Exclamation)
                Return
            End If

            'Hash Passwords before storing
            UserpassHash = PasswordUtility.HashPassword(txt6.Text)
            AdminpassHash = PasswordUtility.HashPassword(txt3.Text)


            Dim query As String = ""

            If {"Laboratories", "diagnosis"}.Contains(AdministratorPage.TName) Then
                query = "insert into " & AdministratorPage.TName & "(type,name,address,phone,time) VALUES ('" & txt2.Text & "','" & txt3.Text & "','" & txt4.Text & "','" & txt5.Text & "','" & txt6.Text & "')"
            ElseIf {"General", "Specialized", "Preventive"}.Contains(AdministratorPage.TName) Then
                query = "insert into " & AdministratorPage.TName & "(name,address,phone,time) VALUES ('" & txt2.Text & "','" & txt3.Text & "','" & txt4.Text & "','" & txt5.Text & "')"
            ElseIf AdministratorPage.TName = "administrator" Then
                query = "insert into administrator(userid,name,password) VALUES ('" & txt1.Text & "','" & txt2.Text & "','" & AdminpassHash & "')"
            ElseIf AdministratorPage.TName = "SignUpPage" Then
                query = "insert into SignUpPage(userid,name,sex,age,phone,password) VALUES ('" & txt1.Text & "','" & txt2.Text & "','" & txt3.Text & "','" & txt4.Text & "','" & txt5.Text & "','" & UserpassHash & "')"
            End If

            ExecuteQueryAndLoadData(query)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            If txt1.Text.Trim() = "" Then
                MsgBox("Please fill in the ID/S.NO field.", MsgBoxStyle.Exclamation)
                Return
            End If

            If Not IsInteger(txt1.Text) Then
                MsgBox("Please enter a valid integer for ID/S.NO.", MsgBoxStyle.Exclamation)
                Return
            End If

            If Not RecordExists(AdministratorPage.TName, txt1.Text) Then
                MsgBox("Record with ID/S.NO " & txt1.Text & " does not exist.", MsgBoxStyle.Exclamation)
                Return
            End If

            Dim query As String = ""

            If {"Laboratories", "diagnosis"}.Contains(AdministratorPage.TName) Then
                query = "select * from " & AdministratorPage.TName & " where id='" & txt1.Text & "'"
            ElseIf {"General", "Specialized", "Preventive"}.Contains(AdministratorPage.TName) Then
                query = "select * from " & AdministratorPage.TName & " where s_no='" & txt1.Text & "'"
            ElseIf AdministratorPage.TName = "administrator" Then
                query = "select * from administrator where userid='" & txt1.Text & "'"
            ElseIf AdministratorPage.TName = "SignUpPage" Then
                query = "select * from SignUpPage where userid='" & txt1.Text & "'"
            ElseIf AdministratorPage.TName = "bookings" Then
                query = "select * from bookings where booking_id='" & txt1.Text & "'"
            ElseIf AdministratorPage.TName = "sys_log" Then
                query = "select * from sys_log where syslog_id='" & txt1.Text & "'"
            End If

            ExecuteQueryAndLoadData(query)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            'Check if the fields are not empty
            If {"Laboratories", "diagnosis"}.Contains(AdministratorPage.TName) Then
                If txt1.Text.Trim() = "" OrElse txt2.Text.Trim() = "" OrElse txt3.Text.Trim() = "" OrElse txt4.Text.Trim() = "" OrElse txt5.Text.Trim() = "" OrElse txt6.Text.Trim() = "" Then
                    MsgBox("Please fill all the required fields.")
                    Return
                End If
            ElseIf {"General", "Specialized", "Preventive"}.Contains(AdministratorPage.TName) Then
                If txt1.Text.Trim() = "" OrElse txt2.Text.Trim() = "" OrElse txt3.Text.Trim() = "" OrElse txt4.Text.Trim() = "" OrElse txt5.Text.Trim() = "" Then
                    MsgBox("Please fill all the required fields.", MsgBoxStyle.Exclamation)
                    Return
                End If
            ElseIf AdministratorPage.TName = "administrator" Then
                If txt1.Text.Trim() = "" OrElse txt2.Text.Trim() = "" OrElse txt3.Text.Trim() = "" Then
                    MsgBox("Please fill all the required fields.", MsgBoxStyle.Exclamation)
                    Return
                End If
            ElseIf AdministratorPage.TName = "SignUpPage" Then
                If txt1.Text.Trim() = "" OrElse txt2.Text.Trim() = "" OrElse txt3.Text.Trim() = "" OrElse txt4.Text.Trim() = "" OrElse txt5.Text.Trim() = "" OrElse txt6.Text.Trim() = "" Then
                    MsgBox("Please fill all the required fields.", MsgBoxStyle.Exclamation)
                    Return
                End If
            ElseIf AdministratorPage.TName = "bookings" Then
                If txt1.Text.Trim() = "" OrElse txt2.Text.Trim() = "" OrElse txt3.Text.Trim() = "" OrElse txt4.Text.Trim() = "" OrElse txt5.Text.Trim() = "" OrElse txt6.Text.Trim() = "" Then
                    MsgBox("Please fill all the required fields.", MsgBoxStyle.Exclamation)
                    Return
                End If
            End If

            If Not IsInteger(txt1.Text) Then
                MsgBox("Please enter a valid integer for ID/S.NO.", MsgBoxStyle.Exclamation)
                Return
            End If

            If Not RecordExists(AdministratorPage.TName, txt1.Text) Then
                MsgBox("Record with ID/S.NO " & txt1.Text & " does not exist.", MsgBoxStyle.Exclamation)
                Return
            End If

            'Hash Passwords before updating
            UserpassHash = PasswordUtility.HashPassword(txt6.Text)
            AdminpassHash = PasswordUtility.HashPassword(txt3.Text)

            Dim query As String = ""

            If {"Laboratories", "diagnosis"}.Contains(AdministratorPage.TName) Then
                query = "update " & AdministratorPage.TName & " set type='" & txt2.Text & "',name='" & txt3.Text & "',address='" & txt4.Text & "',phone='" & txt5.Text & "',time='" & txt6.Text & "' where id='" & txt1.Text & "'"
            ElseIf {"General", "Specialized", "Preventive"}.Contains(AdministratorPage.TName) Then
                query = "update " & AdministratorPage.TName & " set name='" & txt2.Text & "',address='" & txt3.Text & "',phone='" & txt4.Text & "',time='" & txt5.Text & "' where s_no='" & txt1.Text & "'"
            ElseIf AdministratorPage.TName = "administrator" Then
                query = "update administrator set userid='" & txt1.Text & "',name='" & txt2.Text & "',password='" & AdminpassHash & "' where userid='" & txt1.Text & "'"
            ElseIf AdministratorPage.TName = "SignUpPage" Then
                query = "update SignUpPage set userid='" & txt1.Text & "',name='" & txt2.Text & "',sex='" & txt3.Text & "',age='" & txt4.Text & "',phone='" & txt5.Text & "',password='" & UserpassHash & "' where userid='" & txt1.Text & "'"
            ElseIf AdministratorPage.TName = "bookings" Then
                query = "update bookings set service='" & txt3.Text & "',doctor_or_center='" & txt4.Text & "',consultation_date='" & txt5.Text & "',address='" & txt6.Text & "' where booking_id='" & txt1.Text & "'"
            End If

            ExecuteQueryAndLoadData(query)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If txt1.Text.Trim() = "" Then
                MsgBox("Please fill in the ID/S.NO field.", MsgBoxStyle.Exclamation)
                Return
            End If

            If Not IsInteger(txt1.Text) Then
                MsgBox("Please enter a valid integer for ID/S.NO.", MsgBoxStyle.Exclamation)
                Return
            End If

            If Not RecordExists(AdministratorPage.TName, txt1.Text) Then
                MsgBox("Record with ID/S.NO " & txt1.Text & " does not exist.", MsgBoxStyle.Exclamation)
                Return
            End If

            Dim query As String = ""

            If {"Laboratories", "diagnosis"}.Contains(AdministratorPage.TName) Then
                query = "delete from " & AdministratorPage.TName & " where id='" & txt1.Text & "'"
            ElseIf {"General", "Specialized", "Preventive"}.Contains(AdministratorPage.TName) Then
                query = "delete from " & AdministratorPage.TName & " where s_no='" & txt1.Text & "'"
            ElseIf AdministratorPage.TName = "administrator" Then
                query = "delete from administrator where userid='" & txt1.Text & "'"
            ElseIf AdministratorPage.TName = "SignUpPage" Then
                query = "delete from SignUpPage where userid='" & txt1.Text & "'"
            ElseIf AdministratorPage.TName = "bookings" Then
                query = "delete from bookings where booking_id='" & txt1.Text & "'"
            ElseIf AdministratorPage.TName = "sys_log" Then
                query = "delete from sys_log where syslog_id='" & txt1.Text & "'"
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


    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        Try
            connection.Open()

            ' Define the SQL query based on the selected table name
            Dim sqlQuery As String = ""
            Dim tableName As String = lblTableName.Text
            Dim queries As New Dictionary(Of String, String) From {
            {"DIAGNOSIS TABLE", "SELECT * FROM diagnosis"},
            {"LABORATORIES TABLE", "SELECT * FROM Laboratories"},
            {"USERS DETAILS", "SELECT * FROM SignUpPage"},
            {"ADMINISTRATOR TABLE", "SELECT * FROM administrator"},
            {"GENERAL STORE TABLE", "SELECT * FROM General"},
            {"SPECIALIZED STORE TABLE", "SELECT * FROM Specialized"},
            {"PREVENTIVE STORE TABLE", "SELECT * FROM Preventive"},
            {"USER BOOKINGS TABLE", "SELECT * FROM bookings"},
            {"SYSTEM LOGS", "SELECT * FROM sys_log"}
        }

            ' Check if the table name exists in the dictionary
            If queries.ContainsKey(tableName) Then
                sqlQuery = queries(tableName)
                Dim cmd As New NpgsqlCommand(sqlQuery, connection)
                Dim ad As New NpgsqlDataAdapter(cmd)
                Dim table As New DataTable()
                ad.Fill(table)
                dgvAdmin.DataSource = table
            Else
                MsgBox("No query found for the selected table.", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            connection.Close()
        End Try
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

        ' Define the default name for the PDF
        Dim pdfName As String = $"{lblTableName.Text}_{StartPage.userName}_{DateTime.Now.ToString("yyyyMMdd")}.pdf"

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
        e.Graphics.DrawString("Admin ID: " & StartPage.userID, f10b, Brushes.Black, leftmargin, startY)
        startY += lineHeight
        e.Graphics.DrawString("Admin Name: " & StartPage.userName, f10b, Brushes.Black, leftmargin, startY)
        startY += lineHeight * 2 ' Add extra space after user info

        ' Draw Printing Date
        e.Graphics.DrawString("Printing Date: " & PrintingTime.ToString("dd/MM/yyyy"), f10b, Brushes.Black, leftmargin, startY)
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


        ' Save the PDF with the default name
        PD.DocumentName = pdfName
        Dim filePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), pdfName)
        PD.PrinterSettings.PrintToFile = True
        PD.PrinterSettings.PrintFileName = filePath
    End Sub

    Private Sub btnPrintData_Click(sender As Object, e As EventArgs) Handles btnPrintData.Click
        MsgBox("Printing Started! Please Wait", MsgBoxStyle.Information)
        PPD.Document = PD
        PPD.ShowDialog()
    End Sub
End Class