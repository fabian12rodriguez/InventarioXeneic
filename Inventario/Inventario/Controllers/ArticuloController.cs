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

       /* public ActionResult ObtenerArticulo(int id_articulo)
        {
            List<TipoMarca> listaMarca = AD_Concesionaria.ObtenerListadoDeMarcas();
            List<SelectListItem> comboMarca = listaMarca.ConvertAll(i => //convertimos la listaMarca en un SelectedListItem  para que cada item (i) nos muestre el id y el Nombre
            {
                return new SelectListItem()
                {
                    Text = i.Nombre, //significa que el texto va a ser el campo de mi item (i) que se llame nombre
                    Value = i.IdMarca.ToString(), //significa que el texto va a ser el campo de mi item (i) que se llame nombre
                    //es toString porque tomamos un INT del IDMARCA
                    Selected = false //no va a haber ningun ITEM seleccionado
                };
            });
            Auto resultado = AD_Concesionaria.ObtenerAuto(idAuto);
            foreach (var item in comboMarca) // para cada item del combo vamos a consultar lo siguiente
            {
                if (item.Value.Equals(resultado.IdMarca.ToString())) // SI el item Value (propiedad del SelectedListItem) es igual a la instancia del auto IDMarca ToString(porque compara String con String)
                {
                    item.Selected = true; //
                    break; // si es verdadero que corte el for
                }
            }

            ViewBag.items = comboMarca;//agrega el itemCombo al viewBag

            //------------------------------------
            List<TipoArticulo> listaMarca = AD_Concesionaria.ObtenerListadoDeMarcas();
            List<SelectListItem> comboMarca = listaMarca.ConvertAll(i => //convertimos la listaMarca en un SelectedListItem  para que cada item (i) nos muestre el id y el Nombre
            {
                return new SelectListItem()
                {
                    Text = i.Nombre, //significa que el texto va a ser el campo de mi item (i) que se llame nombre
                    Value = i.IdMarca.ToString(), //significa que el texto va a ser el campo de mi item (i) que se llame nombre
                    //es toString porque tomamos un INT del IDMARCA
                    Selected = false //no va a haber ningun ITEM seleccionado
                };
            });
            Auto resultado = AD_Concesionaria.ObtenerAuto(idAuto);
            foreach (var item in comboMarca) // para cada item del combo vamos a consultar lo siguiente
            {
                if (item.Value.Equals(resultado.IdMarca.ToString())) // SI el item Value (propiedad del SelectedListItem) es igual a la instancia del auto IDMarca ToString(porque compara String con String)
                {
                    item.Selected = true; //
                    break; // si es verdadero que corte el for
                }
            }

            ViewBag.items = comboMarca;//agrega el itemCombo al viewBag

            return View(resultado);
        }*/










    }
}