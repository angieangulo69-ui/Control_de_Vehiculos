Public Class Propietario
    Inherits Persona 'Herencia de persona'
    'Atributos de la clase Propietarios'
    Private _IdPropietarios As Integer
    Private _Nombre As String
    Private _Telefono As Integer

    Public Property IdPropietarios As Integer
        Get
            Return _IdPropietarios
        End Get
        Set(value As Integer)
            _IdPropietarios = value
        End Set
    End Property

    Public Property Nombre1 As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
        End Set
    End Property

    Public Property Telefono1 As Integer
        Get
            Return _Telefono
        End Get
        Set(value As Integer)
            _Telefono = value
        End Set
    End Property

    'Constructor de la clase Propietarios'
    Public Sub New(idPropietarios As Integer, nombre As String, telefono As Integer)
        Me.IdPropietarios = idPropietarios
        Me.Nombre = nombre
        Me.Telefono = telefono
    End Sub
    'Constructor vacio de la clase Propietarios'
    Public Sub New()
    End Sub
    'Propiedades de la clase Propietarios'

End Class
