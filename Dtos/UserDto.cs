using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Dtos
{
    public record UserDto
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "İsim alanı boş geçilemez!.")]
        public string Name { get; set; }
        
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Soyadı alanı boş geçilemez")]
        public string Surname { get; set; }
       
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Kullanıcı Adı alanı boş geçilemez.")]
        public string? UserName { get; init; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email alanı boş geçilemez..")]
        public string? Email { get; init; }
        
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; init; }
        
        public HashSet<string> Roles { get; set; } = new HashSet<string>();
    }
}
