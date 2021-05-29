using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventario.AccesoDatos;
using Inventario.ViewModels;


namespace Inventario.Controllers
{
    public class InventarioController : Controller
    {
        // GET: Inventario
     
        public ActionResult ListadoInventario()
        {
            List<VMInventario> lista = AD_Inventario.ListarStock();
            return View(lista);
        }
        public ActionResult ListadoAsignarUsr()
        {
            List<VMInventario> lista = AD_Inventario.ListarAsignarUsuario();
            return View(lista);
        }


    }
}