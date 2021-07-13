using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventario.AccesoDatos;
using Inventario.ViewModels;
using Inventario.Models;
using Rotativa;

namespace Inventario.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte


        public ActionResult Index()
        {
            ReporteGral resultado = new ReporteGral();
            return View(resultado);
        }
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
      
        public ActionResult ListadoReportes4Filtrado(string nombre_articulo)
        {
            if (nombre_articulo == "")
            {
                return RedirectToAction("ListadoReportes4", "Reporte");
            }
            else
            {
                List<VMInventario> resultado = AD_Reportes.ListadoStockFiltrado(nombre_articulo);


                return View(resultado);
            }
        }

        public ActionResult Ayuda()
        {
          return View();
        }
        public ActionResult Terminosycondiciones()
        {
            return View();
        }

            //--------------PDF---------------------------------

            //------------General
            public ActionResult PDFIndex()
        {
            ReporteGral resultado = new ReporteGral();
            return View(resultado);
        }
        public ActionResult Print()
        {
            return new ActionAsPdf("PDFIndex", new { nombre = "Xeneic" }) { FileName = "reporte.pdf" };
        }
        //------------ListadoReportes1
        public ActionResult PDFListadoReportes1()
        {
            List<VMInventario> lista = AD_Reportes.ListadoArtPorTipo();
            return View(lista);
        }
        public ActionResult Print1()
        {
            return new ActionAsPdf("PDFListadoReportes1", new { nombre = "Xeneic" }) { FileName = "reporte.pdf" };
        }
        //------------ListadoReportes2
        public ActionResult PDFListadoReportes2()
        {
            List<VMInventario> lista = AD_Reportes.ListadoUsrPorArea();
            return View(lista);
        }
        public ActionResult Print2()
        {
            return new ActionAsPdf("PDFListadoReportes2", new { nombre = "Xeneic" }) { FileName = "reporte.pdf" };
        }
        //------------ListadoReportes3
        public ActionResult PDFListadoReportes3()
        {
            List<VMInventario> lista = AD_Reportes.ListadoSinUsrAsignado();
            return View(lista);
        }
        public ActionResult Print3()
        {
            return new ActionAsPdf("PDFListadoReportes3", new { nombre = "Xeneic" }) { FileName = "reporte.pdf" };
        }
        //------------ListadoReportes4
        public ActionResult PDFListadoReportes4()
        {
            List<VMInventario> lista = AD_Reportes.ListadoCantTipoNBK();
            return View(lista);
        }
        public ActionResult Print4()
        {
            return new ActionAsPdf("PDFListadoReportes4", new { nombre = "Xeneic" }) { FileName = "reporte.pdf" };
        }
        //public ActionResult Print5()
        //{
        //    return new ActionAsPdf("ListadoReportes4Filtrado", new { nombre = "Xeneic" }) { FileName = "reporte.pdf" };
        //}



    }
}