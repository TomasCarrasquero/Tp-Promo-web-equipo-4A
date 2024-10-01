using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {

        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            try
            {
                AccesoDatos datos = new AccesoDatos();

                datos.setQuery("SELECT Id, Descripcion FROM MARCAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.ID_Marca = datos.Lector.GetInt32(0);
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void agregar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setQuery("INSERT INTO MARCAS (Descripcion) VALUES('" + marca.Descripcion + "');");
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
        public void modificar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("UPDATE MARCAS SET Descripcion = @Descripcion WHERE Id = @ID_Marca");
                datos.setParameters("@ID_Marca", marca.ID_Marca);
                datos.setParameters("@Descripcion", marca.Descripcion);
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
        public void eliminar(int Id)
            //ELIMINACION FISICA. BORRA REGISTROS DIRECTAMENTE EN LA BASE DE DATOS.
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setQuery("DELETE FROM MARCAS WHERE Id = @ID_Marca");
                datos.setParameters("@ID_Marca", Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
