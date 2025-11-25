Imports System.Data.SqlClient

Public Class dbLogin
        Private ReadOnly dbHelper = New DbHelper() ' Clase para manejar conexiones y consultas

        Public Function ValidateLogin(ByRef usuario As String, ByRef password As String) As Boolean
            Try
                Dim sql As String = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @Usuario AND Contrasena = @Password"
            Dim Parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Usuario", usuario),
                New SqlParameter("@Password", password)
            }
            Dim dt As DataTable = dbHelper.ExecuteQuery(sql, Parametros)
                If dt.Rows.Count > 0 AndAlso Convert.ToInt32(dt.Rows(0)(0)) > 0 Then
                    Return True
                End If
            Catch ex As Exception

            Return False
        End Try
            Return False
        End Function

    Public Function RegisterUser(usuario As Usuario) As String
        Try
            Dim sql As String =
               "INSERT INTO Usuarios (NombreUsuario, Contrasena, Email, Rol, Activo) " &
               "VALUES (@Usuario, @Password, @Email, @Rol, @Activo)"

            Dim parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Usuario", usuario.NombreUsuario),
            New SqlParameter("@Password", usuario.Contrasena),
            New SqlParameter("@Email", usuario.Email),
            New SqlParameter("@Rol", 1),
            New SqlParameter("@Activo", usuario.Activo)
        }

            dbHelper.ExecuteNonQuery(sql, parametros)

        Catch ex As Exception
            Return "Error al registrar el usuario: " & ex.Message
        End Try

        Return "Usuario registrado correctamente."
    End Function
End Class



