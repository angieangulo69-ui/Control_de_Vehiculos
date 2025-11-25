Public Class Admin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Usuario As String = Session("Usuario")
        If Usuario Is Nothing Or Usuario = "" Then
            Response.Redirect("Login.aspx")
            Return
        End If

    End Sub

End Class