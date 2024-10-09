<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="Tp_PromoWeb_Equipo_4A.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%--<%
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
                    <div class="boton">
                        <asp:Button ID="btnElegir" runat="server" Text="Elegir!" CssClass="btn btn-primary" CommandArgument="<%= %>" CommandName="Seleccionar" OnCommand="btnElegir_Command"/>
                    </div>
                </div>
            </div>
        </div>
        <% } %>--%>


        <asp:Repeater runat="server" ID="repetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card" style="width: 18rem;">

                        <div id="cardCarousel_<%# Eval("Id") %>" class="carousel slide card-carousel" data-bs-ride="carousel">
                            <div class="carousel-inner">
                                <asp:Repeater ID="rptImagenes" runat="server" DataSource='<%# Eval("Imagenes") %>'>
                                    <ItemTemplate>
                                        <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                            <img src='<%# Eval("Url") %>' class="d-block w-100" alt="Imagen del artículo">
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <button class="carousel-control-prev" type="button" data-bs-target="#cardCarousel_<%# Eval("Id") %>" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#cardCarousel_<%# Eval("Id") %>" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                            </button>
                        </div>
                        <div class="card-body">
                            <h5 class="card-title"><b><%#Eval("Nombre") %></b> </h5>
                            <div class="boton">
                                <asp:Button ID="btnElegir" runat="server" Text="Elegir!" CssClass="btn btn-primary" CommandArgument='<%#Eval("Id") %>' CommandName="Seleccionar" OnCommand="btnElegir_Command" />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
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

        .boton {
            text-align: center;
            margin-top: auto;
            padding-bottom: 10px;
        }

        .card-carousel img {
            width: 100%;
            height: 200px; 
            object-fit: contain; 
        }

        .carousel-control-prev-icon,
        .carousel-control-next-icon {
              background-color: darkgrey;
        }
    </style>
</asp:Content>
