Imports System.Data.SqlClient

Public Class FormPersona
    Inherits System.Web.UI.Page

    'Instancia de la clase Persona
    Public Persona As New Persona()
    Protected dbHelper As New dbPersona()
    'Carga la apgina
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarPersonas()
            btnActualizar.Visible = False
        End If
    End Sub

    'Método para guardar una nueva persona desde los TextBox
    Protected Sub btn_guardar(sender As Object, e As EventArgs)

        Try
            Dim persona As New Persona With {
                .Nombre = txtNombre.Text.Trim(),
                .Apellido1 = txtApellido1.Text.Trim(),
                .Apellido2 = txtApellido2.Text.Trim(),
                .Nacionalidad = txtNacionalidad.Text.Trim(),
                .Telefono = txtTelefono.Text.Trim(),
                .FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text)
            }

            If dbHelper.create(Persona) Then
                lblMensaje.Text = "Persona creada"
                LimpiarCampos()
                CargarPersonas()
            Else
                lblMensaje.Text = "Ocurrio un error"
            End If
        Catch ex As Exception
            lblMensaje.Text = " Error: " & ex.Message
        End Try

    End Sub
    'Método para eliminar una fila del GridView
    Protected Sub gvPersonas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

        Try
            Dim id As Integer = Convert.ToInt32(gvPersonas.DataKeys(e.RowIndex).Value)
            dbHelper.delete(id)
            lblMensaje.Text = "Persona eliminada"
            CargarPersonas() 'Acutalizar el GridView'
            e.Cancel = True

        Catch ex As Exception
            lblMensaje.Text = "Error al eliminar la persona: " & ex.Message
        End Try

    End Sub
    'Método para editar una fila del GridView
    Protected Sub gvPersonas_RowEditing(sender As Object, e As GridViewEditEventArgs)

        Try
            gvPersonas.EditIndex = e.NewEditIndex
            CargarPersonas()
        Catch ex As Exception
            lblMensaje.Text = " Error al editar: " & ex.Message
        End Try
    End Sub



    '   Método para cargar las personas en el GridView
    Private Sub CargarPersonas()
        Try
            Dim dt As New DataTable()
            Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("Progra_lllConnectionString").ConnectionString)
                Dim sql As String = "SELECT * FROM Personas"
                Using cmd As New SqlCommand(sql, conn)
                    conn.Open()
                    dt.Load(cmd.ExecuteReader())
                End Using
            End Using

            gvPersonas.DataSource = dt
            gvPersonas.DataBind()
        Catch ex As Exception
            lblMensaje.Text = "Error al cargar personas: " & ex.Message
        End Try
    End Sub
    'Método para cancelar la edición de una fila en el GridView
    Protected Sub gvPersonas_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)

        gvPersonas.EditIndex = -1
        CargarPersonas()


    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        LimpiarCampos()
        lblMensaje.Text = " Campos limpiados"
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        LimpiarCampos()
        btnActualizar.Visible = False
        btnMostrar.Visible = True
        editando.Value = ""
        lblMensaje.Text = "Edición cancelada"
    End Sub

    Protected Sub btnCargar_Click(sender As Object, e As EventArgs)
        CargarPersonas()
        lblMensaje.Text = " Lista de personas actualizada"
    End Sub

    Private Sub LimpiarCampos()
        ' Limpia los TextBox del formulario
        txtNombre.Text = String.Empty
        txtApellido1.Text = String.Empty
        txtApellido2.Text = String.Empty
        txtNacionalidad.Text = String.Empty
        txtFechaNacimiento.Text = String.Empty
        txtTelefono.Text = String.Empty

        ' Limpia el campo oculto de edición
        editando.Value = String.Empty

        ' Restablece el estado de los botones
        btnMostrar.Visible = True
        btnActualizar.Visible = False

        ' Limpia el mensaje en pantalla
        lblMensaje.Text = ""
    End Sub

    'Método para actualizar una fila editada en el GridView
    Protected Sub gvPersonas_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)

        Try
            Dim id As Integer = Convert.ToInt32(gvPersonas.DataKeys(e.RowIndex).Value)
            Dim persona As Persona = New Persona With {
                .IdPersona = id,
                .Nombre = e.NewValues("Nombre"),
                .Apellido1 = e.NewValues("Apellido1"),
                .Apellido2 = e.NewValues("Apellido2"),
               .Nacionalidad = e.NewValues("Nacionalidad"),
                .FechaNacimiento = e.NewValues("FechaNacimiento"),
                .Telefono = e.NewValues("Telefono")
            }

            If dbHelper.update(persona) Then
                lblMensaje.Text = "Persona actualizada correctamente"
            Else
                lblMensaje.Text = "Error al actualizar la persona"
            End If

            gvPersonas.EditIndex = -1
            CargarPersonas()
            lblMensaje.Text = "Persona actualizada ."
        Catch ex As Exception
            lblMensaje.Text = " Error al actualizar: " & ex.Message
        End Try

    End Sub
    'Método para seleccionar una fila en el GridView
    Protected Sub gvPersonas_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim id As Integer = Convert.ToInt32(gvPersonas.SelectedDataKey.Value)

            Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("Progra_lllConnectionString").ConnectionString)
                Dim sql As String = "SELECT * FROM Personas WHERE IdPersona = @IdPersona"
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@IdPersona", id)
                    conn.Open()
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            ' Cargar los datos en los campos de texto
                            txtNombre.Text = dr("Nombre").ToString()
                            txtApellido1.Text = dr("Apellido1").ToString()
                            txtApellido2.Text = dr("Apellido2").ToString()
                            txtNacionalidad.Text = dr("Nacionalidad").ToString()
                            txtTelefono.Text = dr("Telefono").ToString()
                            txtFechaNacimiento.Text = Convert.ToDateTime(dr("FechaNacimiento")).ToString("yyyy-MM-dd")

                            ' Guardar el id seleccionado para actualizar
                            editando.Value = id.ToString()

                            ' Cambiar visibilidad de botones
                            btnMostrar.Visible = False
                            btnActualizar.Visible = True

                            lblMensaje.Text = "Modo edición: Persona seleccionada (ID " & id & ")"
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            lblMensaje.Text = " Error al seleccionar: " & ex.Message
        End Try
    End Sub
    'Método para actualizar una persona desde los TextBox
    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Try
            If String.IsNullOrEmpty(editando.Value) OrElse Not IsNumeric(editando.Value) Then
                lblMensaje.Text = " No se ha seleccionado una persona para actualizar."
                Exit Sub
            End If

            'Crear el objeto Persona con los datos actualizados
            Dim persona As Persona = New Persona With {
             .IdPersona = Convert.ToInt32(editando.Value),
            .Nombre = txtNombre.Text.Trim(),
            .Apellido1 = txtApellido1.Text().Trim(),
            .Apellido2 = txtApellido2.Text().Trim(),
            .Nacionalidad = txtNacionalidad.Text(),
            .Telefono = txtTelefono.Text().Trim()
        }
            'Asignar la fecha de nacimiento si no está vacía
            If Not String.IsNullOrEmpty(txtFechaNacimiento.Text) Then
                persona.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text)
            End If
            'Actualizar la persona en la base de datos
            dbHelper.update(persona)

            lblMensaje.Text = "Persona actualizada correctamente."
            LimpiarCampos()
            CargarPersonas()

        Catch ex As Exception
            lblMensaje.Text = "Error al actualizar: " & ex.Message
        End Try
    End Sub
End Class


