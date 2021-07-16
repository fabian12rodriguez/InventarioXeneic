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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult ListadoUsuarios()
        {
            List<VMInventario> lista = AD_Usuario.ListarUsuarios();
            return View(lista);
        }
   
        public ActionResult ObtenerUsuario(int id_usuario)
        {
            VMInventario resultado = AD_Usuario.ObtenerUsuario(id_usuario);
            List<TipoRoles> listaRoles = AD_Usuario.ListarTipoRoles();
            List<SelectListItem> comboRoles = listaRoles.ConvertAll(i =>
            {
                return new SelectListItem()
                {
                    Text = i.Descripcion_rol,
                    Value = i.Id_rol.ToString(),
                    Selected = false
                };
            });

            foreach (var item in comboRoles)
            {
                if (item.Value.Equals(resultado.Id_rol.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }

            ViewBag.itemsRoles = comboRoles;

            return View(resultado);
        }
        [HttpPost]
        public ActionResult ObtenerUsuario(VMInventario model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Usuario.ActualizarDatosUsuarios(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoUsuarios", "Usuario");
                }
                else
                {
                    return View(model);
                }
            }
            return View();
        }
        public ActionResult AltaUsuario()
        {
            List<TipoRoles> listaTipoRoles = AD_Usuario.ListarTipoRoles();
            List<SelectListItem> itemsRoles = listaTipoRoles.ConvertAll(i => {
                return new SelectListItem()
                {
                    Text = i.Descripcion_rol,
                    Value = i.Id_rol.ToString(),
                    Selected = false
                };
            });

            ViewBag.itemsRoles = itemsRoles;

            return View();
        }

        [HttpPost]
        public ActionResult AltaUsuario(VMInventario usuario)
        {
            if (ModelState.IsValid)
            {

                AD_Usuario.InsertarUsuario(usuario);
                return RedirectToAction("ListadoUsuarios", "Usuario");
            }
            else
            {
                return View(usuario);
            }
        }
        public ActionResult RegistrarUsuario()
        {
            List<TipoRoles> listaTipoRoles = AD_Usuario.ListarTipoRoles();
            List<SelectListItem> itemsRoles = listaTipoRoles.ConvertAll(i => {
                return new SelectListItem()
                {
                    Text = i.Descripcion_rol,
                    Value = i.Id_rol.ToString(),
                    Selected = false
                };
            });

            ViewBag.itemsRoles = itemsRoles;

            return View();
        }

        [HttpPost]
        public ActionResult RegistrarUsuario(VMInventario usuario)
        {
            if (ModelState.IsValid)
            {

                AD_Usuario.registrarUsuario(usuario);
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View(usuario);
            }
        }
        public ActionResult ReestablecerUsuario()
        {
            return View();

        }
        [HttpPost]
        public ActionResult ReestablecerUsuario(VMInventario model)
        {
            VMInventario resultado = AD_Usuario.ObtenerRecuperarUsuario(model.Codigo_usuario);

            /*bool resultado = AD_Usuario.ActualizarDatosRecuperarUsuarios(model);*/

            if (resultado.Codigo_usuario != null)
            {

                return RedirectToAction("ObtenerRecuperarUsr", "Usuario", new { resultado.Codigo_usuario });
            }
            else
            {
                ViewBag.Mensaje = "Usuario inexistente";
                return View();

            }

        }
        public ActionResult ObtenerRecuperarUsr(string codigo_usuario)
        {
            VMInventario resultado = AD_Usuario.ObtenerRecuperarUsuario(codigo_usuario);
            resultado.Password_usuario = "";
            return View(resultado);
        }
        [HttpPost]
        public ActionResult ObtenerRecuperarUsr(VMInventario model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Usuario.ActualizarDatosRecuperarUsuarios(model);
                if (resultado)
                {
                    return RedirectToAction("Login", "Login");
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