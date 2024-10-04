<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargarCodigo.aspx.cs" Inherits="Tp_PromoWeb_Equipo_4A.CargarCodigo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<form class="d-flex justify-content-center mt-5">
        <div>
            <h3 style="margin-top: 50px">Ingresá el código</h3>
        </div>
        <div class="w-100 d-flex">
            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" OnClick="btnSiguiente_Click" CssClass="btn btn-primary"/>
        </div>
         <asp:Literal ID="litAlerta" runat="server"></asp:Literal>
    </form>--%>
    <form class="container d-flex flex-column align-items-center mt-5 p-4" style="max-width: 500px; border: 1px solid #ccc; border-radius: 10px; box-shadow: 0px 4px 12px rgba(0, 0, 0, 0.1);">
        <div class="text-center mb-4">
            <h3 style="margin-top: 20px;">Ingresá el código</h3>
        </div>

        <div class="d-flex justify-content-center w-100 mb-3 ">
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" placeholder="Código"></asp:TextBox>
        </div>

        <div class="w-100 d-flex justify-content-center mb-3">
            <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" OnClick="btnSiguiente_Click" CssClass="btn btn-primary px-5" />
        </div>
        <div class="w-100 text-center">
            <asp:Literal ID="litAlerta" runat="server"></asp:Literal>
        </div>
    </form>

</asp:Content>
