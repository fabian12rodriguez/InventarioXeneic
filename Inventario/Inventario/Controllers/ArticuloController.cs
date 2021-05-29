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
        public ActionResult AltaArticulo(ArticuloStock articulo)
        {
            if (ModelState.IsValid)
            {

                AD_ArtStock.InsertarArticulo(articulo);
                int id_articulo = AD_ArtStock.ObtenerArticulo();
                AD_ArtStock.InsertarStock(articulo, id_articulo);
                return RedirectToAction("ListadoArticulos", "Articulo");
            }
            else
            {
                return View(articulo);
            }
        }

   
        public ActionResult ObtenerArticulo(int id_articulo)
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
                    break;                 }
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
        }









    }
}