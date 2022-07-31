using System.ComponentModel.DataAnnotations;

namespace AspNetMVCEgitimi.NETCore.Models
{
    public class AdminLoginViewModel
    {
        [Display(Name = "Kullanıcı Adı"), Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez!"), StringLength(50)]
        public string Username { get; set; }
        [Display(Name = "Şifre"), Required(ErrorMessage = "Şifre Boş Geçilemez!"), StringLength(50), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
