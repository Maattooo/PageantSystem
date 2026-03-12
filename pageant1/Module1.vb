Imports MySql.Data.MySqlClient

Module Module1
    Public con As New MySqlConnection("server=192.168.2.5;userid=admin;password=admin;database=pageant")

    Public Sub SafeCloseConnection()
        If con IsNot Nothing AndAlso con.State <> ConnectionState.Closed Then
            con.Close()
        End If
    End Sub
End Module

