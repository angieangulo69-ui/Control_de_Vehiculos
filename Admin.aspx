<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Admin.aspx.vb" Inherits="Control_de_Vehiculos.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2> Panel de Administración </h2>
    <asp:AccessDataSource runat="server" />
    <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
   <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
</asp:Content>
