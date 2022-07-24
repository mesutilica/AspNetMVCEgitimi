using System.ComponentModel.DataAnnotations;

namespace AspNetMVCEgitimi.NETCore.Models
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
        public string? Image { get; set; }
        [Display(Name = "Ürün Kategorisi")]
        public int CategoryId { get; set; } // Navigation property
        public virtual Category? Category { get; set; } // Category tablosu ile Product arasında ilişki kurduk
    }
}
