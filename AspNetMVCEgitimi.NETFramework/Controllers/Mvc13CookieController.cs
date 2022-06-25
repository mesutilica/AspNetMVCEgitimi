using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCEgitimi.NETFramework.Controllers
{
    public class Mvc13CookieController : Controller
    {
        // GET: Mvc13Cookie
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string kuki)
        {
            HttpCookie httpCookie = new HttpCookie("kullanici", kuki) // 1. parametre oluşacak cookie ismi, 2. parametre bu cookie deki veri
            {
                Expires = DateTime.Now.AddMinutes(18) // Expires ile cookie nin yaşam süresini ayarlıyoruz
            };
            HttpContext.Response.Cookies.Add(httpCookie); // Oluşturduğumuz cookie yi kullanıcının cihazına yerleştiriyoruz
            return View();
        }
        public ActionResult CookieOku()
        {
            if (HttpContext.Request.Cookies["kullanici"] == null) // CookieOku sayfasında ilgili cookie var mı
            {
                ViewBag.Kullanici = "Cookie Yok";
            }
            else ViewBag.Kullanici = "Cookie Değeri : " + HttpContext.Request.Cookies["kullanici"].Value; // Eğer cookie varsa değerini ekrana yolla

            return View();
        }
        [HttpPost]
        public ActionResult CookieOku(string kuki)
        {
            if (HttpContext.Request.Cookies["kullanici"] != null) // Eğer cookie varsa
            {
                HttpContext.Response.Cookies["kullanici"].Expires = DateTime.Now.AddSeconds(-1); // cookie nin süresini bitir
            }
            return RedirectToAction("CookieOku"); // sayfayı yeniden yönlendir
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string kullaniciAdi, string sifre)
        {
            // burada veritabanından kullanıcı sorgulaması yapılır
            if (kullaniciAdi == "admin" && sifre == "123456")
            {
                HttpCookie httpCookie = new HttpCookie("yonetici", kullaniciAdi)
                {
                    Expires = DateTime.Now.AddMinutes(18)
                };
                HttpContext.Response.Cookies.Add(httpCookie);
            }
            else
            {
                TempData["Kullanici"] = "Giriş Başarısız!";
            }
            return View();
        }
    }
}