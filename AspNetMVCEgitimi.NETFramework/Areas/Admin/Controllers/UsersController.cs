using AspNetMVCEgitimi.NETFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AspNetMVCEgitimi.NETFramework.Areas.Admin.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        DatabaseContext context = new DatabaseContext();
        // GET: Admin/Users
        public ActionResult Index()
        {
            return View(context.Users.ToList());
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Users/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                // TODO: Add insert logic here
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(user);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View(context.Users.Find(id));
        }

        // POST: Admin/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View();
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View(context.Users.Find(id));
        }

        // POST: Admin/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                // TODO: Add delete logic here
                context.Entry(user).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
