<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="Tp_PromoWeb_Equipo_4A.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%
            Negocio.ArticuloNegocio negocio = new Negocio.ArticuloNegocio();
            List<Dominio.Imagen> ListaImg = new List<Dominio.Imagen>();
            foreach (Dominio.Articulo art in ListaArticulos)
            {
                ListaImg = negocio.listaImagenesXArt(art);
                string imgUrl = ListaImg.Count > 0 ? ListaImg[0].Url : "https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png"; 
        %>
        <div class="col">
            <div class="card tarjeta">
                <img src="<%= imgUrl %>" class="img-thumbnail img-fluid">
                <div class="card-body">
                    <h5 class="card-title"> <b><%= art.Nombre %></b> </h5>
<%--                    <p class="card-text"><%= "$" + art.Descripcion %></p>--%>
                    <div class="boton">
                        <asp:Button ID="btnElegir" runat="server" Text="Elegir!" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
        <% } %>
    </div>

    <style>
        .img-thumbnail {
            width: 100%;
            height: 200px; 
            object-fit: contain; 
        }
        .tarjeta {
            width: 230px;
            height: 350px;
        }
        .boton{
            text-align: center;
            margin-top: auto; 
            padding-bottom: 10px;
        }

    </style>
</asp:Content>
