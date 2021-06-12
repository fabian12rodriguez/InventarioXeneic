using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Inventario.ViewModels;
using System.Data.SqlClient;

namespace Inventario
{
    public partial class WebForm2 : System.Web.UI.Page
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