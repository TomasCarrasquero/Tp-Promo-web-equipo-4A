using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp_PromoWeb_Equipo_4A
{
    public partial class CargarCodigo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string codigoVoucher = Request.Form["codigo"];

            if (ValidarCodigoVoucher(codigoVoucher))
            { 
                Response.Redirect("SeleccionPremio.aspx");
            }
            else
            {
                Response.Write("<script>alert('El código es inválido o ya ha sido utilizado.');</script>");
            }
        }

        private bool ValidarCodigoVoucher(string codigo)
        {
            bool codigoEsValido = false;

            string connectionString = "PROMOS_DB";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Vouchers WHERE CodigoVoucher = @CodigoVoucher AND FechaCanje IS NULL";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CodigoVoucher", codigo);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                codigoEsValido = count > 0;
            }

            return codigoEsValido;
        }
    }
}