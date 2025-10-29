Public Class FormPersona
    Inherits System.Web.UI.Page
    'Atributos  
    Public Persona As New Persona()
    Protected dbHelper As New dbPersona()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub btn_guardar(sender As Object, e As EventArgs)

        Persona.Nombre = txtNombre.Text
        Persona.Apellido1 = txtApellido1.Text
        Persona.Apellido2 = txtApellido2.Text
        Persona.Nacionalidad = txtNacionalidad.Text
        Persona.Telefono = txtTelefono.Text
        Persona.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text)

        If dbHelper.create(Persona) Then
            lblMensaje.Text = "Persona creada"
            txtNombre.Text = ""
            txtApellido1.Text = ""
            txtNombre.Text = ""
            txtApellido1.Text = ""
            txtApellido2.Text = ""
            txtTelefono.Text = ""
            txtNacionalidad.Text = ""
        Else
            lblMensaje.Text = "Ocurrio un error"
            End If

            gvPersonas.DataBind()

        End Sub

        Protected Sub gvPersonas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

            Try
                Dim id As Integer = Convert.ToInt32(gvPersonas.DataKeys(e.RowIndex).Value)
                dbHelper.delete(id)
                e.Cancel = True
                gvPersonas.DataBind()
            Catch ex As Exception
                lblMensaje.Text = "Error al eliminar la persona: " & ex.Message
            End Try

        End Sub

        Protected Sub gvPersonas_RowEditing(sender As Object, e As GridViewEditEventArgs)




    End Sub

        Protected Sub gvPersonas_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)

            gvPersonas.EditIndex = -1
            gvPersonas.DataBind()


        End Sub

        Protected Sub gvPersonas_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)


            Dim id As Integer = Convert.ToInt32(gvPersonas.DataKeys(e.RowIndex).Value)
        Dim persona As Persona = New Persona With {
            .Nombre = e.NewValues("Nombre"),
            .Apellido1 = e.NewValues("Apellido1"),
            .Apellido2 = e.NewValues("Apellido2"),
           .Nacionalidad = e.NewValues("Nacionalidad"),
            .FechaNacimiento = e.NewValues("FechaNacimiento"),
            .Telefono = e.NewValues("Telefono"),
            .IdPersona = id
        }
        dbHelper.update(persona)
            gvPersonas.DataBind()
            e.Cancel = True
            gvPersonas.EditIndex = -1

        End Sub

        Protected Sub gvPersonas_SelectedIndexChanged(sender As Object, e As EventArgs)

            Dim row As GridViewRow = gvPersonas.SelectedRow()
        Dim id As Integer = Convert.ToInt32(gvPersonas.DataKeys(row.RowIndex).Value)
        Dim persona As Persona = New Persona()

        txtNombre.Text = row.Cells(1).Text
        txtApellido1.Text = row.Cells(2).Text
        txtApellido2.Text = row.Cells(3).Text
        txtNacionalidad.Text = row.Cells(4).Text
        txtFechaNacimiento.Text = row.Cells(5).Text
        txtTelefono.Text = row.Cells(6).Text
        editando.Value = id

    End Sub

        Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)


        Dim persona As Persona = New Persona With {
            .Nombre = txtNombre.Text(),
            .Apellido1 = txtApellido1.Text(),
            .Apellido2 = txtApellido2.Text(),
            .Nacionalidad = txtNacionalidad.Text(),
            .Telefono = txtTelefono.Text(),
            .IdPersona = Convert.ToInt32(editando.Value)
        }
        dbHelper.update(persona)
            gvPersonas.DataBind()
            gvPersonas.EditIndex = -1

        End Sub
    End Class


