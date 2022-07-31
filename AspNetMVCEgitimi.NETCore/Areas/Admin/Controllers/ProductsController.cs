using AspNetMVCEgitimi.NETCore.Models;
using AspNetMVCEgitimi.NETCore.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AspNetMVCEgitimi.NETCore.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class ProductsController : Controller
    {
        DatabaseContext context = new();
        // GET: ProductsController
        public async Task<ActionResult> IndexAsync(string search)
        {
            if (!(string.IsNullOrWhiteSpace(search))) // Eğer search parametresi doluysa
            {
                return View(await context.Products.Where(s => s.Name.Contains(search)).ToListAsync()); // ürünlere filtre uygula
            }
            return View(await context.Products.Include(c => c.Category).ToListAsync()); // include metodu join işlemi yaparak 2 tabloyu birleştirir
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.CategoryId = new SelectList(await context.Categories.ToListAsync(), "Id", "Name");
            ViewBag.BrandId = new SelectList(await context.Brands.ToListAsync(), "Id", "Name");
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product product, IFormFile? Image)
        {
            try
            {
                product.Image = await FileHelper.FileLoaderAsync(Image);
                await context.Products.AddAsync(product);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            ViewBag.CategoryId = new SelectList(await context.Categories.ToListAsync(), "Id", "Name");
            ViewBag.BrandId = new SelectList(await context.Brands.ToListAsync(), "Id", "Name");
            return View(product);
        }

        // GET: ProductsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(await context.Categories.ToListAsync(), "Id", "Name");
            ViewBag.BrandId = new SelectList(await context.Brands.ToListAsync(), "Id", "Name");
            return View(await context.Products.FindAsync(id));
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Product product, IFormFile? Image)
        {
            try
            {
                if (Image != null) product.Image = await FileHelper.FileLoaderAsync(Image);
                context.Entry(product).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            ViewBag.CategoryId = new SelectList(await context.Categories.ToListAsync(), "Id", "Name");
            ViewBag.BrandId = new SelectList(await context.Brands.ToListAsync(), "Id", "Name");
            return View(product);
        }

        // GET: ProductsController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            return View(await context.Products.FindAsync(id));
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Product product)
        {
            try
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
