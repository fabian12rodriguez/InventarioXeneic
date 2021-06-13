using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventario.AccesoDatos;

namespace Inventario.ViewModels
{
    public class ReporteGral
    {
        public List<VMInventario> ListadoArtPorTipo { get; set; }
        public List<VMInventario> ListadoUsrPorArea { get; set; }
        public List<VMInventario> ListadoSinUsrAsignado { get; set; }
        public List<VMInventario> ListadoCantTipoNBK { get; set; }

        public ReporteGral()//CONSTRUCTOR DE LA CLASE
        {
            ListadoArtPorTipo = new List<VMInventario>();
            ListadoUsrPorArea = new List<VMInventario>();
            ListadoSinUsrAsignado = new List<VMInventario>();
            ListadoCantTipoNBK = new List<VMInventario>();
            cargarVariables();
        }

        private void cargarVariables()
        {
            ListadoArtPorTipo = AD_Reportes.ListadoArtPorTipo();
            ListadoUsrPorArea = AD_Reportes.ListadoUsrPorArea();
            ListadoSinUsrAsignado = AD_Reportes.ListadoSinUsrAsignado();
            ListadoCantTipoNBK = AD_Reportes.ListadoCantTipoNBK();
        }

    }
}