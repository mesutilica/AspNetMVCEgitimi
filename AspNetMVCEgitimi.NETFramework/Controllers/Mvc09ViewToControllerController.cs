using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCEgitimi.NETFramework.Controllers
{
    public class Mvc09ViewToControllerController : Controller
    {
        // GET: Mvc09ViewToController
        public ActionResult Index(string txtAra) // Mvc de ındex metodu içerisine bu şekilde parametre ekleyerek ön yüzden gönderilen veriyi yakalayabiliyoruz. Dikkat! eşleşme sağlanabilmesi için ön yüzdeki elemanın name bilgisi ile buradaki değişken bilgisinin aynı isimde olması lazım yoksa eşleşmez!!!
        {
            ViewBag.GetVerisi = "Aranan kelime : " + txtAra;
            return View();
        }
        [HttpPost] // aşağıdaki metodun sadece post işlemlerinde çalışmasını sağlar
        public ActionResult Index(string text1, string ddlListe, bool cbOnay)
        {
            //1. yöntem parametrelerden gelen veri;
            ViewBag.Mesaj = "textboxdan gelen veri : " + text1;
            ViewData["Vdata"] = "checkboxdan gelen veri : " + cbOnay;
            TempData["Tdata"] = "listboxdan gelen veri : " + ddlListe;

            //2. yöntem Request.Form ile sayafadaki elementlerden veri alma
            var txt = Request.Form["text1"];
            var ddl = Request.Form["ddlListe"];
            //var chb = Request.Form["cbOnay"]; true,false dönüyor
            var chb = Request.Form.GetValues("cbOnay")[0];

            ViewBag.Mesaj2 = "textboxdan gelen veri 2 : " + txt;
            ViewData["Vdata2"] = "checkboxdan gelen veri 2 : " + chb;
            TempData["Tdata2"] = "listboxdan gelen veri 2 : " + ddl;

            return View();
        }
    }
}