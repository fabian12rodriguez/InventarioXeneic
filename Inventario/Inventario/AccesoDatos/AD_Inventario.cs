using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventario.Models;
using Inventario.ViewModels;
using System.Data.SqlClient;

namespace Inventario.AccesoDatos
{
    public class AD_Inventario
    {
        public static List<VMInventario> ListarStock()
        {
            List<VMInventario> resultado = new List<VMInventario>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSql =
                   @"select A.NOMBRE_ARTICULO, 
                            A.MODELO_ARTICULO, 
                            M.DESCRIPCION_MARCA, 
                            T.DESCRIPCION_TIPO_ARTICULO, 
                            A.IMAGEN_ARTICULO, 
                            SUM(mvt.CANTIDAD_MVT)stock
                            from articulos a join MOVIMIENTOS_STOCK mvt on a.ID_ARTICULO = mvt.ID_ARTICULO
                            join MARCAS M on A.ID_MARCA = M.ID_MARCA
                            join TIPOS_ARTICULOS T on A.ID_TIPO_ARTICULO  = T.ID_TIPO_ARTICULO
                            where a.HABILITADO_ARTICULO = 1
                            GROUP BY
                            A.NOMBRE_ARTICULO, 
                            A.MODELO_ARTICULO, 
                            A.ID_MARCA,
                            M.DESCRIPCION_MARCA, 
                            A.ID_TIPO_ARTICULO,
                            T.DESCRIPCION_TIPO_ARTICULO, 
                            A.IMAGEN_ARTICULO;";

                cmd.Parameters.Clear();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consultaSql;

                cn.Open();
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        VMInventario aux = new VMInventario();
                      //  aux.Id_articulo = int.Parse(dr["Id_articulo"].ToString());
                        aux.Nombre_articulo = dr["Nombre_articulo"].ToString();
                        aux.Modelo_articulo = dr["Modelo_articulo"].ToString();
                        aux.Desc_marca_articulo = dr["DESCRIPCION_MARCA"].ToString();
                        aux.Desc_tipo_articulo = dr["DESCRIPCION_TIPO_ARTICULO"].ToString();
                        aux.Imagen_articulo = dr["Imagen_articulo"].ToString();
                        aux.Stock = int.Parse(dr["Stock"].ToString());

                        resultado.Add(aux);


                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }

            return resultado;
        }
        public static List<VMInventario> ListarAsignarUsuario()
        {
            List<VMInventario> resultado = new List<VMInventario>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSql =
                   @"select A.ID_ARTICULO, 
                    A.NOMBRE_ARTICULO, 
                    A.MODELO_ARTICULO, 
                    M.DESCRIPCION_MARCA, 
                    T.DESCRIPCION_TIPO_ARTICULO, 
                    u.CODIGO_USUARIO
                    from articulos a left join ARTICULOS_USUARIOS au on a.ID_ARTICULO = au.ID_ARTICULO
                    join MARCAS M on A.ID_MARCA = M.ID_MARCA
                    join TIPOS_ARTICULOS T on A.ID_TIPO_ARTICULO  = T.ID_TIPO_ARTICULO
                    LEFT join USUARIOS U on au.ID_USUARIO = U.ID_USUARIO
                    where a.HABILITADO_ARTICULO = 1;
                    ";

                cmd.Parameters.Clear();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consultaSql;

                cn.Open();
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        VMInventario aux = new VMInventario();
                        aux.Id_articulo = int.Parse(dr["Id_articulo"].ToString());
                        aux.Nombre_articulo = dr["Nombre_articulo"].ToString();
                        aux.Modelo_articulo = dr["Modelo_articulo"].ToString();
                        aux.Desc_marca_articulo = dr["DESCRIPCION_MARCA"].ToString();
                        aux.Desc_tipo_articulo = dr["DESCRIPCION_TIPO_ARTICULO"].ToString();
                        aux.Codigo_usuario = dr["Codigo_usuario"].ToString();

                        resultado.Add(aux);


                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }

            return resultado;
        }
        public static bool InsertarArticulosUsuarios(VMInventario art_usr)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSql = "INSERT INTO Articulos VALUES(@NOMBRE_ARTICULO, @MODELO_ARTICULO, @ID_MARCA, @ID_TIPO_ARTICULO, 1, @IMAGEN_ARTICULO)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id_articulo", art_usr.Id_articulo);
                cmd.Parameters.AddWithValue("@id_usuario", art_usr.Id_usuario);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consultaSql;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }

            return resultado;
        }
        public static bool ActualizarArticulosUsuarios(VMInventario art_usr)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString(); 

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try 
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "UPDATE articulos_usuarios SET Id_articulo = @Id_articulo, id_usuario = @id_usuario where Id_articulo = @Id_articulo and id_usuario = @id_usuario ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id_articulo", art_usr.Id_articulo);
                cmd.Parameters.AddWithValue("@id_usuario", art_usr.Id_usuario);


                cmd.CommandType = System.Data.CommandType.Text; 
                cmd.CommandText = consulta; 


                cn.Open
                ();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception)
            {

                throw;
            }

            finally 
            {
                cn.Close();
            }

            return resultado;
        }
        public static VMInventario ObtenerAsignarArt(int id_articulo)
        {
            VMInventario resultado = new VMInventario();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = @"select A.ID_ARTICULO, 
                                            u.CODIGO_USUARIO
                                            from articulos a 
                                            left join ARTICULOS_USUARIOS au on a.ID_ARTICULO = au.ID_ARTICULO
                                            join MARCAS M on A.ID_MARCA = M.ID_MARCA
                                            join TIPOS_ARTICULOS T on A.ID_TIPO_ARTICULO = T.ID_TIPO_ARTICULO
                                            LEFT join USUARIOS U on au.ID_USUARIO = U.ID_USUARIO
                                            where a.HABILITADO_ARTICULO = 1 and a.id_articulo =@id_articulo";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_articulo", id_articulo);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;


                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                        resultado.Id_articulo = int.Parse(dr["Id_articulo"].ToString());
                        resultado.Codigo_usuario = dr["Codigo_usuario"].ToString();


                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                cn.Close();
            }

            return resultado;
        }
















    }
}