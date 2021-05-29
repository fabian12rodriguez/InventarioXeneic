using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventario.AccesoDatos;
using Inventario.ViewModels;

namespace Inventario.Controllers
{
    public class TipoArticulosController : Controller
    {
        // GET: TipoArticulos
        public ActionResult AltaTipoArt()
        {

            return View();
        }

        public ActionResult ListadoTipoArt()
        {
            List<TipoArticulo> lista = AD_Articulos.ListarTipoArticulos();
            return View(lista);
        }

        [HttpPost]
        public ActionResult AltaTipoArt(TipoArticulo tipoArticulo)
        {
            if (ModelState.IsValid)
            {
                AD_Articulos.InsertarTipoArt(tipoArticulo);
                return RedirectToAction("ListadoTipoArt", "TipoArticulos");
            }
            else
            {
                return View(tipoArticulo);
            }
        }

        public ActionResult ObtenerTipoArt(int id_tipo_articulo)
        {
            TipoArticulo resultado = AD_Articulos.ObtenerTipoArt(id_tipo_articulo);

            return View(resultado);
        }
        [HttpPost]
        public ActionResult ObtenerTipoArt(TipoArticulo model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Articulos.ActualizarDatosTipoArt(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoTipoArt", "TipoArticulos");
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