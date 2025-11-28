<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Home.aspx.vb" Inherits="Control_de_Vehiculos.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style>
    /* Fondo dinámico con movimiento suave */
    body {
        background: linear-gradient(135deg, #52b788, #40916c, #2d6a4f);
        background-size: 300% 300%;
        animation: gradientMove 10s ease infinite;
        font-family: 'Segoe UI', sans-serif;
    }

    @keyframes gradientMove {
        0% { background-position: 0% 50%; }
        50% { background-position: 100% 50%; }
        100% { background-position: 0% 50%; }
    }

    /* Tarjeta */
    .info-card {
        background: #ffffff;
        color: #1b4332;
        max-width: 550px;
        margin: 70px auto;
        padding: 35px;
        border-radius: 20px;
        box-shadow: 0 8px 25px rgba(0, 0, 0, 0.20);
        text-align: center;
        animation: fadeIn 0.9s ease;
    }

    @keyframes fadeIn {
        from { opacity: 0; transform: translateY(20px); }
        to { opacity: 1; transform: translateY(0); }
    }

    .title {
        font-size: 30px;
        font-weight: bold;
        color: #2d6a4f;
    }

    .subtitle {
        font-size: 18px;
        margin-top: 12px;
        color: #40916c;
    }

    .label-text {
        font-weight: bold;
        color: #1b4332;
    }
</style>

<!-- TARJETA DE BIENVENIDA -->
<div class="info-card">
    <div class="title">¡Bienvenid@!</div>

    <div class="subtitle">
        <span class="label-text">Nombre:</span>
        <asp:Label ID="lblNombre" runat="server"></asp:Label>
    </div>

    <div class="subtitle">
        <span class="label-text">Correo Electrónico:</span>
        <asp:Label ID="lblEmail" runat="server"></asp:Label>
    </div>

    <hr />

    <p style="color:#2d6a4f; font-size:16px;">
        Sistema de Control de Vehículos  — administración sencilla y moderna
    </p>
</div>


</asp:Content>
