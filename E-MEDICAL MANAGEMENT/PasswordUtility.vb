Imports System.Security.Cryptography
Imports System.Text

Module PasswordUtility

    ' Function to hash a password using SHA256
    Public Function HashPassword(ByVal password As String) As String
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
        Dim hash As Byte() = New SHA256Managed().ComputeHash(bytes)
        Return Convert.ToBase64String(hash)
    End Function
End Module
