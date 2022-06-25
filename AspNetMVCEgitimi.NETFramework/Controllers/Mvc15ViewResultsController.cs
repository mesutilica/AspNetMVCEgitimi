using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCEgitimi.NETFramework.Controllers
{
    public class Mvc15ViewResultsController : Controller
    {
        // GET: Mvc15ViewResults
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Yonlendir()
        {
            //return Redirect("/Home/Index"); // Anasayfaya yönlendir
            //return Redirect("/Home/Index?kelime=monitör"); // parametreyle yönlendirme
            return Redirect("https://www.google.com.tr/"); // dış linke yönlendirme
        }
        public RedirectToRouteResult RoutaYonlendir()
        {
            return RedirectToRoute("Default", new { controller = "Session", action = "Index", id = 18 });
        }
        public PartialViewResult KategorileriGetirPartial()
        {
            return PartialView("_KategorilerPartial"); // Bu action tetiklendiğinde geriye _KategorilerPartial isimli partial view ı gönder
        }
        public PartialViewResult KategorileriModelleGetirPartial()
        {
            List<string> kategoriler = new List<string>()
            {
                "Bilgisayar",
                "Monitör",
                "Klavye",
                "Mouse",
                "Telefon"
            };
            return PartialView("_KategorilerPartial2", kategoriler);
        }
    }
}