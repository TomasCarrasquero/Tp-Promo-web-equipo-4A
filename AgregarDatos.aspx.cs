using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp_PromoWeb_Equipo_4A
{
    public partial class AgregarDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente a = new Cliente();
                ClienteNegocio negocio = new ClienteNegocio();

                a.Nombre = txtNombre.Text;
                a.Apellido = txtApellido.Text;
                a.Documento = txtDni.Text;
                a.Email = txtEmail.Text;
                a.Direccion = txtDireccion.Text;
                a.Ciudad = txtCiudad.Text;
                a.CP = int.Parse(txtCP.Text);

                negocio.agregar(a);
                Response.Redirect("Catalogo.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
            
        }

    }
}
