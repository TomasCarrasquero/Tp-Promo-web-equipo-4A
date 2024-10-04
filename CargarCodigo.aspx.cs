using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Tp_PromoWeb_Equipo_4A
{
    public partial class CargarCodigo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            CodigoNegocio negocio = new CodigoNegocio();
            
            string codigoVoucher = txtCodigo.Text;

            if (negocio.ValidarCodigoVoucher(codigoVoucher))
            {
                Response.Redirect("SeleccionPremio.aspx");
            }
            else
            {
                //Response.Write("<script>alert('El código es inválido o ya ha sido utilizado.');</script>");
                litAlerta.Text = "<div class='alert alert-danger' role='alert'>El código es inválido o ya ha sido utilizado.</div>";
            }

        }
        

    }
}