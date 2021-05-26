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
    public class ArticuloController : Controller
    {
        // GET: Articulo
       public ActionResult AltaArticulo()
        {
            return View();
        }

        /*public ActionResult ListadoInstrumentos()
        {
            List<Instrumento> lista = AD_Instrumentos.ListarInstrumentos();
            return View(lista);
        }*/

        /*public ActionResult AltaArticulo()
        {
            List<TipoItemVM> listaTipos = AD_Instrumentos.ListarTipos();
            List<SelectListItem> items = listaTipos.ConvertAll(t => {
                return new SelectListItem()
                {
                    Text = t.Nombre,
                    Value = t.IdTipo.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;
            return View();
        }*/

        [HttpPost]
        public ActionResult AltaArticulo(Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                AD_Articulos.InsertarArticulo(articulo);
                return RedirectToAction("AltaArticulo", "Articulo");
            }
            else
            {
                return View(articulo);
            }
        }
    }
}