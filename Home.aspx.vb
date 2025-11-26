Public Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Validar si la sesión existe y es un objeto Usuario
        If Session("Usuario") Is Nothing OrElse Not TypeOf Session("Usuario") Is Usuario Then
            Response.Redirect("Login.aspx") ' Redirige si no ha iniciado sesión
            Return
        End If

        Dim UsuarioObj As Usuario = CType(Session("Usuario"), Usuario)

        lblNombre.Text = "Bienvenido " & UsuarioObj.NombreUsuario
        lblEmail.Text = "Correo Electrónico: " & UsuarioObj.Email

    End Sub

End Class