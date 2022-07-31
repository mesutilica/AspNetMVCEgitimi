using System.ComponentModel.DataAnnotations;

namespace AspNetMVCEgitimi.NETCore.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [Display(Name = "Marka Adı"), StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Marka Logo"), StringLength(50)]
        public string? Logo { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
