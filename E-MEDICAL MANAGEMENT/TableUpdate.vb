Imports System.IO
Imports ClosedXML.Excel
Imports Npgsql

Public Class TableUpdate
    Private connection As New NpgsqlConnection(GetConnectionString())

    Dim fieldName As String

    Dim UserpassHash As String
    Dim AdminpassHash As String


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
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
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
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
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
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
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
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
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
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
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
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
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
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
        Finally
            connection.Close()
        End Try
    End Sub


    Private Sub btnExportData_Click(sender As Object, e As EventArgs) Handles btnExportData.Click
        Try
            If dgvAdmin Is Nothing Then
                MsgBox("DataGridView is not initialized.", MsgBoxStyle.Critical)
                Return
            End If

            ' Set default file name
            Dim defaultFileName As String = $"{lblTableName.Text}_{StartPage.userName}_{DateTime.Now.ToString("yyyyMMdd")}.xlsx"

            Using workbook As XLWorkbook = New XLWorkbook()
                ' Add a worksheet to the workbook
                Dim worksheet As IXLWorksheet = workbook.Worksheets.Add("Data")

                ' Set headers formatting
                Dim boldStyle As IXLFont = worksheet.Cell(1, 1).Style.Font
                boldStyle.Bold = True
                boldStyle.FontSize = 14

                ' Add headers
                worksheet.Cell(1, 1).Value = "VertexHub E-Medical"
                worksheet.Cell(2, 1).Value = "Table:"
                worksheet.Cell(2, 2).Value = lblTableName.Text
                worksheet.Cell(3, 1).Value = "Admin ID:"
                worksheet.Cell(3, 2).Value = If(StartPage.userID IsNot Nothing, StartPage.userID.ToString(), "")
                worksheet.Cell(4, 1).Value = "Admin Name:"
                worksheet.Cell(4, 2).Value = If(StartPage.userName IsNot Nothing, StartPage.userName.ToString(), "")
                worksheet.Cell(5, 1).Value = "Printing Date:"
                worksheet.Cell(5, 2).Value = DateTime.Now.ToString("dd/MM/yyyy")

                If dgvAdmin.Rows.Count > 0 Then
                    ' Add column headers from the DataGridView
                    For colIndex As Integer = 0 To dgvAdmin.Columns.Count - 1
                        worksheet.Cell(7, colIndex + 1).Value = dgvAdmin.Columns(colIndex).HeaderText.ToString()
                    Next

                    ' Set column headers formatting
                    Dim headersBoldStyle As IXLFont = worksheet.Range("A7:" & ConvertToLetter(dgvAdmin.Columns.Count) & "7").Style.Font
                    headersBoldStyle.Bold = True
                    headersBoldStyle.FontSize = 12

                    ' Add data rows from the DataGridView
                    For rowIndex As Integer = 0 To dgvAdmin.Rows.Count - 1
                        For colIndex As Integer = 0 To dgvAdmin.Columns.Count - 1
                            worksheet.Cell(rowIndex + 8, colIndex + 1).Value = If(dgvAdmin.Rows(rowIndex).Cells(colIndex).Value IsNot Nothing, dgvAdmin.Rows(rowIndex).Cells(colIndex).Value.ToString(), "")
                        Next
                    Next
                End If

                ' Create and configure SaveFileDialog
                Dim saveDialog As New SaveFileDialog()
                saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"
                saveDialog.FileName = defaultFileName

                ' Show SaveFileDialog and check if the user clicked OK
                If saveDialog.ShowDialog() = DialogResult.OK Then
                    Dim filePath As String = saveDialog.FileName

                    ' Save the workbook with the specified file name and path
                    workbook.SaveAs(filePath)

                    ' Inform the user that exporting has completed
                    MsgBox("Exporting Completed!", MsgBoxStyle.Information)
                End If
            End Using
        Catch ex As Exception
            ' Log the error to console
            Console.WriteLine("Error: " & ex.Message)
            ' Display user-friendly error message
            MsgBox("An error occurred while processing your request. Please try again later.", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function ConvertToLetter(num As Integer) As String
        Dim modnum As Integer
        Dim letter As String = ""

        While num > 0
            modnum = (num - 1) Mod 26
            letter = Chr(65 + modnum) & letter
            num = (num - modnum) \ 26
        End While

        Return letter
    End Function



End Class