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

        /*
         * 
         * 
         * 
         * */
        public ActionResult ListadoArticulos()
        {
            List<VMInventario> lista = AD_Inventario.ListarArticulos();
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
                return RedirectToAction("ListadoArticulos", "Inventario");
            }
            else
            {
                return View(articulo);
            }
        }


        public ActionResult ObtenerArticulo(int id_articulo)
        {
            VMInventario resultado = AD_Inventario.ObtenerArticulo(id_articulo);
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
        public ActionResult ObtenerArticulo(VMInventario model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Inventario.ActualizarDatosArticulos(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoArticulos", "Inventario");
                }
                else
                {
                    return View(model);
                }
            }
            return View();
        }
        public ActionResult AgregarStock(int id_articulo)
        {
            VMInventario resultado = AD_Inventario.ObtenerArticulo(id_articulo);
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

            int cant_stock = AD_Inventario.ObtenerArticuloCantStock(id_articulo);
            ViewBag.cantStock = cant_stock;

            return View(resultado);
        }
        [HttpPost]
        public ActionResult AgregarStock(ArticuloStock articulo)
        {
            if (ModelState.IsValid)
            {
                AD_ArtStock.AgregarStock(articulo);
                return RedirectToAction("ListadoAsignarUsr", "Inventario");
            }
            else
            {
                return View(articulo);
            }
        }

        /******************
         * **
         * 
         */
        public ActionResult ObtenerArtAsignado(int id_articulo)
        {
            ArticuloStock resultado = AD_ArtStock.ObtenerArtAsignadoUsr(id_articulo);
            List<TipoUsuarios> listaTipoUsuario = AD_Inventario.ListarTipoUsuarios();
            List<SelectListItem> comboTipoUsuario = listaTipoUsuario.ConvertAll(i =>
            {
                return new SelectListItem()
                {
                    Text = i.Codigo_usuario,
                    Value = i.Id_usuario.ToString(),

                    Selected = false
                };
            });
            foreach (var item in comboTipoUsuario)
            {
                if (item.Value.Equals(resultado.Id_usuario.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }

            ViewBag.itemsUsuarios = comboTipoUsuario;

            return View(resultado);
        }
        [HttpPost]
        public ActionResult ObtenerArtAsignado(VMInventario model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Inventario.ActualizarArticuloAsignado(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoAsignarUsr", "Inventario");
                }
                else
                {
                    return View(model);
                }
            }
            return View();
        }
        public ActionResult AsignarStock(int id_articulo)
        {
            ArticuloStock resultado = AD_ArtStock.ObtenerArtAsignadoUsr(id_articulo);

            List<VMInventario> ListarTipoUsuariosArt = AD_Inventario.ListarTipoUsuariosArt(id_articulo);
            string listado = "";
            foreach (var item in ListarTipoUsuariosArt) {

                listado += "-"+item.Codigo_usuario +  "\n";

            }
            ViewBag.listado = listado;
            /***********************************************************************/
            List<TipoUsuarios> listaTipoUsuario = AD_Inventario.ListarTipoUsuarios();
            List<SelectListItem> comboTipoUsuario = listaTipoUsuario.ConvertAll(i =>
            {
                return new SelectListItem()
                {
                    Text = i.Codigo_usuario,
                    Value = i.Id_usuario.ToString(),

                    Selected = false
                };
            });
            foreach (var item in comboTipoUsuario)
            {
                if (item.Value.Equals(resultado.Id_usuario.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }

            ViewBag.itemsUsuarios = comboTipoUsuario;
            int cant_stock = AD_Inventario.ObtenerArticuloCantStock(id_articulo);
            ViewBag.cantStock = cant_stock;

            return View(resultado);

        }
        [HttpPost]
        public ActionResult AsignarStock(ArticuloStock articulo)
        {
            if (ModelState.IsValid)
            {
                AD_ArtStock.AsignarStock(articulo);
                return RedirectToAction("ListadoAsignarUsr", "Inventario");
            }
            else
            {
                return View(articulo);
            }
        }
        public ActionResult ListadoHistorialArt(int id_articulo)
        {
            List<VMInventario> lista = AD_Inventario.ListarHistorialArt(id_articulo);
            return View(lista);
        }
        //public ActionResult BajaStock(int id_articulo)
        //{
        //    VMInventario resultado = AD_Inventario.ObtenerArticulo(id_articulo); 

        //    int cant_stock = AD_Inventario.ObtenerArticuloCantStock(id_articulo);
        //    ViewBag.cantStock = cant_stock;

        //    return View(resultado);
        //}
        //[HttpPost]
        //public ActionResult BajaStock(ArticuloStock articulo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        AD_ArtStock.BajaStock(articulo);
        //        return RedirectToAction("ListadoAsignarUsr", "Inventario");
        //    }
        //    else
        //    {
        //        return View(articulo);
        //    }
        //}

        public ActionResult BajaStock(int id_articulo, string Motivo_baja)
        {
            if (Motivo_baja != null)
            {
                if (Motivo_baja != "")
                {
                    if (id_articulo != 0)
                    {
                        AD_ArtStock.BajaStock(id_articulo, Motivo_baja);
                        return RedirectToAction("ListadoAsignarUsr", "Inventario");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    VMInventario resultado = AD_Inventario.ObtenerArticulo(id_articulo);

                    int cant_stock = AD_Inventario.ObtenerArticuloCantStock(id_articulo);
                    ViewBag.cantStock = cant_stock;
                    ViewBag.MensajeError = "Debe ingresar un motivo de baja";

                    return View(resultado);
                }
            }
            else {

                VMInventario resultado = AD_Inventario.ObtenerArticulo(id_articulo);

                int cant_stock = AD_Inventario.ObtenerArticuloCantStock(id_articulo);
                ViewBag.cantStock = cant_stock;

                return View(resultado);

            }
        }

        /*[HttpPost]
        public ActionResult BajaStock(int Id_articulo, string Motivo_baja)
        {
            if (Id_articulo != 0)
            {
                AD_ArtStock.BajaStock(Id_articulo,Motivo_baja);
                return RedirectToAction("ListadoAsignarUsr", "Inventario");
            }
            else
            {
                return View();
            }
        }*/



    }
}