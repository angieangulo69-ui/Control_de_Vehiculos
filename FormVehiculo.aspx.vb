Public Class FormVehiculo
    Inherits System.Web.UI.Page
    Public Vehiculo As New Vehiculo()
    'Protected dbVehiculo As New dbVehiculo()
    'Protected dbPropietario As New dbPropietario()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("IdPersona") IsNot Nothing Then
                Dim idPersona As Integer = Convert.ToInt32(Request.QueryString("IdPersona"))
                ''txtIdPersona.Text = idPersona ' O cargar los datos si quieres
            End If
        End If
    End Sub

End Class