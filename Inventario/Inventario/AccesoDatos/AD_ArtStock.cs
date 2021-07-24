using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventario.Models;
using Inventario.ViewModels;
using System.Data.SqlClient;


namespace Inventario.AccesoDatos
{
    public class AD_ArtStock
    {
        //public static bool InsertarArticulo(ArticuloStock articulo)
        //{
        //    bool resultado = false;
        //    string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

        //    SqlConnection cn = new SqlConnection(cadenaConexion);

        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        string consultaSql = "INSERT INTO Articulos VALUES(@NOMBRE_ARTICULO, @MODELO_ARTICULO, @ID_MARCA, @ID_TIPO_ARTICULO, 1, @IMAGEN_ARTICULO)";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@NOMBRE_ARTICULO", articulo.Nombre_articulo);
        //        cmd.Parameters.AddWithValue("@MODELO_ARTICULO", articulo.Modelo_articulo);
        //        cmd.Parameters.AddWithValue("@ID_MARCA", articulo.Id_marca);
        //        cmd.Parameters.AddWithValue("@ID_TIPO_ARTICULO", articulo.Id_tipo_articulo);
        //        cmd.Parameters.AddWithValue("@IMAGEN_ARTICULO", articulo.Imagen_articulo);

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
        public static bool InsertarArticulo(ArticuloStock articulo)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "p_InsertarArticulo";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@NOMBRE_ARTICULO", articulo.Nombre_articulo));
                cmd.Parameters.Add(new SqlParameter("@MODELO_ARTICULO", articulo.Modelo_articulo));
                cmd.Parameters.Add(new SqlParameter("@ID_MARCA", articulo.Id_marca));
                cmd.Parameters.Add(new SqlParameter("@ID_TIPO_ARTICULO", articulo.Id_tipo_articulo));
                cmd.Parameters.Add(new SqlParameter("@HABILITADO_ARTICULO", articulo.Habilitado_articulo));
                cmd.Parameters.Add(new SqlParameter("@IMAGEN_ARTICULO", articulo.Imagen_articulo));


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
        public static int ObtenerArticulo()
        {
            int resultado = 0;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = @"SELECT MAX(A.ID_ARTICULO ) ID FROM ARTICULOS A";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;


                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                        resultado = int.Parse(dr["ID"].ToString());
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

        //public static bool InsertarStock(ArticuloStock articulo, int id_articulo)
        //{
        //    bool resultado = false;
        //    string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

        //    SqlConnection cn = new SqlConnection(cadenaConexion);


        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        string consultaSql = "INSERT INTO MOVIMIENTOS_STOCK VALUES(GETDATE(), @cantidad_mvt,@id_articulo,13,'alta de articulo')";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@cantidad_mvt", articulo.Cantidad_mvt);
        //        cmd.Parameters.AddWithValue("@id_articulo", id_articulo);
        //      // cmd.Parameters.AddWithValue("@observaciones_mvt", articulo.Observaciones_mvt);
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
        public static bool InsertarStock(ArticuloStock articulo, int id_articulo)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);


