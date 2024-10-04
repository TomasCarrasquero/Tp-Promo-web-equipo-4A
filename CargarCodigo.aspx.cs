using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Microsoft.Ajax.Utilities;
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
                Response.Redirect("Catalogo.aspx");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtCodigo.Text.Trim()))
                {
                    litAlerta.Text = "<div class='alert alert-danger' role='alert'>Para continuar debe ingresar un código.</div>";

                }
                else
                {
                    litAlerta.Text = "<div class='alert alert-danger' role='alert'>El código es inválido o ya ha sido utilizado.</div>";
                }

            }

        }
        

    }
}