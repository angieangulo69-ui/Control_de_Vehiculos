<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPropietario.aspx.vb" Inherits="Control_de_Vehiculos.FormPropietario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body {
            background: linear-gradient(135deg, #d8f3dc, #b7e4c7, #95d5b2);
            font-family: 'Segoe UI', sans-serif;
        }

        .card {
            border-radius: 20px !important;
            border: none !important;
            box-shadow: 0 8px 22px rgba(0,0,0,0.15);
            background: #f1fff4;
        }

        .card-header {
            background: #2d6a4f !important;
            color: white !important;
            font-size: 1.4rem;
            font-weight: bold;
            text-align: center;
            padding: 15px;
        }

        .form-control {
            border-radius: 10px !important;
            border: 1px solid #95d5b2 !important;
            padding: 10px;
            transition: 0.2s;
        }

        .form-control:focus {
            border-color: #1b4332 !important;
            box-shadow: 0 0 6px rgba(0, 80, 40, 0.4);
        }

        .btn-verde {
            background-color: #40916c !important;
            border: none !important;
            color: white !important;
            font-weight: 600;
            border-radius: 10px;
            padding: 10px 20px;
            transition: 0.25s;
        }

        .btn-verde:hover {
            background-color: #1b4332 !important;
            transform: translateY(-3px);
            box-shadow: 0 4px 12px rgba(0,0,0,0.25);
        }
    </style>


    <div class="card p-4">

        <div class="card-header">
            Datos de Propietario
        </div>

        <div class="card-body p-4">

            <div class="row g-3">
    
                <div class="col-md-12">
                    <asp:DropDownList ID="ddlPersona" CssClass="form-control" runat="server">
                        <asp:ListItem Text="Seleccione una Persona" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </div>

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
                    <asp:TextBox ID="txtFechaNacimiento" CssClass="form-control" TextMode="Date" placeholder="Fecha Nacimiento" runat="server"></asp:TextBox>
                </div>

                <div class="col-md-4">
                    <asp:TextBox ID="txtTelefono" CssClass="form-control" placeholder="Teléfono" runat="server"></asp:TextBox>
                </div>

            </div>

            <!-- BOTÓN -->
            <div class="text-center mt-4">
                <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="btn-verde" OnClick="btnSeleccionar_Click" />
            </div>

        </div>
    </div>

</asp:Content>