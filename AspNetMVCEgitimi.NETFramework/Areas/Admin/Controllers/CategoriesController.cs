using AspNetMVCEgitimi.NETFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCEgitimi.NETFramework.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        DatabaseContext context = new DatabaseContext();
        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View(context.Categories.ToList()); // veritabanındaki kategorilerin listesini view a gönder
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                // TODO: Add insert logic here
                context.Categories.Add(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(category);
            }
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
