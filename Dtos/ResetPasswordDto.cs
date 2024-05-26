using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Dtos
{
    public record ResetPasswordDto
    {
        [DataType(DataType.Text)]
        public string? UserName { get; init; }
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "şifre alanı gerekli!!")]
        [Display(Name = "Şifre")]
        public string? Password { get; init; }
        
        [Display(Name = "Şifre onaylama ")]
        [Required(ErrorMessage = "şifre onaylama alanı gerekli!!")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Şifreler eşleşmiyor")]
        public string? ConfirmPassword { get; init; }
    }
}