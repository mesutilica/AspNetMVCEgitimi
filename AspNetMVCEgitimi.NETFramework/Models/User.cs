using System.ComponentModel.DataAnnotations;

namespace AspNetMVCEgitimi.NETFramework.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "Kullanıcı Adı"), Required, StringLength(50)]
        public string Username { get; set; }
        [Display(Name = "Şifre"), Required, StringLength(50)]
        public string Password { get; set; }
        [Display(Name = "Aktif?")]
        public bool IsActive { get; set; }
        [Display(Name = "Admin?")]
        public bool IsAdmin { get; set; }
    }
}