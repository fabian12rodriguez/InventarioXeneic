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

        public ActionResult ObtenerMarca(int id_marca)
        {
            Marca resultado = AD_Articulos.ObtenerMarca(id_marca);
           
            return View(resultado);
        }
        [HttpPost]
        public ActionResult ObtenerMarca(Marca model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Articulos.ActualizarDatosMarcas(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoMarcas", "Marca");
                }
                else
                {
                    return View(model);
                }
            }
            return View();
        }







    }
}