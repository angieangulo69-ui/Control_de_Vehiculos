Imports System.Data.SqlClient

Public Class FormPropietario
    Inherits System.Web.UI.Page
    Protected DbHelper As New DbHelper



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then ' Primera vez que se carga la página
            CargarPersona()
        End If


    End Sub

    Private Sub CargarPersona()
        Dim db As New DbHelper()
        Dim dt As DataTable = db.ExecuteDataTable("SELECT IdPersona, CONCAT(Nombre, ' ', Apellido1, ' ', Apellido2) AS NombreCompleto FROM Personas", New List(Of SqlParameter)())

        ddlPersona.DataSource = dt
        ddlPersona.DataTextField = "NombreCompleto"
        ddlPersona.DataValueField = "IdPersona"
        ddlPersona.DataBind()
        ddlPersona.Items.Insert(0, New ListItem("--Seleccione--", "0"))
    End Sub



    Protected Sub btnSeleccionar_Click(sender As Object, e As EventArgs)
        If ddlPersona.SelectedValue = "0" Then
            ' Limpiar campos si no se selecciona ninguna persona
            txtNombre.Text = ""
            txtApellido1.Text = ""
            txtApellido2.Text = ""
            txtNacionalidad.Text = ""
            txtFechaNacimiento.Text = ""
            txtTelefono.Text = ""
            Return
        End If

        Dim db As New DbHelper()
        Dim idPersona As Integer = Convert.ToInt32(ddlPersona.SelectedValue)
        Dim dt As DataTable = db.ConsultarPorId(idPersona)

        If dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)
            txtNombre.Text = row("Nombre").ToString()
            txtApellido1.Text = row("Apellido1").ToString()
            txtApellido2.Text = row("Apellido2").ToString()
            txtNacionalidad.Text = row("Nacionalidad").ToString()
            txtFechaNacimiento.Text = Convert.ToDateTime(row("FechaNacimiento")).ToString("yyyy-MM-dd")
            txtTelefono.Text = row("Telefono").ToString()
        End If
    End Sub
End Class