using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Dtos
{
    public record UserDto
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "User is requaired.")]
        public string? UserName { get; init; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Email is requaired.")]
        public string? Email { get; init; }
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; init; }
        public HashSet<string> Roles { get; set; } = new HashSet<string>();
    }
}
