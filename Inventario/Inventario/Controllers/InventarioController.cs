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
        /***************/
        /*public ActionResult ObtenerArticulo(int id_articulo)
        {
            Articulo resultado = AD_Articulos.ObtenerArticulo(id_articulo);
            List<TipoMarca> listaMarca = AD_Articulos.ListarTipoMarcas();
            List<SelectListItem> comboMarca = listaMarca.ConvertAll(i =>
            {
                return new SelectListItem()
                {
                    Text = i.Descripcion_marca,
                    Value = i.Id_marca.ToString(),
                    Selected = false
                };
            });

            foreach (var item in comboMarca)
            {
                if (item.Value.Equals(resultado.Id_marca.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }

            ViewBag.itemsMarca = comboMarca;

            List<TipoArticulo> listaTipoArticulo = AD_Articulos.ListarTipoArticulos();
            List<SelectListItem> comboTipoArticulo = listaTipoArticulo.ConvertAll(i =>
            {
                return new SelectListItem()
                {
                    Text = i.Descripcion_tipo_articulo,
                    Value = i.Id_tipo_articulo.ToString(),

                    Selected = false
                };
            });
            foreach (var item in comboTipoArticulo)
            {
                if (item.Value.Equals(resultado.Id_tipo_articulo.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }

            ViewBag.itemsTipoArticulo = comboTipoArticulo;

            return View(resultado);
        }
        [HttpPost]
        public ActionResult ObtenerArticulo(Articulo model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Articulos.ActualizarDatosArticulos(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoArticulos", "Articulo");
                }
                else
                {
                    return View(model);
                }
            }
            return View();
        }*/


    }
}