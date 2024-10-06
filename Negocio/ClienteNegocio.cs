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
        public void agregarConSP(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setStoreProcedure("storedAltaCliente");
                datos.setParameters("@documento", cliente.Documento);
                datos.setParameters("@nombre", cliente.Nombre);
                datos.setParameters("@apellido", cliente.Apellido);
                datos.setParameters("@email", cliente.Email);
                datos.setParameters("@direccion", cliente.Direccion);
                datos.setParameters("@ciudad", cliente.Ciudad);
                datos.setParameters("@codigoPostal", cliente.CP);
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
        ///--------------------PRUEBA -----------------------------------------------------
        
        public Cliente buscarPorDNI(string documento)
        {
            AccesoDatos datos = new AccesoDatos();
            Cliente cliente = null;

            try
            {
                datos.setStoreProcedure("storedProcedureBuscarClientePorDNI");
                datos.setParameters("@documento", documento);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    cliente = new Cliente();

                    cliente.Id = datos.Lector.GetInt32(0);

                    cliente.Documento = (string)datos.Lector["Documento"];

                    cliente.Nombre = (string)datos.Lector["Nombre"];

                    cliente.Apellido = (string)datos.Lector["Apellido"];

                    cliente.Email = (string)datos.Lector["Email"];

                    cliente.Direccion = (string)datos.Lector["Direccion"];

                    cliente.Ciudad = (string)datos.Lector["Ciudad"];

                    cliente.CP = datos.Lector.GetInt32(7);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return cliente;
        }

        ///--------------------PRUEBA -----------------------------------------------------
    }
}
