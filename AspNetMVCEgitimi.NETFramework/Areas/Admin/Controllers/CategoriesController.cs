using AspNetMVCEgitimi.NETFramework.Models;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMVCEgitimi.NETFramework.Areas.Admin.Controllers
{
    [Authorize]
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
        public ActionResult Edit(int? id) // ? işareti id nin null olabileceğini belirtir
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var kategori = context.Categories.Find(id); // kategorilerden adres çubuğundan id si gönderileni bul

            return View(kategori);
        }

        // POST: Admin/Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                // TODO: Add update logic here
                context.Entry(category).State = System.Data.Entity.EntityState.Modified; // Bize ön yüzden gönderilen category nesnesini güncellenecek olarak değiştir.
                context.SaveChanges(); // Değişiklikleri veritabanına işle
                return RedirectToAction("Index");
            }
            catch
            {
                return View(category);
            }
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Category kategori = context.Categories.Find(id); // kategorilerden adres çubuğundan id si gönderileni bul

            return View(kategori);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                // TODO: Add delete logic here
                context.Entry(category).State = System.Data.Entity.EntityState.Deleted; // Silme sayfasından gönderilen category nesnesini yakala ve onu silinecek olarak işaretle
                context.SaveChanges(); // veritabanına değişiklikleri işle
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
