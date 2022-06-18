using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCEgitimi.NETFramework.Controllers
{
    public class Mvc08ControllerToViewController : Controller
    {
        // GET: Mvc08ControllerToView : Mvc Controller dan View a veri gönderme
        public ActionResult Index()
        {
            ViewBag.KategoriAdi = "Bilgisayar";
            ViewData["UrunAdi"] = "Lenovo Tablet";
            TempData["UrunFiyati"] = "1990";
            return View();
        }
    }
}