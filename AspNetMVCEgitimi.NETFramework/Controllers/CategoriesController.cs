using AspNetMVCEgitimi.NETFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCEgitimi.NETFramework.Controllers
{
    public class CategoriesController : Controller
    {
        DatabaseContext context = new DatabaseContext();
        // GET: Categories
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(context.Categories.Find(id));
        }
    }
}