using AspNetMVCEgitimi.NETFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCEgitimi.NETFramework.Areas.Admin.Controllers
{
    [Authorize] // Bu controller daki tüm actionlara oturum açmayı zorunlu kıl
    public class ProductsController : Controller
    {
        DatabaseContext context = new DatabaseContext();
        // GET: Admin/Products
        public ActionResult Index(string search)
        {
            if (!(string.IsNullOrWhiteSpace(search))) // Eğer search parametresi doluysa
            {
                return View(context.Products.Where(s => s.Name.Contains(search)).ToList()); // ürünlere filtre uygula
            }
            return View(context.Products.ToList()); // view a db deki product ları gönder
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int id)
        {
            return View(context.Products.Find(id));
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(context.Categories.ToList(), "Id", "Name"); // yeni bir select list oluşturup içine kategorileri doldurup viewbag e yükledik ve sayfaya gönderdik
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
            ViewBag.CategoryId = new SelectList(context.Categories.ToList(), "Id", "Name");
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
            ViewBag.CategoryId = new SelectList(context.Categories.ToList(), "Id", "Name", product.CategoryId); // product.CategoryId seçeneği seçili kategoriyi ayarlamak için kullanılır.
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image != null)
                    {
                        Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                        product.Image = Image.FileName;
                    }
                    context.Entry(product).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.CategoryId = new SelectList(context.Categories.ToList(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View(context.Products.Find(id));
        }

        // POST: Admin/Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                // TODO: Add delete logic here
                context.Entry(product).State = EntityState.Deleted;
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
