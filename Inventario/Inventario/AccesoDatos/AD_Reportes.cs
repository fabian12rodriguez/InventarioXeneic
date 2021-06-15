using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventario.Models;
using Inventario.ViewModels;
using System.Data.SqlClient;
using System.Data;

namespace Inventario.AccesoDatos
{
    public class AD_Reportes
    {

        public static List<VMInventario> ListadoArtPorTipo()
        {
            List<VMInventario> resultado = new List<VMInventario>(); 
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString(); 

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try 
            {
                SqlCommand cmd = new SqlCommand();

                //Emitir listado de artículos por tipo.

                string consulta = @"SELECT t.DESCRIPCION_TIPO_ARTICULO Tipo, count(*) cantidad
                                    FROM ARTICULOS A, TIPOS_ARTICULOS T
                                    WHERE A.ID_TIPO_ARTICULO = T.ID_TIPO_ARTICULO
                                    group by t.DESCRIPCION_TIPO_ARTICULO
                                    ORDER BY 1;
                                     ";
                cmd.Parameters.Clear();


                cmd.CommandType = System.Data.CommandType.Text; 
                cmd.CommandText = consulta;



                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read()) 
                    {
                        VMInventario nuevoReporte = new VMInventario();
                        nuevoReporte.Desc_tipo_articulo = dr["Tipo"].ToString();
                        nuevoReporte.Cantidad = int.Parse(dr["Cantidad"].ToString());
                        resultado.Add(nuevoReporte);

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
        public static List<VMInventario> ListadoUsrPorArea()
        {
            List<VMInventario> resultado = new List<VMInventario>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                //Emitir listado de usuarios por área.

                string consulta = @"SELECT A.DESCRIPCION_AREA Area, COUNT (*) CANTIDAD
                                    FROM USUARIOS U, AREAS A, AREAS_USUARIOS AU
                                    WHERE U.ID_USUARIO = AU.ID_USUARIO
                                    AND A.ID_AREA = AU.ID_AREA
                                    GROUP BY A.DESCRIPCION_AREA
                                    ORDER BY 2 DESC,1 ;";
                cmd.Parameters.Clear();


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;



                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        VMInventario nuevoReporte = new VMInventario();
                        nuevoReporte.Area = dr["Area"].ToString();
                        nuevoReporte.Cantidad = int.Parse(dr["Cantidad"].ToString());
                        resultado.Add(nuevoReporte);

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
        public static List<VMInventario> ListadoSinUsrAsignado()
        {
            List<VMInventario> resultado = new List<VMInventario>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                //listado de artículos sin usuarios asignados.

                string consulta = @"select A.NOMBRE_ARTICULO, 
                                    A.MODELO_ARTICULO, 
                                    M.DESCRIPCION_MARCA, 
                                    T.DESCRIPCION_TIPO_ARTICULO
                                    from articulos a left join ARTICULOS_USUARIOS au on a.ID_ARTICULO = au.ID_ARTICULO
                                    join MARCAS M on A.ID_MARCA = M.ID_MARCA
                                    join TIPOS_ARTICULOS T on A.ID_TIPO_ARTICULO  = T.ID_TIPO_ARTICULO
                                    LEFT join USUARIOS U on au.ID_USUARIO = U.ID_USUARIO
                                    where a.HABILITADO_ARTICULO = 1
                                    and u.CODIGO_USUARIO is null;";
                cmd.Parameters.Clear();


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;



                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        VMInventario nuevoReporte = new VMInventario();
                        nuevoReporte.Nombre_articulo = dr["NOMBRE_ARTICULO"].ToString();
                        nuevoReporte.Modelo_articulo = dr["MODELO_ARTICULO"].ToString();
                        nuevoReporte.Desc_marca_articulo = dr["DESCRIPCION_MARCA"].ToString();
                        nuevoReporte.Desc_tipo_articulo = dr["DESCRIPCION_TIPO_ARTICULO"].ToString();
                        resultado.Add(nuevoReporte);

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
        public static List<VMInventario> ListadoCantTipoNBK()
        {
            List<VMInventario> resultado = new List<VMInventario>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                //listado de cantidad de artículos tipo notebook

                string consulta = @"SELECT t.DESCRIPCION_TIPO_ARTICULO tipo, count(*) cantidad
                                    FROM ARTICULOS A, TIPOS_ARTICULOS T
                                    WHERE A.ID_TIPO_ARTICULO = T.ID_TIPO_ARTICULO
                                    and t.DESCRIPCION_TIPO_ARTICULO like '%NOTEBOOK%'
                                    group by t.DESCRIPCION_TIPO_ARTICULO
                                    ORDER BY 1;";
                cmd.Parameters.Clear();


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;



                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        VMInventario nuevoReporte = new VMInventario();
                        nuevoReporte.Desc_tipo_articulo = dr["tipo"].ToString();
                        nuevoReporte.Cantidad = int.Parse(dr["Cantidad"].ToString());
                        resultado.Add(nuevoReporte);

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
        public static string obtenerDatosGrafico()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);


            SqlCommand cmd = new SqlCommand();

            //Emitir listado de artículos por tipo.

            string consulta = @"SELECT A.DESCRIPCION_AREA AREA, COUNT (*) CANTIDAD
                                    FROM USUARIOS U, AREAS A, AREAS_USUARIOS AU
                                    WHERE U.ID_USUARIO = AU.ID_USUARIO
                                    AND A.ID_AREA = AU.ID_AREA
                                    GROUP BY A.DESCRIPCION_AREA
                                    ORDER BY 2 DESC,1 ;
                                     ";
            cmd.Parameters.Clear();


            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();
            cmd.Connection = cn;


            DataTable Datos = new DataTable();
            Datos.Load(cmd.ExecuteReader());
            cn.Close();

            string strDatos;

            strDatos = "[['Area', 'Cantidad'],";

            foreach (DataRow dr in Datos.Rows)
            {

                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + dr[0] + "'" + "," + dr[1];
                strDatos = strDatos + "],";


            }

            strDatos = strDatos + "]";

            return strDatos;
        }




    }
}