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
                   @"select A.ID_ARTICULO, 
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
                            A.ID_ARTICULO, 
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
















    }
}