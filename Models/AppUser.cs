
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class AppUser:IdentityUser
    {
        [Display(Name ="Ad")]
        [Required(ErrorMessage ="Ad Alanı Boş Geçilemez")]
        public string Name { get; set; }

        [Display(Name="Soyad")]
        [Required(ErrorMessage = "Soyad Alanı Boş Geçilemez")]
        public string Surname { get; set; }
        //[Display(Name="Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı Adı Alanı Boş Geçilemez")]
        public string UserName { get; set; }

    }
}
