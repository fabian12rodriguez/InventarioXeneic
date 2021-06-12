using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventario.AccesoDatos;
using Inventario.ViewModels;

namespace Inventario.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte

        public ActionResult ListadoReportes1()
        {
            List<VMInventario> lista = AD_Reportes.ListadoArtPorTipo();
            return View(lista);
        }
        public ActionResult ListadoReportes2()
        {
            List<VMInventario> lista = AD_Reportes.ListadoUsrPorArea();
            return View(lista);
        }
        public ActionResult ListadoReportes3()
        {
            List<VMInventario> lista = AD_Reportes.ListadoSinUsrAsignado();
            return View(lista);
        }
        public ActionResult ListadoReportes4()
        {
            List<VMInventario> lista = AD_Reportes.ListadoCantTipoNBK();
            return View(lista);
        }
    }
}