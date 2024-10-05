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
                ArticuloNegocio negocio = new ArticuloNegocio();
                ListaArticulos = negocio.listarConSP();
            }
        }

        protected void btnElegir_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarDatos.aspx");
        }
    }
}