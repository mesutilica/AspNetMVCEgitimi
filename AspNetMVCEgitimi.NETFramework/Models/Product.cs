using System.ComponentModel.DataAnnotations;

namespace AspNetMVCEgitimi.NETFramework.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Ürün Adı"), Required, StringLength(100)]
        public string Name { get; set; }
        [Display(Name = "Stok")]
        public int Stock { get; set; }
        [Display(Name = "Ürün Fiyatı")]
        public decimal Price { get; set; }
        [Display(Name = "Ürün Resmi"), StringLength(100)]
        public string Image { get; set; }
        [Display(Name = "Ürün Kategorisi")]
        public int CategoryId { get; set; } // Navigation property
        public virtual Category Category { get; set; } // Category tablosu ile Product arasında ilişki kurduk
        // Classlar arasında ilişki kurduktan sonra migrationsu aktif etmemiz gerekiyor.
        // Visual studio üst menüsünde Tools > Nuget Package Manager > Package Manager Console yolunu izleyerek Pmc alanını açmamız gerekiyor.
        // PMC alanına enable-migrations diyerek enter ile migrations ı aktif ediyoruz
        // Proje içerisine Migrations klasörü ve bu klasör içerisine Configuration ve InitialCreate class ları oluşturulur
        // enable-migrations 1 kerelik yapılır sonrasında bu komutu yazmıyoruz bunun yerine her değişiklikte add-migration migrationİsmi enter diyerek yeni değişiklikleri yapıyoruz.
        // son olarak yaptığımız değişikliklerin veritabanına işlenmesi için update-database komutu çalıştırılır
    }
}