﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargarCodigo.aspx.cs" Inherits="Tp_PromoWeb_Equipo_4A.CargarCodigo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form class="d-flex justify-content-center mt-5">
        <div>
            <h3 style="margin-top: 50px">Ingresá el código</h3>
        </div>
        <div class="w-50 d-flex">
<%--            <input type="text" id="codigo" class="form-control me-2" placeholder="XXXXXXX-XXXXXXX">--%>
            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
<%--            <button type="submit" onclick="btnSiguiente_Click" class="btn btn-primary">Siguiente</button>--%>
            <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" OnClick="btnSiguiente_Click" CssClass="btn btn-primary" CommandName="" CommandArgument="" />
        </div>
    </form>
</asp:Content>
