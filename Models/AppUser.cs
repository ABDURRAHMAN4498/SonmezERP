
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class AppUser:IdentityUser<int>
    {
        [Display(Name ="Ad")]
        public string Name { get; set; }
        [Display(Name="Soyad")]
        public string Surname { get; set; }
        [Display(Name="Kullanıcı Adı")]
        public string UserName { get; set; }

    }
}
