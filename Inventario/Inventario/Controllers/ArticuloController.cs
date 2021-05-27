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

        public ActionResult ListadoArticulos()
        {
            List<Articulo> lista = AD_Articulos.ListarArticulos();
            return View(lista);
        }

        public ActionResult AltaArticulo()
        {
            List<TipoMarca> listaTiposMarcas = AD_Articulos.ListarTipoMarcas();
            List<SelectListItem> itemsMarcas = listaTiposMarcas.ConvertAll(t => {
                return new SelectListItem()
                {
                    Text = t.Descripcion_marca,
                    Value = t.Id_marca.ToString(),
                    Selected = false
                };
            });

            ViewBag.itemsMarcas = itemsMarcas;


            List<TipoArticulo> listaTiposArticulos = AD_Articulos.ListarTipoArticulos();
            List<SelectListItem> itemsTipoArticulos = listaTiposArticulos.ConvertAll(t => {
                return new SelectListItem()
                {
                    Text = t.Descripcion_tipo_articulo,
                    Value = t.Id_tipo_articulo.ToString(),
                    Selected = false
                };
            });

            ViewBag.itemsTipoArticulos = itemsTipoArticulos;
            return View();
        }

        [HttpPost]
        public ActionResult AltaArticulo(Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                AD_Articulos.InsertarArticulo(articulo);
                return RedirectToAction("ListadoArticulos", "Articulo");
            }
            else
            {
                return View(articulo);
            }
        }
    }
}