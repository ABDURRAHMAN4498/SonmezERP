using System.ComponentModel.DataAnnotations;

namespace SonmezERP.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Ad")]
        [Required(ErrorMessage ="Bu Alan Boş Geçilemez")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
        [Display(Name ="Soyad")]
        public string  Surname { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
        //[Display(Name ="Kullanıcı Adı")]
        public string UserName { get; set; }


        [Display(Name ="Şifre")]
        public string Password { get; set; }

        [Display(Name ="Şifre Tekrarı")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmedi!")]
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
        public string ConfirmPassword { get; set; }

    }
}
