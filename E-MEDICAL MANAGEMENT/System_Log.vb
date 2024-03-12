Imports Npgsql

Module System_Log

    Dim connection As New NpgsqlConnection(GetConnectionString())

    ' Function to log login time
    Public Function LogLoginTime() As Boolean
        Dim loginTime As DateTime = DateTime.Now
        Try
            connection.Open()
            Dim commandText As String = $"INSERT INTO sys_log (user_id, user_name, login_time) VALUES ( '{StartPage.userID}', '{StartPage.userName}', '{loginTime}')"
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
