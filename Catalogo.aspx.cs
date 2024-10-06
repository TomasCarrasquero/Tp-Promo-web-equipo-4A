using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Tp_PromoWeb_Equipo_4A
{
    public partial class Catalogo : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["codigo"] == null)
            {
                Response.Redirect("Error.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    ListaArticulos = negocio.listarConSP();
                    repetidor.DataSource = ListaArticulos;
                    repetidor.DataBind();
                }
            }
        }
        protected void btnElegir_Command(object sender, CommandEventArgs e)
        {
            int articuloId = Convert.ToInt32(e.CommandArgument);
            Session.Add("IdArticulo", articuloId);
            Response.Redirect("AgregarDatos.aspx");
        }

        protected void repetidor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ImagenNegocio negocioImagen = new ImagenNegocio();
            Articulo articulo = (Articulo)e.Item.DataItem;
            Imagen imgPrincipal = negocioImagen.obtenerImagenPrincipal(articulo.Id);
            Image imgArticulo = (Image)e.Item.FindControl("imgArticulo");

            if (imgPrincipal != null)
            {
                imgArticulo.ImageUrl = imgPrincipal.Url;
            }
            else
            {
                imgArticulo.ImageUrl = "https://image.freepik.com/vector-gratis/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg";
            }
        }
    }
}