<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="Tp_PromoWeb_Equipo_4A.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            
            <div class="row row-cols-1 row-cols-md-3 g-4">
                <%
                    Negocio.ArticuloNegocio negocio = new  Negocio.ArticuloNegocio();
                    List<Dominio.Imagen> ListaImg = new List<Dominio.Imagen>();
                    foreach (Dominio.Articulo art in ListaArticulos)
                    {
                        ListaImg = negocio.listaImagenesXArt(art);
                %>  <div class="col">
                        <div class="card imgAjustada">
                            <img src="<%:ListaImg[0].Url %>" class="img-thumbnail">
                            <div class="card-body">
                                <h5 class="card-title" style="color: black; text-align: center;"> <b><%: art.Nombre %></b> </h5>
                                <p class="card-text" style="color: #4675b9; text-align: center;"><%:"$" + art.Precio %></p>
<%--                                <asp:Button />--%>
                            </div>
                        </div>
                    </div> 
                <% } %>
            </div>
<style>
    .img-thumbnail {
    width: auto;
    height: auto;
    }
    .imgAjustada {
        width: 250px; 
        height: 380px;
    }
</style>
</asp:Content>
