using Inventario.AccesoDatos;
using Inventario.ViewModels;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventario.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string tabla = AD_Reportes.obtenerDatos();
            ViewBag.grafico = tabla;
            
            string tabla2 = AD_Reportes.obtenerDatos2();
            ViewBag.grafico2 = tabla2;

            string tabla3 = AD_Reportes.obtenerDatos3();
            ViewBag.grafico3 = tabla3;
            return View();
        }
 
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}