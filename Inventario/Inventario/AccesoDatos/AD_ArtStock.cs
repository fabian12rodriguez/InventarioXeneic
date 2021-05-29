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
        public static bool InsertarArticulo(ArticuloStock articulo)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSql = "INSERT INTO Articulos VALUES(@NOMBRE_ARTICULO, @MODELO_ARTICULO, @ID_MARCA, @ID_TIPO_ARTICULO, 1, @IMAGEN_ARTICULO)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@NOMBRE_ARTICULO", articulo.Nombre_articulo);
                cmd.Parameters.AddWithValue("@MODELO_ARTICULO", articulo.Modelo_articulo);
                cmd.Parameters.AddWithValue("@ID_MARCA", articulo.Id_marca);
                cmd.Parameters.AddWithValue("@ID_TIPO_ARTICULO", articulo.Id_tipo_articulo);
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

        public static bool InsertarStock(ArticuloStock articulo, int id_articulo)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);


            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSql = "INSERT INTO MOVIMIENTOS_STOCK VALUES(GETDATE(), @cantidad_mvt,@id_articulo,'alta de articulo' )";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cantidad_mvt", articulo.Cantidad_mvt);
                cmd.Parameters.AddWithValue("@id_articulo", id_articulo);
              // cmd.Parameters.AddWithValue("@observaciones_mvt", articulo.Observaciones_mvt);
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

    }
}