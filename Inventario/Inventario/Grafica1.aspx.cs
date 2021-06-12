using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inventario
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected string obtenerDatos() {

            DataTable Datos = new DataTable();

            //Columnas
            Datos.Columns.Add(new DataColumn("Task", typeof(string)));
            Datos.Columns.Add(new DataColumn("Hours per Day", typeof(string)));

            //Datos de las columnas
            Datos.Rows.Add(new Object[] {"Work",11});
            Datos.Rows.Add(new Object[] {"Eat", 2 });
            Datos.Rows.Add(new Object[] {"Commute", 2 });
            Datos.Rows.Add(new Object[] {"Watch TV", 2 });
            Datos.Rows.Add(new Object[] {"Sleep", 7 });

            string strDatos;

            strDatos = "[['Task', 'Hours per Day'],";

            foreach (DataRow dr in Datos.Rows) {

                strDatos = strDatos + "[";
                strDatos = strDatos + "'"+dr[0]+"'"+","+ dr[1];
                strDatos = strDatos + "],";


            }

            strDatos = strDatos + "]";

            return strDatos;
        }
    }
}