Option Explicit On
Option Strict On

Imports Npgsql

Module PostgreSQL_Connection

    Public Function GetConnectionString() As String

        Dim host As String = "Host=aws-0-us-west-1.pooler.supabase.com;"
        Dim port As String = "Port=5432;"
        Dim db As String = "Database=postgres;"
        Dim user As String = "Username=postgres.wuhhyphxwlxldxbgzmfu;"
        Dim pass As String = "Password=vertexhubDBpassword;"



        Dim conString As String = String.Format("{0}{1}{2}{3}{4}", host, port, db, user, pass)


        Return conString

    End Function
End Module
