using Humanizer;
using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class User
    {
        public int Id { get; set; }
        public int UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string? Foto { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        public string PhoneNo { get; set; }
    }
}
