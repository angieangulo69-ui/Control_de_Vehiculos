<%@ Page Title="Gestión de Personas" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPersona.aspx.vb" Inherits="Control_de_Vehiculos.FormPersona" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="editando" runat="server"/> 

    <div class="container mt-4 mb-5">
        <div class="card shadow-lg border-0 rounded-4">
            <div class="card-header bg-primary text-white text-center rounded-top-4">
                <h3 class="mb-0">Gestión de Personas</h3>
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
                            
                <div class="mt-4 d-flex flex-wrap gap-2 justify-content-center">
                 <asp:Button ID="btnMostrar" runat="server" CssClass="btn btn-primary btn-hover-move" Text="Guardar" OnClick="btn_guardar" />
                <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-primary btn-hover-move" Text="Actualizar" OnClick="btnActualizar_Click" />
                </div>                                  
                </div>

                <div class="text-center mt-3">
                    <asp:Label ID="lblMensaje" runat="server" CssClass="fw-bold text-primary"></asp:Label>
                </div>
            </div>
        </div>

        <div class="card shadow-lg border-0 rounded-4 mt-4">
            <div class="card-header bg-secondary text-white text-center rounded-top-4">
                <h4 class="mb-0">Listado de Personas</h4>
            </div>
            <div class="card-body">
                <asp:GridView 
                   ID="gvPersonas" 
                   runat="server" 
                   AutoGenerateColumns="False"
                   DataKeyNames="IdPersona"
                   CssClass  ="table table-striped table-hover text-center align-middle"
                   OnRowDeleting="gvPersonas_RowDeleting"
                   OnRowEditing="gvPersonas_RowEditing"
                   OnRowUpdating ="gvPersonas_RowUpdating"
                   OnRowCancelingEdit ="gvPersonas_RowCancelingEdit"
                   OnSelectedIndexChanged="gvPersonas_SelectedIndexChanged">

     <Columns>
      
        <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-success" />
            <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-primary" />
            <asp:BoundField DataField="idPersona" HeaderText="ID" Visible="False" ReadOnly="True" SortExpression="idPersona" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Apellido1" HeaderText="Primer Apellido" SortExpression="Apellido1" />
            <asp:BoundField DataField="Apellido2" HeaderText="Segundo Apellido" SortExpression="Apellido2" />
            <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" SortExpression="Nacionalidad" />
             <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
            <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" />
</Columns>

    <HeaderStyle CssClass="table-dark text-white" />
    <RowStyle CssClass="table-light" />

</asp:GridView>
                
            </div>
        </div>
   
</asp:Content>