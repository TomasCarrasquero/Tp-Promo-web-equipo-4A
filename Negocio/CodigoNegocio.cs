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

                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("IdCliente"))))
                        cod.IdCLiente = datos.Lector.GetInt32(datos.Lector.GetOrdinal("IdCliente"));
                    else
                        cod.IdCLiente = -1;

                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("FechaCanje"))))
                        cod.FechaCanje = (DateTime)datos.Lector["FechaCanje"];
                    else
                        cod.FechaCanje = DateTime.MinValue;

                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("IdArticulo"))))
                        cod.IdArticulo = datos.Lector.GetInt32(datos.Lector.GetOrdinal("IdArticulo"));
                    else
                        cod.IdArticulo = -1;

                    //  if (!(datos.Lector["IdCliente"] is DBNull))
                    //      cod.IdCLiente = datos.Lector.GetInt32(1);
                    //  int num = -1;    
                    //  cod.IdCLiente = num;
                    //      if (!(datos.Lector["FechaCanje"] is DBNull))
                    //          cod.FechaCanje = (DateTime)datos.Lector["FechaCanje"];
                    //  if (!(datos.Lector["IdArticulo"] is DBNull))
                    //      cod.IdArticulo = datos.Lector.GetInt32(3);

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
            List<Codigo> listaCodigos = listarCodigosConSP();

            foreach (Codigo cod in listaCodigos)
            {
                if (codigo == cod.CodigoVoucher)
                {
                    if (cod.FechaCanje == DateTime.MinValue && cod.IdArticulo == -1 && cod.IdCLiente == -1)
                    {
                        codigoEsValido = true;
                        return codigoEsValido;
                    }
                    else
                    {
                        return codigoEsValido;  
                    }
                }
            }
            return codigoEsValido;
        }
    }
}
