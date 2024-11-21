Imports System.Data.SqlClient

Public Class DatabaseHelper
    ' Static connection string
    Public Shared ReadOnly ConnectionString As String = "Data Source=DESKTOP-NUDMVOB\SQLEXPRESS; Initial Catalog=VbDotNet; Integrated Security=True"

    ' Method to create and return a new SQL connection
    Public Shared Function GetConnection() As SqlConnection
        Return New SqlConnection(ConnectionString)
    End Function
End Class
