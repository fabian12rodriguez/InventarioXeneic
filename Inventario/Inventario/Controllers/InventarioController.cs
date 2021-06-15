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

            return View(lista);

        }
        //
     
        //public ActionResult ListadoInventario(IEnumerable<VMInventario> lista1)
        //{
        //    List<VMInventario> lista = AD_Inventario.ListarStock();

        //    List<TipoArticulo> listaTiposArticulos = AD_Articulos.ListarTipoArticulos();
        //    List<SelectListItem> itemsTipoArticulos = listaTiposArticulos.ConvertAll(t => {
        //        return new SelectListItem()
        //        {
        //            Text = t.Descripcion_tipo_articulo,
        //            Value = t.Id_tipo_articulo.ToString(),
        //            Selected = false
        //        };
        //    });

        //    ViewBag.itemsTipoArticulos = itemsTipoArticulos;

        //    return View(lista);

        //}

        public ActionResult ListadoInventarioFiltrado(int id_tipo_articulo)
        {
            if (id_tipo_articulo == 0) {
                return RedirectToAction("ListadoInventario", "Inventario");
            }
            else { 
            List<VMInventario> resultado = AD_Inventario.ListadoInventarioFiltrado(id_tipo_articulo);

            
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

            return View(resultado);
            }
        }



        public ActionResult ListadoAsignarUsr()
        {
            List<VMInventario> lista = AD_Inventario.ListarAsignarUsuario();
            return View(lista);
        }

        

    }
}