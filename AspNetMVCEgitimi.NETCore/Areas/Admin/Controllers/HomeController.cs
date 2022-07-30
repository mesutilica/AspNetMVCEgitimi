using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimi.NETCore.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
