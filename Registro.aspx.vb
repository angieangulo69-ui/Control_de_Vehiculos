Imports Control_de_Vehiculos.Utils

Public Class Registro
    Inherits System.Web.UI.Page

    Protected dbHelper As New dbLogin()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Nada por ahora
    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim nombreUsuario As String = txtNombre.Text.Trim()
        Dim email As String = txtEmail.Text.Trim()
        Dim password As String = txtPass.Text
        Dim confirmPassword As String = txtPassConfirm.Text

        ' Validar contraseñas
        If password <> confirmPassword Then
            SwalUtils.ShowSwalError(Me, "Error", "Las contraseñas no coinciden.")
            Exit Sub
        End If

        ' Encriptar contraseña
        Dim encrypter As New Simple3Des("MiClaveSecreta123")
        Dim passEncrypted As String = encrypter.EncryptData(password)

        ' Crear objeto usuario
        Dim usuario As New Usuario(nombreUsuario, passEncrypted, txtEmail.Text)
        usuario.Rol = "Usuario"
        usuario.Activo = True

        ' Registrar en BD
        Dim mensaje As String = dbHelper.RegisterUser(usuario)

        If mensaje.ToLower().Contains("error") Then
            SwalUtils.ShowSwalError(Me, "Error", mensaje)
        Else
            Dim script As String = "Swal.fire({ title: 'Registro exitoso',text: 'Tu cuenta ha sido creada correctamente.', icon: 'success', confirmButtonText: 'Ir al login'}).then(function() {window.location = 'Login.aspx';});"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SwalRedirect", script, True)
        End If
    End Sub

End Class
