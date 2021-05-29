using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Inventario.Models;
using Inventario.ViewModels;

namespace Inventario.AccesoDatos
{
    public class AD_Articulos
    {
        public static List<Articulo> ListarArticulos()
        {
            List<Articulo> resultado = new List<Articulo>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSql =
                    @"select A.ID_ARTICULO, A.NOMBRE_ARTICULO, A.MODELO_ARTICULO, A.ID_MARCA,M.DESCRIPCION_MARCA, T.ID_TIPO_ARTICULO,T.DESCRIPCION_TIPO_ARTICULO, A.IMAGEN_ARTICULO
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
                        Articulo aux = new Articulo();
                        aux.Id_articulo = int.Parse(dr["Id_articulo"].ToString());
                        aux.Nombre_articulo = dr["Nombre_articulo"].ToString();
                        aux.Modelo_articulo = dr["Modelo_articulo"].ToString();
                        aux.Desc_marca_articulo = dr["DESCRIPCION_MARCA"].ToString();
                        aux.Desc_tipo_articulo = dr["DESCRIPCION_TIPO_ARTICULO"].ToString();
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
        public static bool InsertarArticulo(Articulo articulo)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSql = "INSERT INTO Articulos VALUES(@NOMBRE_ARTICULO, @MODELO_ARTICULO, @ID_MARCA, @ID_TIPO_ARTICULO, @IMAGEN_ARTICULO)";
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

          
        public static List<TipoMarca> ListarTipoMarcas()
        {
            List<TipoMarca> resultado = new List<TipoMarca>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSql = "SELECT Id_marca, Descripcion_marca FROM Marcas";
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
                        TipoMarca aux = new TipoMarca();
                        aux.Id_marca = int.Parse(dr["Id_marca"].ToString());
                        aux.Descripcion_marca = dr["Descripcion_marca"].ToString();
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
        public static List<TipoArticulo> ListarTipoArticulos()
        {
            List<TipoArticulo> resultado = new List<TipoArticulo>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSql = "SELECT Id_tipo_articulo, Descripcion_tipo_articulo FROM tipos_articulos";
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
                        TipoArticulo aux = new TipoArticulo();
                        aux.Id_tipo_articulo = int.Parse(dr["Id_tipo_articulo"].ToString());
                        aux.Descripcion_tipo_articulo = dr["Descripcion_tipo_articulo"].ToString();
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
        public static List<Marca> ListarMarcas()
        {
            List<Marca> resultado = new List<Marca>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSql =
                    @"SELECT Id_marca, Descripcion_marca FROM Marcas;";

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
                        Marca aux = new Marca();
                        aux.Id_marca = int.Parse(dr["Id_marca"].ToString());
                        aux.Descripcion_marca = dr["Descripcion_marca"].ToString();

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
        public static bool InsertarMarca(Marca marca)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSql = "INSERT INTO Marcas VALUES(@DESCRIPCION_MARCA)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DESCRIPCION_MARCA", marca.Descripcion_marca);

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
        public static Articulo ObtenerArticulo(int id_articulo)
        {
            Articulo resultado = new Articulo();
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
        }
        public static bool ActualizarDatosArticulos(Articulo articulo)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString(); 
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try 
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "UPDATE articulos SET Nombre_articulo = @Nombre_articulo, Modelo_articulo = @Modelo_articulo, Id_marca = @Id_marca, Id_tipo_articulo = @Id_tipo_articulo, Imagen_articulo = @Imagen_articulo where Id_articulo = @Id_articulo";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id_articulo", articulo.Id_articulo);
                cmd.Parameters.AddWithValue("@Nombre_articulo", articulo.Nombre_articulo);
                cmd.Parameters.AddWithValue("@Modelo_articulo", articulo.Modelo_articulo);
                cmd.Parameters.AddWithValue("@Id_marca", articulo.Id_marca);
                cmd.Parameters.AddWithValue("@Id_tipo_articulo", articulo.Id_tipo_articulo);
                cmd.Parameters.AddWithValue("@Imagen_articulo", articulo.Imagen_articulo);

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
        public static Marca ObtenerMarca(int id_marca)
        {
            Marca resultado = new Marca();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM marcas WHERE id_marca =@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id_marca);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;


                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {

                        resultado.Id_marca = int.Parse(dr["Id_marca"].ToString());
                        resultado.Descripcion_marca = dr["Descripcion_marca"].ToString();
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
        public static bool ActualizarDatosMarcas(Marca marca)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();
            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "UPDATE marcas SET Descripcion_marca = @Descripcion_marca where Id_marca = @Id_marca";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id_marca", marca.Id_marca);
                cmd.Parameters.AddWithValue("@Descripcion_marca", marca.Descripcion_marca);
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












    }
}