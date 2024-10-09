using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Tp_PromoWeb_Equipo_4A
{
    public partial class Catalogo : System.Web.UI.Page
    {
        public List<Articulo> articulos { get; set; }
        public ArticuloNegocio negocio { get; set; } = new ArticuloNegocio();

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
                    articulos = negocio.listarConSP();
                    CargarImagenes();

                    repetidor.DataSource = articulos;
                    repetidor.DataBind();
                }
            }
        }

        private void CargarImagenes()
        {
            foreach (var articulo in articulos)
            {
                try
                {
                    var imagenesArticulo = negocio.listaImagenesXArt(articulo);

                    if (imagenesArticulo.Any())
                    {
                        articulo.Imagenes = negocio.listaImagenesXArt(articulo);
                    }
                    else
                    {
                        articulo.Imagenes = new List<Imagen> { new Imagen() { Url = "https://image.freepik.com/vector-gratis/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg" } };
                    }
                }
                catch
                {
                    Console.WriteLine("Ocurrió un error cargando imagenes de articulo " + articulo.Id);
                }
            }
        }

        protected void btnElegir_Command(object sender, CommandEventArgs e)
        {
            int articuloId = Convert.ToInt32(e.CommandArgument);
            Session.Add("IdArticulo", articuloId);
            Response.Redirect("AgregarDatos.aspx");
        }
    }
}