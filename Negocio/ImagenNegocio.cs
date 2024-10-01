using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImagenNegocio
    {
        public void agregar(Imagen ImgNueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                datos.setParameters("@IdArticulo", ImgNueva.ID_Art);
                datos.setParameters("@ImagenUrl", ImgNueva.ID_Imagen);
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
        public List<Imagen> listar()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setQuery("select Id, IdArticulo, ImagenUrl from IMAGENES;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.ID_Imagen = (int)datos.Lector["id"];
                    aux.ID_Art = (int)datos.Lector["IdArticulo"];
                    aux.Url = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }

                return lista;
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
        public void agregarImagen(int idArticulo, string urlImagen)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery($"Insert into IMAGENES (IdArticulo,ImagenUrl) values ({idArticulo}, '{urlImagen}')");
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

        public Imagen obtenerImagenPrincipal(int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            Imagen imagen = new Imagen();
            //int imagen = 0;
            try
            {
                //datos.setQuery($"select TOP 1 Id from IMAGENES where IdArticulo = '{idArticulo}' ORDER BY Id ASC");
                datos.setQuery("select TOP 1 Id, IdArticulo, ImagenUrl from IMAGENES where IdArticulo = @idArt ORDER BY Id ASC");
                datos.setParameters("@idArt", idArticulo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    imagen.ID_Imagen = (int)datos.Lector["Id"];
                    imagen.ID_Art = (int)datos.Lector["IdArticulo"];
                    imagen.Url = (string)datos.Lector["ImagenUrl"];
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

            return imagen;
        }
        public void modificarImagen(int idImagen, string imagenUrl)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery($"update IMAGENES SET ImagenUrl = '{imagenUrl}' WHERE Id = {idImagen}");
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

