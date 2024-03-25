Imports Npgsql
Imports System.Net
Imports System.IO
Imports Newtonsoft.Json.Linq

Module System_Log

    Dim connection As New NpgsqlConnection(GetConnectionString())

    ' Function to log login time
    Public Function LogLoginTime() As Boolean
        Dim loginTime As DateTime = DateTime.Now
        Dim ipAddress As String = GetPublicIPAddress()
        Dim deviceLocation As String = GetLocation(ipAddress)
        
        Try
            connection.Open()
            Dim commandText As String = $"INSERT INTO sys_log (user_id, user_name, ip_address, login_time, device_location) VALUES ('{StartPage.userID}', '{StartPage.userName}', '{ipAddress}', '{loginTime}', '{deviceLocation}')"
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

    ' Function to retrieve location based on public IP address
    Private Function GetLocation(ipAddress As String) As String
        Dim apiUrl As String = $"http://ip-api.com/json/{ipAddress}"
        Dim request As HttpWebRequest = WebRequest.Create(apiUrl)
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
        Dim reader As New StreamReader(response.GetResponseStream())
        Dim jsonResponse As String = reader.ReadToEnd()
        response.Close()
        
        ' Parse JSON response to extract location information
        Dim location As String = ""
        Dim json As JObject = JObject.Parse(jsonResponse)
        If json("status").ToString() = "success" Then
            Dim city As String = json("city").ToString()
            Dim region As String = json("regionName").ToString()
            Dim country As String = json("country").ToString()
            location = $"{city}, {region}, {country}"
        End If
        
        Return location
    End Function

End Module
