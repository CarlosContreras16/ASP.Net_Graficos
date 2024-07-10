using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Datos;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public JsonResult Reporteventas()
        {
            DT_REPORTE objDT_REPORTE = new DT_REPORTE();

            List<Reporteventa> objLista = objDT_REPORTE.RetornarVentas();

            return Json(objLista, JsonRequestBehavior.AllowGet);


        }

        [HttpGet]
        public JsonResult Reportedispensador()
        {
            DT_REPORTE objDT_REPORTE = new DT_REPORTE();

            List<Reporte_dispensador> objLista = objDT_REPORTE.Retornardispensador();

            return Json(objLista, JsonRequestBehavior.AllowGet);
        }
    }
}
