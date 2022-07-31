using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimi.NETCore.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize] // .net core da area içerisindeki controller lara bu attribute ü eklememiz gerekiyor yoksa sayfalar açılmıyor!
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
