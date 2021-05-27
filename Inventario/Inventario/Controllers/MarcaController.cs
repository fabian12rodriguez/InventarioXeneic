using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventario.AccesoDatos;
using Inventario.Models;
using Inventario.ViewModels;


namespace Inventario.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
      
        public ActionResult ListadoMarcas()
        {
            List<Marca> lista = AD_Articulos.ListarMarcas();
            return View(lista);
        }
        public ActionResult AltaMarca()
        {

            return View();
        }

    [HttpPost]
        public ActionResult AltaMarca(Marca marcas)
        {
            if (ModelState.IsValid)
            {
                AD_Articulos.InsertarMarca(marcas);
                return RedirectToAction("ListadoMarcas", "Marca");
            }
            else
            {
                return View(marcas);
            }
        }







    }
}