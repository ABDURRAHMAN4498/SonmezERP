using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Dtos
{
    public record ResetPasswordDto
    {
        [Required(ErrorMessage ="Ad alanı boş geçilemez!")]
        [Display(Name ="Ad")]
        [DataType(DataType.Text)]
        public string?  Name { get; set; }
        [Display(Name = "Soyad")]
        [Required(ErrorMessage ="Soyad alanı boş geçilemez")]
        [DataType(DataType.Text)]
        public string? SureName { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        
        public string? UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "şifre alanı gerekli!!")]
        [Display(Name = "Şifre")]
        public string? Password { get; set; }
        [Display(Name = "Şifre onaylama ")]
        [Required(ErrorMessage = "şifre onaylama alanı gerekli!!")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Şifreler eşleşmiyor")]
        public string? ConfirmPassword { get; set; }
    }
}