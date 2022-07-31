using System.ComponentModel.DataAnnotations;

namespace AspNetMVCEgitimi.NETCore.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Ürün Adı"), Required(ErrorMessage = "Boş Geçilemez!"), StringLength(100)]
        public string Name { get; set; }
        [Display(Name = "Stok"), Required(ErrorMessage = "Boş Geçilemez!")]
        public int Stock { get; set; }
        [Display(Name = "Ürün Fiyatı"), Required(ErrorMessage = "Boş Geçilemez!")]
        public decimal Price { get; set; }
        [Display(Name = "Ürün Resmi"), StringLength(100)]
        public string? Image { get; set; }
        [Display(Name = "Ürün Kategorisi")]
        public int CategoryId { get; set; } // Navigation property
        [Display(Name = "Ürün Kategorisi")]
        public virtual Category? Category { get; set; } // Category tablosu ile Product arasında ilişki kurduk
        [Display(Name = "Ürün Markası")]
        public int? BrandId { get; set; }
        [Display(Name = "Ürün Markası")]
        public virtual Brand? Brand { get; set; }
    }
}
