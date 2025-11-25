<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Registro.aspx.vb" Inherits="Control_de_Vehiculos.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="card shadow-lg p-4" style="max-width: 400px; width: 100%;">

        <div class="card-body">
            <h2 class="h4 mb-3 text-center">Crear Cuenta</h2>

            <div class="form-floating mb-3">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                <label for="MainContent_txtNombre">Nombre</label>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Email"></asp:TextBox>
                <label for="MainContent_txtEmail">Correo electrónico</label>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                <label for="MainContent_txtPass">Contraseña</label>
            </div>

            <div class="form-floating mb-3">
                <asp:TextBox ID="txtPassConfirm" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirmar contraseña"></asp:TextBox>
                <label for="MainContent_txtPassConfirm">Confirmar contraseña</label>
            </div>

            <asp:Button CssClass="btn btn-primary w-100 py-2" ID="btnRegistrar" runat="server" Text="Registrarse" OnClick="btnRegistrar_Click" />

            <div class="mt-3 text-center">
                <a href="Login.aspx">¿Ya estás registrado?</a>
            </div>

            <asp:Label ID="lblError" runat="server" Text="" CssClass="error"></asp:Label>
        </div>

    </div>

    

</asp:Content>