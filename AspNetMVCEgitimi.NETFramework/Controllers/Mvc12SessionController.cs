using System.Web.Mvc;

namespace AspNetMVCEgitimi.NETFramework.Controllers
{
    public class Mvc12SessionController : Controller
    {
        // GET: Mvc12Session : Sunucu tarafında güvenli bir şekilde farklı sayfalardan da ulaşabileceğimiz veri taşıma yöntemidir.
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string text)
        {
            // Session oluşturup değer atama
            Session["deger"] = text;
            // 2. Session oluşturma yöntemiz
            Session.Add("seysin", " 2. Session, Text Değeri : " + text);
            return View();
        }
        public ActionResult Sessions()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Sessions(string text)
        {
            Session.Remove("deger");
            Session["seysin"] = null;

            return View();
        }
    }
}