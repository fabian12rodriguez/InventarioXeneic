using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventario.Models;
using Inventario.ViewModels;

namespace Inventario.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Graficos()
        {
            return View();
        }
        public JsonResult DataPastel()
        {
            SeriePastel serie = new SeriePastel();
            return Json(serie.GetDataDummy(), JsonRequestBehavior.AllowGet);
          /*  return Json(new { total = total, data = data }, JsonRequestBehavior.AllowGet);*/
        }
    }
}