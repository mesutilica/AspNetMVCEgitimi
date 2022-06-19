using AspNetMVCEgitimi.NETFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCEgitimi.NETFramework.Controllers
{
    public class Mvc11ModelValidationController : Controller
    {
        // GET: Mvc11ModelValidation : Validation ile model class larımızda doğrulama işlemi yaparız
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult YeniUye()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniUye(Uye uye)
        {
            if (ModelState.IsValid) //ModelState IsValid parametreden gelen uye nesnesinin validation kurallarını denetler ve kurallara uyulmuşsa kod bloğundaki kodları çalıştırır
            {
                ViewBag.UyeBilgi = $"Üye Adı : {uye.Ad} <hr /> Üye Soyad : {uye.Soyad} <hr /> Üye Mail : {uye.Email} <hr /> Üye TC : {uye.TcKimlikNo}";
            }

            return View();
        }
        public ActionResult UyeDuzenle(int? id) // üye düzenlemenin get metodunda id parametresi beklenir çünkü bu id ye göre ilgili üye bilgileri ekrana getirilir
        {
            Uye uye = new Uye()
            {
                Id = 1,
                Ad = "Fatih",
                Soyad = "Sultan",
                Email = "fatih@sultan.net",
                TcKimlikNo = "000001453"
            };
            return View(uye);
        }
        [HttpPost]
        public ActionResult UyeDuzenle(Uye uye)
        {
            if (ModelState.IsValid) //ModelState IsValid parametreden gelen uye nesnesinin validation kurallarını denetler ve kurallara uyulmuşsa kod bloğundaki kodları çalıştırır
            {
                ViewBag.UyeBilgi = $"Üye Adı : {uye.Ad} <hr /> Üye Soyad : {uye.Soyad} <hr /> Üye Mail : {uye.Email} <hr /> Üye TC : {uye.TcKimlikNo}";
            }

            return View(uye); // uye nesnesini view a geri yolla
        }
        public ActionResult UyeListesi()
        {
            var uyeListesi = new List<Uye>() {
            new Uye()
            {
                Id = 1,
                Ad = "Fatih",
                Soyad = "Sultan",
                Email = "fatih@sultan.net",
                TcKimlikNo = "000001453"
            },
            new Uye()
            {
                Id = 2,
                Ad = "Mesut",
                Soyad = "Ilıca",
                Email = "mesutilica@gmail.com",
                TcKimlikNo = "0000014531984"
            },
            new Uye()
            {
                Id = 3,
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "murat@yilmaz.net",
                TcKimlikNo = "00000182534"
            }
            };
            return View(uyeListesi); // view a uyelistesi nesnesini gönderdik
        }
        public ActionResult UyeSil(int? id) // üye düzenlemenin get metodunda id parametresi beklenir çünkü bu id ye göre ilgili üye bilgileri ekrana getirilir
        {
            Uye uye = new Uye()
            {
                Id = 1,
                Ad = "Fatih",
                Soyad = "Sultan",
                Email = "fatih@sultan.net",
                TcKimlikNo = "000001453"
            };
            return View(uye);
        }
        [HttpPost]
        public ActionResult UyeSil()
        {
            // burada kayıt veritabanından silinir ve sayfa liste ekranına yönlendirilir
            TempData["Mesaj"] = "<div class='alert alert-danger'>Kayıt Silindi!</div>";
            return View();
        }
    }
}