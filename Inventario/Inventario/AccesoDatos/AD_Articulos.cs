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
                    @"SELECT I.IdInstrumento, I.Nombre, I.Descripcion, I.Stock, I.Precio, I.IdTipo, T.Nombre AS 'Tipo'
                        FROM Instrumentos I
                        INNER JOIN Tipos T ON I.IdTipo = T.IdTipo";

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
                        Instrumento aux = new Instrumento();
                        aux.IdInstrumento = int.Parse(dr["IdInstrumento"].ToString());
                        aux.Nombre = dr["Nombre"].ToString();
                        aux.Descripcion = dr["Descripcion"].ToString();
                        aux.Stock = int.Parse(dr["Stock"].ToString());
                        aux.Precio = float.Parse(dr["Precio"].ToString());
                        aux.IdTipo = int.Parse(dr["IdTipo"].ToString());
                        aux.Tipo = dr["Tipo"].ToString();

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

        public static List<TipoItemVM> ListarTipos()
        {
            List<TipoItemVM> resultado = new List<TipoItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSql = "SELECT IdTipo, Nombre FROM Tipos";
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
                        TipoItemVM aux = new TipoItemVM();
                        aux.IdTipo = int.Parse(dr["IdTipo"].ToString());
                        aux.Nombre = dr["Nombre"].ToString();
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

        public static bool InsertarInstrumento(Instrumento instrumento)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();
                string consultaSql = "INSERT INTO Instrumentos VALUES(@instrumento, @descripcion, @stock, @precio, @tipo)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@instrumento", instrumento.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", instrumento.Descripcion);
                cmd.Parameters.AddWithValue("@stock", instrumento.Stock);
                cmd.Parameters.AddWithValue("@precio", instrumento.Precio);
                cmd.Parameters.AddWithValue("@tipo", instrumento.IdTipo);

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