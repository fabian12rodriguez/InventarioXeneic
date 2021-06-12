using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inventario
{
    public partial class Grafica3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected string obtenerDatos()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);


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
    }
}