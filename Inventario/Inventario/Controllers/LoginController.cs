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
            VMInventario resultado = AD_Inventario.ValidarUsuario(model);

            if (resultado.Codigo_usuario != null & resultado.Password_usuario != null)
            {
                System.Web.HttpContext.Current.Session.Add("idRol", resultado.Id_rol);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mensaje = "Usuario o contraseña incorrectos";
                return View();
                
            }
        }
         public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }


    }
}