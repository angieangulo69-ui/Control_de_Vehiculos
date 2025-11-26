Imports System.Data.SqlClient
Imports System.Security.Cryptography.X509Certificates

Public Class dbPersona
    'Cadena de conexión desde Web.config'
    Public ReadOnly ConnectionString As String = ConfigurationManager.ConnectionStrings("Progra_lllConnectionString").ConnectionString


    'Método para crear una nueva Persona
    Public Function create(Persona As Persona) As Boolean
        Try
            Dim sql As String = "INSERT INTO Personas (Nombre, Apellido1, Apellido2, Nacionalidad, FechaNacimiento,Telefono ) VALUES (@Nombre, @Apellido1, @Apellido2,  @Nacionalidad,  @FechaNacimiento, @Telefono )"
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
            Return True
        Catch ex As Exception
            ''Return "Error al guardar la persona: " & ex.Message
            Return False
        End Try

        Return True
    End Function

    'Método para eliminar una Persona por ID
    Public Function delete(ByRef id As Integer) As Boolean

        Try
            Dim sql As String = "DELETE FROM Personas WHERE IdPersona = @IdPersona"
            Dim Parametros As New List(Of SqlParameter) From {
            New SqlParameter("@IdPersona", id)
        }
            Using connetion As New SqlConnection(ConnectionString)
                Using command As New SqlCommand(sql, connetion)
                    command.Parameters.AddRange(Parametros.ToArray())
                    connetion.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

            Return True

        Catch ex As Exception
        End Try
        Return False
    End Function

    'Método para actualizar una Persona
    Public Function update(ByRef Persona As Persona) As Boolean

        Try
            Dim sql As String = "UPDATE Personas SET Nombre = @Nombre, Apellido1 = @Apellido1,  Apellido2 = @Apellido2 , 
                                Nacionalidad =@Nacionalidad, FechaNacimiento =@FechaNacimiento, Telefono=@Telefono WHERE IdPersona = @IdPersona"

            Dim Parametros As New List(Of SqlParameter) From {
            New SqlParameter("@IdPersona", Persona.IdPersona),
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
            Return True
        Catch ex As Exception
        End Try
        Return False
    End Function

    'Método para leer todas las Personas
    Public Function readAll() As DataTable
        Dim datos_tabla As New DataTable()
        Try
            Dim sql As String = "SELECT * FROM Personas ORDER BY IdPersona DESC"
            Using connection As New SqlConnection(ConnectionString)
                Using command As New SqlCommand(sql, connection)
                    Dim adapter As New SqlDataAdapter(command)
                    adapter.Fill(datos_tabla)
                End Using
            End Using
        Catch ex As Exception

        End Try
        Return datos_tabla
    End Function

    Public Function Consulta() As DataTable
        Dim sql As String = "SELECT *, CONCAT(Nombre, ' ', Apellido1,' ',Apellido2,' ') AS NombreCompleto FROM Personas"

        ' Crear instancia de DbHelper
        Dim db As New DbHelper()

        ' Llamar al método de instancia
        Return db.ExecuteDataTable(sql, New List(Of SqlParameter)())
    End Function
End Class
