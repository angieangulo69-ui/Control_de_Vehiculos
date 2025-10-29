Public Class Propietario
    Inherits Persona 'Herencia de persona'
    ' Atributos de la clase Propietario
    Private _idPropietario As Integer
    Private _numVehiculos As String


    'Constructor de la clase Propietario Vacio del objeto Persona, porque hereda de la clase Persona
    Public Sub New()
        MyBase.New()
    End Sub

    'Constructor de la clase Propietario
    Public Sub New(idPropietario As Integer, numVehiculos As String, persona As Persona)
        'Permite ponerle los datos de la clase Persona al constructor de la clase Propietario
        MyBase.New(persona.IdPersona, persona.Nombre, persona.Apellido1, persona.Apellido2, persona.Nacionalidad,
                   persona.FechaNacimiento, persona.Telefono)
        _idPropietario = idPropietario
        _numVehiculos = numVehiculos
    End Sub

    Public Sub New(idPropietario As Integer,
                   numVehiculos As String)
        _idPropietario = idPropietario
        _numVehiculos = numVehiculos
    End Sub


    'Propiedades de la clase Propietario 
    Public Property IdPropietario As Integer
        Get
            Return _idPropietario
        End Get
        Set(value As Integer)
            _idPropietario = value
        End Set
    End Property

    Public Property NumVehiculos As String
        Get
            Return _numVehiculos
        End Get
        Set(value As String)
            _numVehiculos = value
        End Set
    End Property
End Class
