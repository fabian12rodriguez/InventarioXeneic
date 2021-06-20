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
                   @"select A.Id_articulo,
                            A.NOMBRE_ARTICULO, 
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
							A.Id_articulo,
                            A.NOMBRE_ARTICULO, 
                            A.MODELO_ARTICULO, 
                            A.ID_MARCA,
                            M.DESCRIPCION_MARCA, 
                            A.ID_TIPO_ARTICULO,
                            T.DESCRIPCION_TIPO_ARTICULO, 
                            A.IMAGEN_ARTICULO
                            order by 5, 2 ;";

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
        public static List<VMInventario> ListadoInventarioFiltrado(int id_tipo_articulo)
        {
            List<VMInventario> resultado = new List<VMInventario>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = @"select A.Id_articulo,
                            A.NOMBRE_ARTICULO, 
                            A.MODELO_ARTICULO, 
                            M.DESCRIPCION_MARCA, 
                            T.DESCRIPCION_TIPO_ARTICULO, 
                            A.IMAGEN_ARTICULO, 
                            SUM(mvt.CANTIDAD_MVT)stock
                            from articulos a join MOVIMIENTOS_STOCK mvt on a.ID_ARTICULO = mvt.ID_ARTICULO
                            join MARCAS M on A.ID_MARCA = M.ID_MARCA
                            join TIPOS_ARTICULOS T on A.ID_TIPO_ARTICULO  = T.ID_TIPO_ARTICULO
                            where a.HABILITADO_ARTICULO = 1
                            and t.id_tipo_articulo = @id_tipo_articulo
                            GROUP BY
							A.Id_articulo,
                            A.NOMBRE_ARTICULO, 
                            A.MODELO_ARTICULO, 
                            A.ID_MARCA,
                            M.DESCRIPCION_MARCA, 
                            A.ID_TIPO_ARTICULO,
                            T.DESCRIPCION_TIPO_ARTICULO, 
                            A.IMAGEN_ARTICULO
                            order by 5, 2;";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_tipo_articulo", id_tipo_articulo);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;


                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        VMInventario aux = new VMInventario();
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
                   @"select A.Id_articulo,
                            A.NOMBRE_ARTICULO, 
                            A.MODELO_ARTICULO, 
                            M.DESCRIPCION_MARCA, 
                            T.DESCRIPCION_TIPO_ARTICULO, 
                            SUM(mvt.CANTIDAD_MVT)stock
                            from articulos a join MOVIMIENTOS_STOCK mvt on a.ID_ARTICULO = mvt.ID_ARTICULO
                            join MARCAS M on A.ID_MARCA = M.ID_MARCA
                            join TIPOS_ARTICULOS T on A.ID_TIPO_ARTICULO  = T.ID_TIPO_ARTICULO
                            where a.HABILITADO_ARTICULO = 1
                            GROUP BY
							A.Id_articulo,
                            A.NOMBRE_ARTICULO, 
                            A.MODELO_ARTICULO, 
                            M.DESCRIPCION_MARCA, 
                            T.DESCRIPCION_TIPO_ARTICULO
                            order by 5,2;";

 /*               @"select A.ID_ARTICULO, 
                    A.NOMBRE_ARTICULO, 
                    A.MODELO_ARTICULO, 
                    M.DESCRIPCION_MARCA, 
                    T.DESCRIPCION_TIPO_ARTICULO
                    from articulos a
                    join MARCAS M on A.ID_MARCA = M.ID_MARCA
                    join TIPOS_ARTICULOS T on A.ID_TIPO_ARTICULO  = T.ID_TIPO_ARTICULO
                    where a.HABILITADO_ARTICULO = 1;
                    ";
*/

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
        //public static bool InsertarArticulosUsuarios(VMInventario art_usr)
        //{
        //    bool resultado = false;
        //    string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

        //    SqlConnection cn = new SqlConnection(cadenaConexion);

        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        string consultaSql = "INSERT INTO Articulos VALUES(@NOMBRE_ARTICULO, @MODELO_ARTICULO, @ID_MARCA, @ID_TIPO_ARTICULO, 1, @IMAGEN_ARTICULO)";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@Id_articulo", art_usr.Id_articulo);
        //        cmd.Parameters.AddWithValue("@id_usuario", art_usr.Id_usuario);

        //        cmd.CommandType = System.Data.CommandType.Text;
        //        cmd.CommandText = consultaSql;

        //        cn.Open();
        //        cmd.Connection = cn;
        //        cmd.ExecuteNonQuery();
        //        resultado = true;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //        cn.Close();
        //    }

        //    return resultado;
        //}
        public static VMInventario ObtenerArtAsignado(int id_articulo)
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
                                            where a.HABILITADO_ARTICULO = 1 
                                            and a.id_articulo =@id_articulo";
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
        public static List<TipoUsuarios> ListarTipoUsuarios()
        {
            List<TipoUsuarios> resultado = new List<TipoUsuarios>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSql =
                    @"SELECT id_usuario, codigo_usuario FROM usuarios;";

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
                        TipoUsuarios aux = new TipoUsuarios();
                        aux.Id_usuario = int.Parse(dr["Id_usuario"].ToString());
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
        public static List<VMInventario> ListarTipoUsuariosArt(int id_articulo)
        {
            List<VMInventario> resultado = new List<VMInventario>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = @"select u.CODIGO_USUARIO, au.ID_ARTICULO, a.NOMBRE_ARTICULO, a.MODELO_ARTICULO
                                    from usuarios u left join ARTICULOS_USUARIOS au on u.ID_USUARIO = au.ID_USUARIO
				                    left join ARTICULOS a on a.ID_ARTICULO = au.ID_ARTICULO
				                    where a.ID_ARTICULO = @id_articulo
                                    and u.id_usuario <> 13";
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
                        VMInventario aux = new VMInventario();
                        aux.Codigo_usuario = dr["Codigo_usuario"].ToString();
                        aux.Nombre_articulo = dr["Nombre_articulo"].ToString();
                        aux.Modelo_articulo = dr["Modelo_articulo"].ToString();
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
        public static bool ActualizarArticuloAsignado(VMInventario articulo)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "UPDATE articulos_usuarios SET id_usuario = @id_usuario where Id_articulo = @Id_articulo";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id_articulo", articulo.Id_articulo);
                cmd.Parameters.AddWithValue("@id_usuario", articulo.Id_usuario);
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
        /******************
         * 
         * 
         * 
         * 
         * ****************/
        //public static List<VMInventario> ListarArticulos()
        //{
        //    List<VMInventario> resultado = new List<VMInventario>();
        //    string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

        //    SqlConnection cn = new SqlConnection(cadenaConexion);

        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        string consultaSql =
        //            @"select A.ID_ARTICULO, A.NOMBRE_ARTICULO, A.MODELO_ARTICULO, A.ID_MARCA,M.DESCRIPCION_MARCA, T.ID_TIPO_ARTICULO,T.DESCRIPCION_TIPO_ARTICULO, A.IMAGEN_ARTICULO
        //                from ARTICULOS A, MARCAS M , TIPOS_ARTICULOS T
        //                WHERE A.ID_MARCA = M.ID_MARCA
        //                AND A.ID_TIPO_ARTICULO  = T.ID_TIPO_ARTICULO";

        //        cmd.Parameters.Clear();

        //        cmd.CommandType = System.Data.CommandType.Text;
        //        cmd.CommandText = consultaSql;

        //        cn.Open();
        //        cmd.Connection = cn;

        //        SqlDataReader dr = cmd.ExecuteReader();

        //        if (dr != null)
        //        {
        //            while (dr.Read())
        //            {
        //                VMInventario aux = new VMInventario();
        //                aux.Id_articulo = int.Parse(dr["Id_articulo"].ToString());
        //                aux.Nombre_articulo = dr["Nombre_articulo"].ToString();
        //                aux.Modelo_articulo = dr["Modelo_articulo"].ToString();
        //                aux.Desc_marca_articulo = dr["DESCRIPCION_MARCA"].ToString();
        //                aux.Desc_tipo_articulo = dr["DESCRIPCION_TIPO_ARTICULO"].ToString();
        //                aux.Imagen_articulo = dr["Imagen_articulo"].ToString();


        //                resultado.Add(aux);


        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //        cn.Close();
        //    }

        //    return resultado;
        //}
        public static List<VMInventario> ListarArticulos()
        {
            List<VMInventario> resultado = new List<VMInventario>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSql =
                    @"select A.ID_ARTICULO, A.NOMBRE_ARTICULO, A.MODELO_ARTICULO, A.ID_MARCA,M.DESCRIPCION_MARCA, T.ID_TIPO_ARTICULO,T.DESCRIPCION_TIPO_ARTICULO, A.Habilitado_articulo,A.IMAGEN_ARTICULO
                        from ARTICULOS A, MARCAS M , TIPOS_ARTICULOS T
                        WHERE A.ID_MARCA = M.ID_MARCA
                        AND A.ID_TIPO_ARTICULO  = T.ID_TIPO_ARTICULO";

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
                        aux.Habilitado_articulo = bool.Parse(dr["Habilitado_articulo"].ToString());
                        aux.Imagen_articulo = dr["Imagen_articulo"].ToString();


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
        public static bool InsertarArticulo(VMInventario articulo)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSql = "INSERT INTO Articulos VALUES(@NOMBRE_ARTICULO, @MODELO_ARTICULO, @ID_MARCA, @ID_TIPO_ARTICULO,@HABILITADO_ARTICULO,@IMAGEN_ARTICULO)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@NOMBRE_ARTICULO", articulo.Nombre_articulo);
                cmd.Parameters.AddWithValue("@MODELO_ARTICULO", articulo.Modelo_articulo);
                cmd.Parameters.AddWithValue("@ID_MARCA", articulo.Id_marca);
                cmd.Parameters.AddWithValue("@ID_TIPO_ARTICULO", articulo.Id_tipo_articulo);
                cmd.Parameters.AddWithValue("@HABILITADO_ARTICULO", articulo.Habilitado_articulo);
                cmd.Parameters.AddWithValue("@IMAGEN_ARTICULO", articulo.Imagen_articulo);

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
        /*public static VMInventario ObtenerArticulo(int id_articulo)
        {
            VMInventario resultado = new VMInventario();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM Articulos WHERE id_articulo =@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id_articulo);

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
                        resultado.Nombre_articulo = dr["Nombre_articulo"].ToString();
                        resultado.Modelo_articulo = dr["Modelo_articulo"].ToString();
                        resultado.Id_marca = int.Parse(dr["Id_marca"].ToString());
                        resultado.Id_tipo_articulo = int.Parse(dr["Id_tipo_articulo"].ToString());
                        resultado.Imagen_articulo = dr["Imagen_articulo"].ToString();


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
        }*/

        public static VMInventario ObtenerArticulo(int id_articulo)
        {
            VMInventario resultado = new VMInventario();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = @"SELECT A.Id_articulo,
                                            A.NOMBRE_ARTICULO,
                                           A.MODELO_ARTICULO,
                                           A.ID_MARCA,
                                           A.ID_TIPO_ARTICULO,
                                           A.HABILITADO_ARTICULO,
                                           A.IMAGEN_ARTICULO,
                                           SUM(mvt.CANTIDAD_MVT) stock
                                           from articulos a join MOVIMIENTOS_STOCK mvt on a.ID_ARTICULO = mvt.ID_ARTICULO
                                           where A.Id_articulo =@id
                                           GROUP BY A.Id_articulo,
                                           A.NOMBRE_ARTICULO,
                                           A.MODELO_ARTICULO,
                                           A.ID_MARCA,
                                           A.ID_TIPO_ARTICULO,
                                           A.HABILITADO_ARTICULO,
                                           A.IMAGEN_ARTICULO";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id_articulo);

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
                        resultado.Nombre_articulo = dr["Nombre_articulo"].ToString();
                        resultado.Modelo_articulo = dr["Modelo_articulo"].ToString();
                        resultado.Id_marca = int.Parse(dr["Id_marca"].ToString());
                        resultado.Id_tipo_articulo = int.Parse(dr["Id_tipo_articulo"].ToString());
                        resultado.Habilitado_articulo = bool.Parse(dr["Habilitado_articulo"].ToString());
                        resultado.Imagen_articulo = dr["Imagen_articulo"].ToString();
                        resultado.Stock = int.Parse(dr["Stock"].ToString());

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



        //public static bool ActualizarDatosArticulos(VMInventario articulo)
        //{
        //    bool resultado = false;
        //    string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
        //    SqlConnection cn = new SqlConnection(cadenaConexion);

        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();

        //        string consulta = "UPDATE articulos SET Nombre_articulo = @Nombre_articulo, Modelo_articulo = @Modelo_articulo, Id_marca = @Id_marca, Id_tipo_articulo = @Id_tipo_articulo, Imagen_articulo = @Imagen_articulo where Id_articulo = @Id_articulo";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@Id_articulo", articulo.Id_articulo);
        //        cmd.Parameters.AddWithValue("@Nombre_articulo", articulo.Nombre_articulo);
        //        cmd.Parameters.AddWithValue("@Modelo_articulo", articulo.Modelo_articulo);
        //        cmd.Parameters.AddWithValue("@Id_marca", articulo.Id_marca);
        //        cmd.Parameters.AddWithValue("@Id_tipo_articulo", articulo.Id_tipo_articulo);
        //        cmd.Parameters.AddWithValue("@Imagen_articulo", articulo.Imagen_articulo);

        //        cmd.CommandType = System.Data.CommandType.Text;
        //        cmd.CommandText = consulta;
        //        cn.Open
        //        ();
        //        cmd.Connection = cn;
        //        cmd.ExecuteNonQuery();
        //        resultado = true;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    finally
        //    {
        //        cn.Close();
        //    }

        //    return resultado;
        //}
        public static bool ActualizarDatosArticulos(VMInventario articulo)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);


            try
            {

                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "p_ActualizarArticulo";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@Id_articulo", articulo.Id_articulo));
                cmd.Parameters.Add(new SqlParameter("@Nombre_articulo", articulo.Nombre_articulo));
                cmd.Parameters.Add(new SqlParameter("@Modelo_articulo", articulo.Modelo_articulo));
                cmd.Parameters.Add(new SqlParameter("@Id_marca", articulo.Id_marca));
                cmd.Parameters.Add(new SqlParameter("@Id_tipo_articulo", articulo.Id_tipo_articulo));
                cmd.Parameters.Add(new SqlParameter("@habilitado_articulo", articulo.Id_tipo_articulo));
                cmd.Parameters.Add(new SqlParameter("@Imagen_articulo", articulo.Imagen_articulo));

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
        public static List<VMInventario> ListarHistorialArt(int id_articulo)
        {
            List<VMInventario> resultado = new List<VMInventario>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = @" select distinct H.FECHA_HISTORIAL,
		                                    A.NOMBRE_ARTICULO,
		                                    a.MODELO_ARTICULO,
		                                    m.CANTIDAD_MVT Stock,
		                                    u.CODIGO_USUARIO, 
		                                    au.nro_ticket, 
		                                    h.OBSERVACIONES_HISTORIAL
                                    from HISTORIAL_ARTICULOS h 
                                    JOIN MOVIMIENTOS_STOCK M on m.ID_MVT = h.ID_MVT
                                    LEFT JOIN ARTICULOS_USUARIOS au on m.ID_ARTICULO = au.ID_ARTICULO
                                    JOIN USUARIOS u on u.ID_USUARIO = m.id_usuario
                                    LEFT JOIN ARTICULOS a on a.ID_ARTICULO = m.ID_ARTICULO
                                    where H.ID_ARTICULO = @id_articulo
                                    order by h.FECHA_HISTORIAL;";
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
                        VMInventario aux = new VMInventario();
                        aux.Fecha_historial= dr["Fecha_historial"].ToString();
                        aux.Nombre_articulo = dr["Nombre_articulo"].ToString();
                        aux.Modelo_articulo = dr["Modelo_articulo"].ToString();
                        aux.Cantidad_mvt = int.Parse(dr["Stock"].ToString());
                        aux.Codigo_usuario = dr["Codigo_usuario"].ToString();
                        aux.Nro_ticket = dr["Nro_ticket"].ToString();
                        aux.Observaciones_historial = dr["Observaciones_historial"].ToString();
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















    }
}