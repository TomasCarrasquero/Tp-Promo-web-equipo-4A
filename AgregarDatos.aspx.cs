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
            if (Session["codigo"] == null)
            {
                Response.Redirect("Error.aspx");
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteNegocio negocio = new ClienteNegocio();
                Cliente clienteExistente = negocio.buscarPorDNI(txtDni.Text);

                if (clienteExistente == null)
                {
                    Cliente nuevoCliente = new Cliente
                    {
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        Documento = txtDni.Text,
                        Email = txtEmail.Text,
                        Direccion = txtDireccion.Text,
                        Ciudad = txtCiudad.Text,
                        CP = int.Parse(txtCP.Text)
                    };

                    negocio.agregarConSP(nuevoCliente);
                }

                Response.Redirect("CanjeExitoso.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }


        //-------------------------- PRUEBA------------------------------------------------
        protected void txtDni_TextChanged(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            string dni = txtDni.Text;

            Cliente cliente = negocio.buscarPorDNI(dni);

            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtEmail.Text = cliente.Email;
                txtDireccion.Text = cliente.Direccion;
                txtCiudad.Text = cliente.Ciudad;
                txtCP.Text = cliente.CP.ToString();
            }
            else
            {
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtEmail.Text = "";
                txtDireccion.Text = "";
                txtCiudad.Text = "";
                txtCP.Text = "";
            }
        }
//-------------------------- PRUEBA------------------------------------------------

    }
}
