using System.ComponentModel.DataAnnotations;

namespace AspNetMVCEgitimi.NETFramework.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Ürün Adı")]
        public string Name { get; set; }
        [Display(Name = "Stok")]
        public int Stock { get; set; }
        [Display(Name = "Ürün Fiyatı")]
        public decimal Price { get; set; }
        [Display(Name = "Ürün Resmi")]
        public string Image { get; set; }
    }
}