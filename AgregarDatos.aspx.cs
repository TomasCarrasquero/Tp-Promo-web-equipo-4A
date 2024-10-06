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
                string codigo = (string)Session["codigo"];
                int IdArticulo = (int)Session["IdArticulo"];
                ClienteNegocio negocio = new ClienteNegocio();
                CodigoNegocio codNegocio = new CodigoNegocio();
                Cliente clienteExistente = negocio.buscarPorDNI(txtDni.Text);

                if (clienteExistente == null)
                {

                    Cliente nuevoCliente = new Cliente();
                    nuevoCliente.Nombre = txtNombre.Text;
                    nuevoCliente.Apellido = txtApellido.Text;
                    nuevoCliente.Documento = txtDni.Text;
                    nuevoCliente.Email = txtEmail.Text;
                    nuevoCliente.Direccion = txtDireccion.Text;
                    nuevoCliente.Ciudad = txtCiudad.Text;
                    nuevoCliente.CP = int.Parse(txtCP.Text);
                    negocio.agregarConSP(nuevoCliente);

                    EnviarMail(nuevoCliente);

                    Cliente cliente = negocio.buscarPorDNI(nuevoCliente.Documento);
                    codNegocio.ModificarVoucherConSP(codigo, cliente.Id, IdArticulo);

                }
                else
                {

                    if (Session["codigo"] == null || Session["IdArticulo"] == null)
                    {
                        Response.Redirect("Error.aspx", false);
                    }
                    else
                    {
                        codNegocio.ModificarVoucherConSP(codigo, clienteExistente.Id, IdArticulo);
                    }

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

        private void EnviarMail(Cliente cliente)
        {   

            if (string.IsNullOrEmpty(cliente.Email))
            {
                return;
            }

            string nombreApellido = cliente.Apellido + ", " + cliente.Nombre;
            string emaildestino = cliente.Email;

            EmailService emailService = new EmailService();
            emailService.armarMail(emaildestino, nombreApellido);
            try
            {
                emailService.enviarEmail();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}
