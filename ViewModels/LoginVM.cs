using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SonmezERP.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı Adı Alanı Boş Geçilemez!")]
        public string? UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Şifre Alanı Boş Geçilemez!")]
        [Display(Name ="Şifre")]
        public string? Password { get; set; }

        [Display(Name ="Beni Hatırla")]
        public bool RememberMe { get; set; }
        private string? _returnurl;
        public string Returnurl { get
            {
                if (_returnurl is null)
                {
                    return "/";
                }
                else
                    return _returnurl;
            }
            set
            {
                _returnurl = value;
            } }

    }
}
