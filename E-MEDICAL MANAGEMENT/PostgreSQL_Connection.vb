Option Explicit On
Option Strict On

Module PostgreSQL_Connection

    Public Function GetConnectionString() As String

        Dim host As String = "Host=ep-hidden-night-a5bx4vqf-pooler.us-east-2.aws.neon.tech;"
        Dim port As String = "Port=5432;"
        Dim db As String = "Database=VertexhubDB;"
        Dim user As String = "Username=neondb_owner;"
        Dim pass As String = "Password=M6uzyPULT5RA;"



        Dim conString As String = String.Format("{0}{1}{2}{3}{4}", host, port, db, user, pass)


        Return conString

    End Function
End Module
