using System.ComponentModel.DataAnnotations;

namespace SonmezERP.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="Bu Alan Boş Geçilemez")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]

        public string  Surname { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]

        public string UserName { get; set; }
        [Compare("Password",ErrorMessage ="Bu Alan Boş Geçilemez")]
        public string Password { get; set; }
    }
}
