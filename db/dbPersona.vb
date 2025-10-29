Imports System.Data.SqlClient

Public Class dbPersona
    Public ReadOnly ConnectionString As String = ConfigurationManager.ConnectionStrings("Progra_lllConnectionString").ConnectionString
    Public Function create(Persona As Persona) As Boolean
        Try
            Dim sql As String = "INSERT INTO Persona (Nombre, Apellido1, Apellido2, Nacionalidad, FechaNacimiento,Telefono ) VALUES (@Nombre, @Apellido1, @Apellido2,  @Nacionalidad,  @FechaNacimiento, @Telefono )"
            Dim Parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Nombre", Persona.Nombre),
            New SqlParameter("@Apellido1", Persona.Apellido1),
            New SqlParameter("@Apellido2", Persona.Apellido2),
            New SqlParameter("@Nacionalidad", Persona.Nacionalidad),
            New SqlParameter("@FechaNacimiento", Persona.FechaNacimiento),
            New SqlParameter("@Telefono", Persona.Telefono)
        }

            Using connetion As New SqlConnection(ConnectionString)
                Using command As New SqlCommand(sql, connetion)
                    command.Parameters.AddRange(Parametros.ToArray())
                    connetion.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Public Function delete(ByRef id As Integer) As String
        Try
            Dim sql As String = "DELETE FROM Persona WHERE ID = @Id"
            Dim Parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Id", id)
        }
            Using connetion As New SqlConnection(ConnectionString)
                Using command As New SqlCommand(sql, connetion)
                    command.Parameters.AddRange(Parametros.ToArray())
                    connetion.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return "Persona eliminada"
    End Function

    Public Function update(ByRef Persona As Persona) As String
        Try
            Dim sql As String = "UPDATE Persona SET Nombre = @Nombre, Apellido1 = @Apellido1,  Apellido2 = @Apellido2 , Nacionalidad =@Nacionalidad, FechaNacimiento =@FechaNacimiento, Telefono=@Telefono WHERE ID = @Id"
            Dim Parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Id", Persona.IdPersona),
            New SqlParameter("@Nombre", Persona.Nombre),
            New SqlParameter("@Apellido", Persona.Apellido1),
            New SqlParameter("@Apellido2", Persona.Apellido2),
            New SqlParameter("@Nacionalidad", Persona.Nacionalidad),
            New SqlParameter("@FechaNacimiento", Persona.FechaNacimiento),
            New SqlParameter("@Telefono", Persona.Telefono)
        }
            Using connetion As New SqlConnection(ConnectionString)
                Using command As New SqlCommand(sql, connetion)
                    command.Parameters.AddRange(Parametros.ToArray())
                    connetion.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return "Persona actualizada"
    End Function

End Class
