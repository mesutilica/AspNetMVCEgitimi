using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCEgitimi.NETFramework.Controllers
{
    public class Mvc01RazorSyntaxController : Controller
    {
        // GET: Mvc01RazorSyntax
        public ActionResult Index() // Mvc de View sayfası otomatik oluşmaz! Bizim oluşturmamız gerekir. Bir view oluşturmak için Action adına(Index) sağ  tıklayıp add view diyerek açılan pencereden ayarlarını belirleyip view oluştururuz.
        {
            return View();
        }
    }
}