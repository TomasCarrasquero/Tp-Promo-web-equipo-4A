using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CodigoNegocio
    {
        public List<Codigo> listarCodigosConSP()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Codigo> lista = new List<Codigo>();

            try
            {
                datos.setStoreProcedure("storedProcedureListarCodigo");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Codigo cod = new Codigo();
                    cod.CodigoVoucher = (string)datos.Lector["CodigoVoucher"];
                    if(!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("IdCliente"))))
                        cod.IdCLiente = datos.Lector.GetInt32(1);
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("FechaCanje"))))
                        cod.FechaCanje = (DateTime)datos.Lector["FechaCanje"];
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("IdArticulo"))))
                        cod.IdArticulo = datos.Lector.GetInt32(3);

                    lista.Add(cod);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ValidarCodigoVoucher(string codigo)
        {

            bool codigoEsValido = false;

            List<Codigo> listaCodigos = new List<Codigo>();
            listaCodigos = listarCodigosConSP();

            foreach (Codigo cod in listaCodigos)
            {
                if(codigo == cod.CodigoVoucher)
                {
                    if(cod.FechaCanje == null){
                        codigoEsValido = true;
                        return codigoEsValido;
                    }
                    return codigoEsValido;
                }
                    
            }
            return codigoEsValido;


            //string connectionString = "PROMOS_DB";

            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    string query = "SELECT COUNT(*) FROM Vouchers WHERE CodigoVoucher = @CodigoVoucher AND FechaCanje IS NULL";
            //    SqlCommand cmd = new SqlCommand(query, conn);
            //    cmd.Parameters.AddWithValue("@CodigoVoucher", codigo);

            //    conn.Open();
            //    int count = (int)cmd.ExecuteScalar();
            //    codigoEsValido = count > 0;
            //}
        }
    }
}
