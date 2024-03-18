using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class Categoreis
    {
        [Key]
        public int Id { get; set; }
        public string? Category { get; set; }
    }
}
