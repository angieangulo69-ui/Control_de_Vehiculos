<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPersona.aspx.vb" Inherits="Control_de_Vehiculos.FormPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="editando" runat="server"/> 

<div class="container d-flex flex-column mb-3 gap-2">

    <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Nombre" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtApellido1" CssClass="form-control" placeholder="Apellido1" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtApellido2" CssClass="form-control" placeholder="Apellido2" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtNacionalidad" CssClass="form-control" placeholder="Nacionalidad" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtFechaNacimiento" CssClass="form-control" TextMode="Date" placeholder="Fecha de Nacimiento" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtTelefono" CssClass="form-control" placeholder="Telefono" runat="server"></asp:TextBox>
    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    

    <asp:Button ID="btnMostrar" runat="server" CssClass="btn btn-primary btn-hover-move" Text="Guardar" OnClick="btn_guardar" />
    <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-primary btn-hover-move" Text="Actualizar" OnClick="btnActualizar_Click" />

    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

</div>
<asp:GridView ID="gvPersonas" CssClass="table table-striped table-hover table-success" runat="server" AutoGenerateColumns="False"
    DataSourceID="SqlDataSource1" DataKeyNames="ID" 
    OnRowDeleting="gvPersonas_RowDeleting" 
    OnRowEditing="gvPersonas_RowEditing" 
    OnRowCancelingEdit="gvPersonas_RowCancelingEdit" 
    OnRowUpdating="gvPersonas_RowUpdating" 
    OnSelectedIndexChanged="gvPersonas_SelectedIndexChanged">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
        <asp:BoundField DataField="Apellido1" HeaderText="Apellido1" SortExpression="Apellido1" />
        <asp:BoundField DataField="Apellido2" HeaderText="Apellido2" SortExpression="Apellido2" />
        <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" SortExpression="Nacionalidad" />
        <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" SortExpression="FechaNacimiento" />
        <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
        

        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            
        
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Progra_lllConnectionString %>" ProviderName="<%$ ConnectionStrings:Progra_lllConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Personas]"></asp:SqlDataSource>
 
</asp:Content>
