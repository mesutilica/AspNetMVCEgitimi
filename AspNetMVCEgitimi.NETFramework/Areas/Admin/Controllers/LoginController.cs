using AspNetMVCEgitimi.NETFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security; // Login için gerekli kütüphane

namespace AspNetMVCEgitimi.NETFramework.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        DatabaseContext context = new DatabaseContext();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user, string ReturnUrl) // ReturnUrl adres çubuğunda yer alan bir query string dir. login işleminden sonra kullanıcıyı gitmek istediği sayfaya yönlendirmede kullanılır
        {
            if (ModelState.IsValid)
            {
                var kullanici = context.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password && u.IsActive && u.IsAdmin);
                if (kullanici != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, true);
                    return ReturnUrl == null ? RedirectToAction("Index", "Products") : (ActionResult)Redirect(ReturnUrl);
                }
                else ModelState.AddModelError("", "Giriş Başarısız!");
            }
            return View(user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut(); // Çıkış yap
            return RedirectToAction("Index", "Login"); // kullanıcıyı logine yönlendir
        }
    }
}