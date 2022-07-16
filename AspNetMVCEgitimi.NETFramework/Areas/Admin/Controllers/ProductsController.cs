using AspNetMVCEgitimi.NETFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCEgitimi.NETFramework.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        DatabaseContext context = new DatabaseContext();
        // GET: Admin/Products
        public ActionResult Index()
        {
            return View(context.Products.ToList()); // view a db deki product ları gönder
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Products/Create
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid) // Eğer model geçerlilik kurallarına uyulmuşsa
            {
                try
                {
                    // TODO: Add insert logic here
                    if (Image != null)
                    {
                        Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                        product.Image = Image.FileName;
                    }
                    context.Products.Add(product);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Product product = context.Products.Find(id);

            return View(product);
        }

        // POST: Admin/Products/Edit/5
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

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Products/Delete/5
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
