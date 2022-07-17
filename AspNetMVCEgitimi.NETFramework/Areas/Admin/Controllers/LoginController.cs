using AspNetMVCEgitimi.NETFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Index(User user)
        {
            return View();
        }
    }
}