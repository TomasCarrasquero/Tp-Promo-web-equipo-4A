using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        
        AccesoDatos datos = new AccesoDatos();
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            try
            {
                datos.setQuery("SELECT A.Id ,Codigo, Nombre, A.Descripcion, M.Descripcion AS 'Marca', C.Descripcion AS 'Categoría', Precio FROM ARTICULOS A, MARCAS M , CATEGORIAS C where M.Id = A.IdMarca and A.IdCategoria = c.Id");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoría"];
                    aux.Precio = datos.Lector.GetDecimal(6);

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Imagen> listaImagenesXArt(Articulo art)
        {
            List<Imagen> lista = new List<Imagen>();

            try
            {
                datos.setQuery("SELECT id, IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo = " + art.Id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Imagen imagen = new Imagen();
                    imagen.ID_Imagen = datos.Lector.GetInt32(0);
                    imagen.ID_Art = datos.Lector.GetInt32(1);
                    imagen.Url = (string)datos.Lector["ImagenUrl"];


                    lista.Add(imagen);
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

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT A.Id ,Codigo, Nombre, A.Descripcion, M.Descripcion AS 'Marca', C.Descripcion AS 'Categoría', Precio FROM ARTICULOS A, MARCAS M , CATEGORIAS C where M.Id = A.IdMarca and A.IdCategoria = c.Id And ";
                switch (campo)
                {
                    case "CodigoArticulo":
                       switch (criterio)
                        {
                            case "Contiene ":
                                consulta += "Codigo like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con ":
                                consulta += "Nombre like '" + filtro + "%' ";
                                break;
                            case "Termina con ":
                                consulta += "Nombre like '%" + filtro + "'";
                                break;
                            case "Contiene ":
                                consulta += "Nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Marca":
                        switch (criterio)
                        {
                            case "Comienza con ":
                                consulta += "M.Descripcion like '" + filtro + "%' ";
                                break;
                            case "Termina con ":
                                consulta += "M.Descripcion like '%" + filtro + "'";
                                break;
                            case "Contiene ":
                                consulta += "M.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Categoría":
                        switch (criterio)
                        {
                            case "Comienza con ":
                                consulta += "C.Descripcion like '" + filtro + "%' ";
                                break;
                            case "Termina con ":
                                consulta += "C.Descripcion like '%" + filtro + "'";
                                break;
                            case "Contiene ":
                                consulta += "C.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    default:
                        break;
                }
                datos.setQuery(consulta);
                datos.ejecutarLectura();
                
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoría"];
                    aux.Precio = datos.Lector.GetDecimal(6);

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setQuery("DELETE FROM ARTICULOS WHERE Id = @Id");
                datos.setParameters("@Id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("Insert into ARTICULOS (Codigo,Nombre, Descripcion , IdMarca, IdCategoria, Precio) values ('" + nuevo.CodigoArticulo + "', '" + nuevo.Nombre + "','" + nuevo.Descripcion + "' , @IDMarca , @IDCategoria , @Precio)");
                datos.setParameters("@IDMarca", nuevo.Marca.ID_Marca);
                datos.setParameters("@IDCategoria", nuevo.Categoria.ID_Categoria);
                datos.setParameters("@Precio", nuevo.Precio);
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

        public void modificar(Articulo articuloParaModificar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery("update ARTICULOS SET Codigo = @Cod, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio  WHERE Id = @ID");
                datos.setParameters("@Cod", articuloParaModificar.CodigoArticulo);
                datos.setParameters("@Nombre", articuloParaModificar.Nombre);
                datos.setParameters("@Descripcion", articuloParaModificar.Descripcion);
                datos.setParameters("@IdMarca", articuloParaModificar.Marca.ID_Marca);
                datos.setParameters("@IdCategoria", articuloParaModificar.Categoria.ID_Categoria);
                datos.setParameters("@Precio", articuloParaModificar.Precio);
                datos.setParameters("@ID", articuloParaModificar.Id);
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

        public bool validarCodigoExistente(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery($"select 1 from ARTICULOS where Codigo = '{codigo}'");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return false;
                }

                return true;
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

        public int obtenerIdArticuloPorCodigo(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setQuery($"select Id from ARTICULOS where Codigo = '{codigo}'");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return (int)datos.Lector["Id"];
                }

                throw new Exception("Codigo articulo invalido");
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

