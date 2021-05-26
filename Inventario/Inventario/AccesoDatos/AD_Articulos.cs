﻿using System;
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
                        aux.Id_marca = int.Parse(dr["Id_marca"].ToString());
                        aux.Id_tipo_articulo = int.Parse(dr["Id_tipo_articulo"].ToString());
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






        /*
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
        }*/
       













    }
}