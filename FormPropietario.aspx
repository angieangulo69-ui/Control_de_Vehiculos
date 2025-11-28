<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPropietario.aspx.vb" Inherits="Control_de_Vehiculos.FormPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card p-4" style="background-color: #d8f3dc; border: 1px solid #95d5b2; border-radius: 10px;">
        <div class="card-body p-4">
            <div class="row g-3">
                <asp:DropDownList ID="ddlPersona" CssClass="form-control" runat="server" >
                    <asp:ListItem Text="Seleccione Persona" Value=""> </asp:ListItem>
                </asp:DropDownList>
                <div class="col-md-4">
                    <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Nombre" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtApellido1" CssClass="form-control" placeholder="Primer Apellido" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtApellido2" CssClass="form-control" placeholder="Segundo Apellido" runat="server"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:TextBox ID="txtNacionalidad" CssClass="form-control" placeholder="Nacionalidad" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtFechaNacimiento" CssClass="form-control" TextMode="Date" placeholder="Fecha de Nacimiento" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtTelefono" CssClass="form-control" placeholder="Teléfono" runat="server"></asp:TextBox>
                </div>             
            </div>
             <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="btn btn-primary" OnClick="btnSeleccionar_Click" />
        </div>
        <div class="mt-4 d-flex flex-wrap gap-2 justify-content-center">
        </div>
    </div>
</asp:Content>
