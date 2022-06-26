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
        public FileResult PdfDosyaGoruntule()
        {
            string dosyayolu = Server.MapPath("/mvc.pdf");
            return new FilePathResult(dosyayolu, "application/pdf");
        }
        public FileStreamResult MetinDosyasiIndir()
        {
            string metin = "FileStreamResult ile metin dosyası indirme";

            System.IO.MemoryStream memory = new System.IO.MemoryStream(); // Memorystream nesnesi oluştur
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(metin); // byte dizisi oluştur ve yukardaki metin içeriğini byte dizisine çevir

            memory.Write(bytes, 0, bytes.Length); // memory nesnesine byte dizisini yazdır
            memory.Position = 0;

            FileStreamResult result = new FileStreamResult(memory, "text/plain"); // geri dönüş türünü oluştur(memory deki nesne ve dosya türü)
            result.FileDownloadName = "deneme.txt"; // indirilecek dosya adını belirle

            return result; // geriye dosyayı dön
        }
        public JavaScriptResult JsResult()
        {
            string js = "alert('Js Result Çalıştı!')";
            return JavaScript(js);
        }
        public JavaScriptResult JsButtonClick()
        {
            string js = "function button_click(){alert('JsButtonClick Çalıştı!');}";
            return JavaScript(js);
        }
        public JsonResult JsonGoruntule()
        {
            var kullanici = new Models.Kullanici
            {
                Ad = "Mahmut",
                Email = "mahmut@site.com",
                Id = 1,
                KullaniciAdi = "mahmut",
                Sifre = "123456",
                Soyad = "Demirci"
            };
            return Json(kullanici, JsonRequestBehavior.AllowGet); // json veriyi dışarıdan gelecek get isteklerine açmak için
        }
        public ContentResult XmlContentResult()
        {
            var xml = @"
            <kullanicilar>
                <kullanici>
                    <Id>18</Id>
                    <Ad>Mesut</Ad>
                    <Soyad>Ilıca</Soyad>
                    <Email>null</Email>
                </kullanici>
                <kullanici>
                    <Id>25</Id>
                    <Ad>Murat</Ad>
                    <Soyad>Yılmaz</Soyad>
                    <Email>murat@gmail.co</Email>
                </kullanici>
            </kullanicilar>";

            return Content(xml, "application/xml");
        }
    }
}