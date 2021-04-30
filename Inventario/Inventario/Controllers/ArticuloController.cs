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
        /*  // GET: Articulo
        public ActionResult ListadoInstrumentos()
        {
            List<Instrumento> lista = AD_Instrumentos.ListarInstrumentos();
            return View(lista);
        }*/

        public ActionResult AltaArticulo()
        {
            List<TipoRoles> listaTipos = AD_Articulos.ListarTipos();
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
        }

       /* [HttpPost]
        public ActionResult AltaInstrumento(Instrumento instrumento)
        {
            if (ModelState.IsValid)
            {
                AD_Instrumentos.InsertarInstrumento(instrumento);
                return RedirectToAction("ListadoInstrumentos", "Negocio");
            }
            else
            {
                return View(instrumento);
            }
        }

        public ActionResult EliminarInstrumento(int idInstrumento)
        {
            List<TipoItemVM> listaTipos = AD_Instrumentos.ListarTipos();
            List<SelectListItem> itemsCombo = listaTipos.ConvertAll(t => {
                return new SelectListItem()
                {
                    Text = t.Nombre,
                    Value = t.IdTipo.ToString(),
                    Selected = false
                };
            });

            Instrumento resultado = AD_Instrumentos.ObtenerDatosInstrumento(idInstrumento);

            foreach (var item in itemsCombo)
            {
                if (item.Value.Equals(resultado.IdTipo.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }

            ViewBag.items = itemsCombo;
            return View(resultado);
        }

        [HttpPost]
        public ActionResult EliminarInstrumento(Instrumento intrumento)
        {
            bool resultado = AD_Instrumentos.EliminarInstrumento(intrumento);
            if (resultado)
            {
                return RedirectToAction("ListadoInstrumentos", "Negocio");
            }
            return View(intrumento);
        }*/












    }
}