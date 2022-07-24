using AspNetMVCEgitimi.NETCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetMVCEgitimi.NETCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // S.O.L.I.D
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("deger", "deneme"); // session da key value ile değer saklayabiliyoruz
            return View();
        }

        public IActionResult Privacy()
        {
            TempData["data"] = HttpContext.Session.GetString("deger"); // TempData ile deger isimli sessiondaki bilgiyi yakalayıp ön yüze gönderiyoruz
            return View();
        }

        public IActionResult SessionSil()
        {
            HttpContext.Session.Remove("deger"); // sessionı sildik
            return RedirectToAction(nameof(Privacy));
        }

        public IActionResult CookieOlustur()
        {
            CookieOptions cookie = new()
            {
                Expires = DateTime.Now.AddMinutes(1)
            };
            Response.Cookies.Append("username", "Admin", cookie);
            Response.Cookies.Append("password", "123456", cookie);

            return RedirectToAction(nameof(CookieOku));
        }
        public IActionResult CookieOku()
        {
            TempData["kullanici"] = Request.Cookies["username"];
            TempData["parola"] = Request.Cookies["password"];

            return View();
        }

        public IActionResult CookieSil()
        {
            Response.Cookies.Delete("username");
            Response.Cookies.Delete("password");

            return RedirectToAction(nameof(CookieOku));
        }

        public IActionResult AppSetting()
        {
            TempData["Email"] = _configuration["Email"]; // TempData ile appsettings deki Email bilgisini okuyup view a gönderdik
            TempData["MailSunucu"] = _configuration["MailSunucu"];
            TempData["UserName"] = _configuration["MailKullanici:UserName"];
            TempData["Password"] = _configuration.GetSection("MailKullanici:Password").Value;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}