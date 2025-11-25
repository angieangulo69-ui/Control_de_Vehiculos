<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="Control_de_Vehiculos.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
   <h2 class="text-center">Iniciar Sesión</h2>

    <div class="d-flex justify-content-center">
    <div class="card p-4" style="width: 350px;">
        
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>

        <div class="form-group mt-2">
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group mt-3">
            <asp:Label ID="lblContrasena" runat="server" Text="Contraseña: "></asp:Label>
            <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
        </div>

        <div class="text-center mt-4">
            <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar Sesión"  CssClass="btn btn-success px-4"  OnClick="btnIniciarSesion_Click"/>
        </div>

    </div>
</div>

</asp:Content>
