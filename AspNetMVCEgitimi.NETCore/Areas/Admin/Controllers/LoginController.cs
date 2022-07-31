using AspNetMVCEgitimi.NETCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimi.NETCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public LoginController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminLoginViewModel adminLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var account = _databaseContext.Users.FirstOrDefault(u => u.Username == adminLoginViewModel.Username & u.Password == adminLoginViewModel.Password & u.IsAdmin & u.IsActive);
                    if (account == null)
                    {
                        ModelState.AddModelError("", "Giriş Başarısız!");
                    }
                    else
                    {

                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(adminLoginViewModel);
        }
    }
}
