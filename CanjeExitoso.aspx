<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CanjeExitoso.aspx.cs" Inherits="Tp_PromoWeb_Equipo_4A.CanjeExitoso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container d-flex justify-content-center align-items-start mt-5">
        <div class="text-center">
            <div class="alert alert-success p-4 rounded">
                <h1 class="display-4">🎉 ¡Canje Exitoso! 🎉
            </h1>
                <p class="lead">Ya estás participando!</p>
            </div>
            <asp:Button ID="btnVolver" runat="server" Text="Volver al inicio" CssClass="btn btn-success mt-3" OnClick="btnVolver_Click" />
        </div>
    </div>
</asp:Content>
