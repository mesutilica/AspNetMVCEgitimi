using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetMVCEgitimi.NETFramework.Models;

namespace AspNetMVCEgitimi.NETFramework.Controllers
{
    public class Mvc10ModelBindingController : Controller
    {
        // GET: Mvc10ModelBinding
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Kullanici()
        {
            Kullanici kullanici = new Kullanici()
            {
                Ad = "Ali",
                Soyad = "Demirci",
                Email = "info@site.com",
                KullaniciAdi = "ali",
                Sifre = "123456"
            };
            return View(kullanici); // yukarıda oluşturduğumuz kullanici nesnesini sayfa ön yüzüne bu şekilde gönderdik.
        }
        [HttpPost]
        public ActionResult Kullanici(Kullanici kullanici) // post metodunda ön yüzden gönderilen modeli parametre ile elde edebiliriz
        {
            ViewBag.Mesaj = "Kullanıcı Adı : " + kullanici.Ad;
            ViewData["Vdata"] = "Kullanıcı Soyadı : " + kullanici.Soyad;
            TempData["Tdata"] = "Kullanıcı Email : " + kullanici.Email;

            return View(kullanici); // post işleminden sonra kullanici nesnesini sayfaya tekrar geri gönderebiliriz
        }
        public ActionResult Adres()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adres(Adres adres)
        {
            ViewBag.Mesaj = "Şehir : " + adres.Sehir; // ön yüze şehir verisi gönderiyoruz
            ViewData["Vdata"] = "İlçe : " + adres.Ilce;// View a ilçe verisi gönderiyoruz
            TempData["Tdata"] = "Açık Adres : " + adres.AcikAdres; // tempdata 2 kez kullanılabilir diğerleri 1 kez

            return View(adres); // burada post işleminden sonra adres nesnesini view a göndermezsek null reference hatası alırız!
        }
        public ActionResult UyeSayfasi()
        {
            Kullanici kullanici = new Kullanici()
            {
                Ad = "Ali",
                Soyad = "Demirci",
                Email = "info@site.com",
                KullaniciAdi = "ali",
                Sifre = "123456"
            };
            var model = new UyeSayfasiViewModel()
            {
                Kullanici = kullanici,
                Adres = new Adres { Sehir = "Çankırı", Ilce = "Atkaracalar", AcikAdres = "Demirli Köyü"}
            };
            return View(model); // sayfa modelini view a göndermeyi unutma!
        }
    }
}