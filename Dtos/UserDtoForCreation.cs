using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Dtos
{
    public record UserDtoForCreation : UserDto
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password is requaired.")]
        public string? Password { get; init; }
    }
}
