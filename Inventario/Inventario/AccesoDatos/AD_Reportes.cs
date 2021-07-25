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
        public static string obtenerDatos()
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
        public static string obtenerDatos2()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);


            SqlCommand cmd = new SqlCommand();

            //Emitir listado de artículos por tipo.

            string consulta = @"select   T.DESCRIPCION_TIPO_ARTICULO, 
                            SUM(mvt.CANTIDAD_MVT)stock
                            from articulos a join MOVIMIENTOS_STOCK mvt on a.ID_ARTICULO = mvt.ID_ARTICULO
                            join MARCAS M on A.ID_MARCA = M.ID_MARCA
                            join TIPOS_ARTICULOS T on A.ID_TIPO_ARTICULO  = T.ID_TIPO_ARTICULO
                            where a.HABILITADO_ARTICULO = 1
                            GROUP BY
                            T.DESCRIPCION_TIPO_ARTICULO
                            order by 1, 2 ;";
            cmd.Parameters.Clear();


            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();
            cmd.Connection = cn;


            DataTable Datos = new DataTable();
            Datos.Load(cmd.ExecuteReader());
            cn.Close();

            string strDatos;

            strDatos = "[['Tipo', 'Cantidad'],";

            foreach (DataRow dr in Datos.Rows)
            {

                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + dr[0] + "'" + "," + dr[1];
                strDatos = strDatos + "],";


            }

            strDatos = strDatos + "]";

            return strDatos;
        }
        public static string obtenerDatos3()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);


            SqlCommand cmd = new SqlCommand();

            //Emitir listado de altas de articulos por mes

            string consulta = @"select 
                                CASE
                                    WHEN  month(h.FECHA_HISTORIAL) = 1 THEN 'enero'
                                    WHEN  month(h.FECHA_HISTORIAL) = 2 THEN 'febrero'
	                                WHEN  month(h.FECHA_HISTORIAL) = 3 THEN 'marzo'
	                                WHEN  month(h.FECHA_HISTORIAL) = 4 THEN 'abril'
	                                WHEN  month(h.FECHA_HISTORIAL) = 5 THEN 'mayo'
	                                WHEN  month(h.FECHA_HISTORIAL) = 6 THEN 'junio'
	                                WHEN  month(h.FECHA_HISTORIAL) = 7 THEN 'julio'
	                                WHEN  month(h.FECHA_HISTORIAL) = 8 THEN 'agosto'
	                                WHEN  month(h.FECHA_HISTORIAL) = 9 THEN 'septiembre'
	                                WHEN  month(h.FECHA_HISTORIAL) = 10 THEN 'octubre'
	                                WHEN  month(h.FECHA_HISTORIAL) = 11 THEN 'noviembre'
                                    ELSE 'diciembre'
                                END as mes, count(*) cantidad
                                from HISTORIAL_ARTICULOS h
                                where h.OBSERVACIONES_HISTORIAL like '%Alta de articulo%'
                                group by month(h.FECHA_HISTORIAL) ;";
            cmd.Parameters.Clear();


            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();
            cmd.Connection = cn;


            DataTable Datos = new DataTable();
            Datos.Load(cmd.ExecuteReader());
            cn.Close();

            string strDatos;

            strDatos = "[['Mes', 'Cantidad'],";

            foreach (DataRow dr in Datos.Rows)
            {

                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + dr[0] + "'" + "," + dr[1];
                strDatos = strDatos + "],";


            }

            strDatos = strDatos + "]";

            return strDatos;
        }
        public static string obtenerDatos4()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);


            SqlCommand cmd = new SqlCommand();

            //Emitir listado de artículos por tipo.

            string consulta = @"SELECT R.DESCRIPCION_ROL ROL, COUNT(*) CANTIDAD
                                FROM USUARIOS U, ROLES R
                                WHERE U.ID_ROL	= R.ID_ROL
                                GROUP BY R.DESCRIPCION_ROL";
            cmd.Parameters.Clear();


            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = consulta;
            cn.Open();
            cmd.Connection = cn;


            DataTable Datos = new DataTable();
            Datos.Load(cmd.ExecuteReader());
            cn.Close();

            string strDatos;

            strDatos = "[['Rol', 'Cantidad'],";

            foreach (DataRow dr in Datos.Rows)
            {

                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + dr[0] + "'" + "," + dr[1];
                strDatos = strDatos + "],";


            }

            strDatos = strDatos + "]";

            return strDatos;
        }
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

                //listado de usuarios con articulos asignados

                string consulta = @"select ar.DESCRIPCION_AREA area, 
                                    u.CODIGO_USUARIO,
                                    U.APELLIDO_USUARIO+' '+U.NOMBRE_USUARIO NOMBRE,
                                    A.NOMBRE_ARTICULO, 
                                    A.MODELO_ARTICULO, 
                                    M.DESCRIPCION_MARCA, 
                                    T.DESCRIPCION_TIPO_ARTICULO
                                    from articulos a left join ARTICULOS_USUARIOS au on a.ID_ARTICULO = au.ID_ARTICULO
                                    join MARCAS M on A.ID_MARCA = M.ID_MARCA
                                    join TIPOS_ARTICULOS T on A.ID_TIPO_ARTICULO  = T.ID_TIPO_ARTICULO
                                    LEFT join USUARIOS U on au.ID_USUARIO = U.ID_USUARIO
									join AREAS_USUARIOS aru on aru.ID_USUARIO = u.ID_USUARIO
									join AREAS ar on ar.ID_AREA = aru.ID_AREA
                                    where a.HABILITADO_ARTICULO = 1
                                    and u.ID_USUARIO is not null;";
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
                        nuevoReporte.Codigo_usuario = dr["Codigo_usuario"].ToString();
                        nuevoReporte.Nombre_usuario = dr["Nombre"].ToString();
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

                //listado de faltante de stock

                string consulta = @"select A.Id_articulo,
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
                                    A.ID_MARCA,
                                    M.DESCRIPCION_MARCA, 
                                    A.ID_TIPO_ARTICULO,
                                    T.DESCRIPCION_TIPO_ARTICULO
							        HAVING SUM(mvt.CANTIDAD_MVT) < 5
                                    order by 6,5,2 ;";
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
                        nuevoReporte.Id_articulo = int.Parse(dr["Id_articulo"].ToString());
                        nuevoReporte.Nombre_articulo = dr["Nombre_articulo"].ToString();
                        nuevoReporte.Modelo_articulo = dr["Modelo_articulo"].ToString();
                        nuevoReporte.Desc_marca_articulo = dr["DESCRIPCION_MARCA"].ToString();
                        nuevoReporte.Desc_tipo_articulo = dr["DESCRIPCION_TIPO_ARTICULO"].ToString();
                        nuevoReporte.Stock = int.Parse(dr["Stock"].ToString());
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
        public static List<VMInventario> ListadoCantTipoNBKFilter(int id_tipo_articulo)
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
                                    T.DESCRIPCION_TIPO_ARTICULO
							        HAVING SUM(mvt.CANTIDAD_MVT) < 5
                                    order by 6,5,2 ;";
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
                        VMInventario nuevoReporte = new VMInventario();
                        nuevoReporte.Id_articulo = int.Parse(dr["Id_articulo"].ToString());
                        nuevoReporte.Nombre_articulo = dr["Nombre_articulo"].ToString();
                        nuevoReporte.Modelo_articulo = dr["Modelo_articulo"].ToString();
                        nuevoReporte.Desc_marca_articulo = dr["DESCRIPCION_MARCA"].ToString();
                        nuevoReporte.Desc_tipo_articulo = dr["DESCRIPCION_TIPO_ARTICULO"].ToString();
                        nuevoReporte.Stock = int.Parse(dr["Stock"].ToString());
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
        public static List<VMInventario> ListadoStockFiltrado(string nombre_articulo)
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
                                    SUM(mvt.CANTIDAD_MVT)stock
                                    from articulos a join MOVIMIENTOS_STOCK mvt on a.ID_ARTICULO = mvt.ID_ARTICULO
                                    join MARCAS M on A.ID_MARCA = M.ID_MARCA
                                    join TIPOS_ARTICULOS T on A.ID_TIPO_ARTICULO  = T.ID_TIPO_ARTICULO
                                    where a.HABILITADO_ARTICULO = 1
									and a.NOMBRE_ARTICULO LIKE '%'+@nombre_articulo+'%'
                                    GROUP BY
							        A.Id_articulo,
                                    A.NOMBRE_ARTICULO, 
                                    A.MODELO_ARTICULO, 
                                    A.ID_MARCA,
                                    M.DESCRIPCION_MARCA, 
                                    A.ID_TIPO_ARTICULO,
                                    T.DESCRIPCION_TIPO_ARTICULO
							        HAVING SUM(mvt.CANTIDAD_MVT) < 5
                                    order by 6,5,2 ;";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre_articulo", nombre_articulo);

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
                        nuevoReporte.Id_articulo = int.Parse(dr["Id_articulo"].ToString());
                        nuevoReporte.Nombre_articulo = dr["Nombre_articulo"].ToString();
                        nuevoReporte.Modelo_articulo = dr["Modelo_articulo"].ToString();
                        nuevoReporte.Desc_marca_articulo = dr["DESCRIPCION_MARCA"].ToString();
                        nuevoReporte.Desc_tipo_articulo = dr["DESCRIPCION_TIPO_ARTICULO"].ToString();
                        nuevoReporte.Stock = int.Parse(dr["Stock"].ToString());
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




    }
}