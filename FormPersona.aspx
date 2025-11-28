<%@ Page Title="Gestión de Personas" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPersona.aspx.vb" Inherits="Control_de_Vehiculos.FormPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body {
            background: linear-gradient(135deg, #d8f3dc, #b7e4c7, #95d5b2);
            background-attachment: fixed;
            font-family: 'Segoe UI', sans-serif;
        }

        .card {
            border-radius: 20px !important;
            overflow: hidden;
            border: none;
            box-shadow: 0 8px 22px rgba(0, 0, 0, 0.15);
        }

        /* Encabezados  */
        .card-header {
            background: #2d6a4f !important;
            color: white !important;
            text-align: center;
            font-size: 1.4rem;
            font-weight: bold;
            padding: 15px;
            letter-spacing: 1px;
        }

        /* Inputs */
        .form-control {
            border-radius: 10px;
            border: 1px solid #95d5b2;
            padding: 10px;
            transition: all 0.2s;
        }

        .form-control:focus {
            border-color: #1b4332;
            box-shadow: 0 0 6px rgba(27, 67, 50, 0.4);
        }

        /* Botones */
        .btn-verde {
            background-color: #40916c !important;
            border: none !important;
            color: white !important;
            font-weight: 600;
            border-radius: 10px !important;
            padding: 10px 18px;
            transition: 0.3s;
        }

        .btn-verde:hover {
            background-color: #1b4332 !important;
            transform: translateY(-3px);
            box-shadow: 0 4px 12px rgba(0,0,0,0.25);
        }

        /* Botón eliminar  */
        .btn-danger {
            border-radius: 10px !important;
            padding: 7px 12px;
        }

        /* Tabla */
        .table-dark {
            background: #1b4332 !important;
        }

        .table-hover tbody tr:hover {
            background-color: #d8f3dc !important;
            cursor: pointer;
        }

        .table-light {
            background: #ffffff !important;
        }

        /* Botones del GridView */
        .btn-success {
            background-color: #52b788 !important;
            border: none !important;
        }

        .btn-primary {
            background-color: #2d6a4f !important;
            border: none !important;
        }
    </style>

    <asp:HiddenField ID="editando" runat="server"/> 

    <div class="container mt-4 mb-5">

        <!-- FORMULARIO -->
        <div class="card">
            <div class="card-header">
                Gestión de Personas
            </div>

            <div class="card-body p-4">
                <div class="row g-3">

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

                <!-- BOTONES -->
                <div class="mt-4 d-flex flex-wrap gap-2 justify-content-center">
                    <asp:Button ID="btnMostrar" runat="server" CssClass="btn-verde" Text="Guardar" OnClick="btn_guardar" />
                    <asp:Button ID="btnActualizar" runat="server" CssClass="btn-verde" Text="Actualizar" OnClick="btnActualizar_Click" />
                </div>

                <div class="text-center mt-3">
                    <asp:Label ID="lblMensaje" runat="server" CssClass="fw-bold" Style="color:#1b4332;"></asp:Label>
                </div>
            </div>
        </div>

        <!--LISTADO -->
        <div class="card mt-4">
            <div class="card-header">
                Listado de Personas
            </div>

            <div class="card-body">

                <asp:GridView 
                   ID="gvPersonas" 
                   runat="server" 
                   AutoGenerateColumns="False"
                   DataKeyNames="IdPersona"
                   CssClass="table table-striped table-hover text-center align-middle"
                   OnRowDeleting="gvPersonas_RowDeleting"
                   OnRowEditing="gvPersonas_RowEditing"
                   OnRowUpdating="gvPersonas_RowUpdating"
                   OnRowCancelingEdit="gvPersonas_RowCancelingEdit"
                   OnSelectedIndexChanged="gvPersonas_SelectedIndexChanged">

                    <Columns>
                        <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-success" />
                        <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-primary" />

                        <asp:BoundField DataField="idPersona" HeaderText="ID" Visible="False" ReadOnly="True" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido1" HeaderText="Primer Apellido" />
                        <asp:BoundField DataField="Apellido2" HeaderText="Segundo Apellido" />
                        <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />

                        <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" />
                    </Columns>

                    <HeaderStyle CssClass="table-dark text-white" />
                    <RowStyle CssClass="table-light" />

                </asp:GridView>

            </div>
        </div>

    </div>

</asp:Content>
