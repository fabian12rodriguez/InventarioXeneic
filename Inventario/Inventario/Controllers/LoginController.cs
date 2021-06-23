using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventario.AccesoDatos;
using Inventario.ViewModels;

namespace Inventario.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(VMInventario model)
        {
            if (ModelState.IsValid)
            {
                VMInventario resultado = AD_Inventario.ValidarUsuario(model);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        /*public ActionResult ObtenerArticulo(VMInventario model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Inventario.ValidarUsuario(model);
                if (resultado)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(model);
                }
            }
            return View();
        }
        */
    }
}