            try
            {

                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "p_InsertarStock";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@cantidad_mvt", articulo.Cantidad_mvt));
                cmd.Parameters.Add(new SqlParameter("@id_articulo", id_articulo));

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
        public static bool AgregarStock(int Id_articulo, int Cantidad_mvt, string nro_ticket)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "p_actualizar_stock";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@id_articulo", Id_articulo));
                cmd.Parameters.Add(new SqlParameter("@cantidad_ingresada", Cantidad_mvt));
                cmd.Parameters.Add(new SqlParameter("@nro_ticket", nro_ticket));


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

        //public static bool AgregarStock(ArticuloStock articulo)
        //{
        //    bool resultado = false;
        //    string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

        //    SqlConnection cn = new SqlConnection(cadenaConexion);

        //    try
        //    {
        //        SqlCommand cmd = cn.CreateCommand();
        //        cmd.CommandText = "p_actualizar_stock";
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.Add(new SqlParameter("@id_articulo", articulo.Id_articulo));
        //        cmd.Parameters.Add(new SqlParameter("@cantidad_ingresada", articulo.Cantidad_mvt));


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
        public static bool AsignarStock(ArticuloStock articulo)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "p_asignar_articulo";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@id_usuario", articulo.Id_usuario));
                cmd.Parameters.Add(new SqlParameter("@id_articulo", articulo.Id_articulo));
                cmd.Parameters.Add(new SqlParameter("@asignar", articulo.Chk_asignado));
                cmd.Parameters.Add(new SqlParameter("@Nro_ticket", articulo.Nro_ticket));


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
        //public static bool BajaStock(ArticuloStock articulo)
        //{
        //    bool resultado = false;
        //    string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

        //    SqlConnection cn = new SqlConnection(cadenaConexion);

        //    try
        //    {
        //        SqlCommand cmd = cn.CreateCommand();
        //        cmd.CommandText = "p_BajaStock";
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.Add(new SqlParameter("@id_articulo", articulo.Id_articulo));
        //        cmd.Parameters.Add(new SqlParameter("@motivo_baja", articulo.Motivo_baja));


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
        public static bool BajaStock(int Id_articulo, string Motivo_baja, string nro_ticket)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "p_BajaStock";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@id_articulo", Id_articulo));
                cmd.Parameters.Add(new SqlParameter("@motivo_baja", Motivo_baja));
                cmd.Parameters.Add(new SqlParameter("@nro_ticket", nro_ticket));


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
        //public static ArticuloStock ObtenerArtAsignadoUsr(int id_articulo)
        //{
        //    ArticuloStock resultado = new ArticuloStock();
        //    string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

        //    SqlConnection cn = new SqlConnection(cadenaConexion);

        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();

        //        string consulta = @"select A.ID_ARTICULO, 
        //                                    a.Nombre_articulo,
        //                                    a.Modelo_articulo,
        //                                    u.CODIGO_USUARIO
        //                                    from articulos a 
        //                                    left join ARTICULOS_USUARIOS au on a.ID_ARTICULO = au.ID_ARTICULO
        //                                    join MARCAS M on A.ID_MARCA = M.ID_MARCA
        //                                    join TIPOS_ARTICULOS T on A.ID_TIPO_ARTICULO = T.ID_TIPO_ARTICULO
        //                                    LEFT join USUARIOS U on au.ID_USUARIO = U.ID_USUARIO
        //                                    where a.HABILITADO_ARTICULO = 1 
        //                                    and a.id_articulo =@id_articulo";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@id_articulo", id_articulo);

        //        cmd.CommandType = System.Data.CommandType.Text;
        //        cmd.CommandText = consulta;


        //        cn.Open();
        //        cmd.Connection = cn;
        //        SqlDataReader dr = cmd.ExecuteReader();

        //        if (dr != null)
        //        {
        //            while (dr.Read())
        //            {

        //                resultado.Id_articulo = int.Parse(dr["Id_articulo"].ToString());
        //                resultado.Nombre_articulo = dr["Nombre_articulo"].ToString();
        //                resultado.Modelo_articulo = dr["Modelo_articulo"].ToString();
        //                resultado.Codigo_usuario = dr["Codigo_usuario"].ToString();


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
        public static ArticuloStock ObtenerArtAsignadoUsr(int id_articulo)
        {
            ArticuloStock resultado = new ArticuloStock();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta =          @"select A.ID_ARTICULO, 
                                            a.Nombre_articulo,
                                            a.Modelo_articulo,
                                            u.CODIGO_USUARIO,
											SUM(mvt.CANTIDAD_MVT)stock
                                            from articulos a 
                                            left join ARTICULOS_USUARIOS au on a.ID_ARTICULO = au.ID_ARTICULO
                                            join MARCAS M on A.ID_MARCA = M.ID_MARCA
                                            join TIPOS_ARTICULOS T on A.ID_TIPO_ARTICULO = T.ID_TIPO_ARTICULO
                                            LEFT join USUARIOS U on au.ID_USUARIO = U.ID_USUARIO
											join MOVIMIENTOS_STOCK mvt on a.ID_ARTICULO = mvt.ID_ARTICULO
                                            where a.HABILITADO_ARTICULO = 1 
                                            and a.id_articulo = @id_articulo
											GROUP BY A.Id_articulo,
										   A.NOMBRE_ARTICULO,
										   A.MODELO_ARTICULO, 
										   u.CODIGO_USUARIO";
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
                        resultado.Nombre_articulo = dr["Nombre_articulo"].ToString();
                        resultado.Modelo_articulo = dr["Modelo_articulo"].ToString();
                        resultado.Codigo_usuario = dr["Codigo_usuario"].ToString();
                        resultado.Artstock = int.Parse(dr["Stock"].ToString());


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