using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listarClientesConSP()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Cliente> lista = new List<Cliente>();

            try
            {
                datos.setStoreProcedure("storedProcedureListarClientes"); //Query: CREATE PROCEDURE storedProcedureListarClientes AS SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Documento = (string)datos.Lector["Documento"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Direccion = (string)datos.Lector["Direccion"];
                    aux.Ciudad = (string)datos.Lector["Ciudad"];
                    aux.CP = datos.Lector.GetInt32(0);

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void agregar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setQuery("INSERT INTO Clientes (Nombre, Apellido, Documento, Email, Direccion, Ciudad, CP) VALUES('" + cliente.Nombre + ", '" + cliente.Apellido + ", '" + cliente.Documento + ", '" + cliente.Email + ", '" + cliente.Direccion + ", '" + cliente.Ciudad + ", '" + cliente.CP);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
