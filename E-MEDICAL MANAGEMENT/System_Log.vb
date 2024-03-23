Imports Npgsql
Imports System.Net
Imports System.IO

Module System_Log

    Dim connection As New NpgsqlConnection(GetConnectionString())

    ' Function to log login time
    Public Function LogLoginTime() As Boolean
        Dim loginTime As DateTime = DateTime.Now
        Dim ipAddress As String = GetPublicIPAddress()

        Try
            connection.Open()
            Dim commandText As String = $"INSERT INTO sys_log (user_id, user_name, ip_address, login_time) VALUES ( '{StartPage.userID}', '{StartPage.userName}', '{ipAddress}', '{loginTime}')"
            Using cmd As New NpgsqlCommand(commandText, connection)
                cmd.ExecuteNonQuery()
            End Using
            Return True ' Log in time successfully recorded
        Catch ex As Exception
            MsgBox("Error logging login time: " & ex.Message)
            Return False ' Failed to log in time
        Finally
            connection.Close()
        End Try
    End Function

    ' Function to retrieve public IP address
    Private Function GetPublicIPAddress() As String
        Dim request As HttpWebRequest = WebRequest.Create("https://api.ipify.org")
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
        Dim reader As New StreamReader(response.GetResponseStream())
        Dim ipAddress As String = reader.ReadToEnd()
        response.Close()
        Return ipAddress
    End Function

    ' Function to log logout time
    Public Function LogLogoutTime() As Boolean
        Dim logoutTime As DateTime = DateTime.Now
        Try
            connection.Open()
            Dim commandText As String = $"UPDATE sys_log SET logout_time = '{logoutTime}' WHERE user_name = '{StartPage.userName}' AND user_id = '{StartPage.userID}' AND logout_time IS NULL"
            Using cmd As New NpgsqlCommand(commandText, connection)
                cmd.ExecuteNonQuery()
            End Using
            Return True ' Log out time successfully recorded
        Catch ex As Exception
            MsgBox("Error logging logout time: " & ex.Message)
            Return False ' Failed to log out time
        Finally
            connection.Close()
        End Try
    End Function

End Module
