using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class Birimler
    {
        [Key]
        public int Id { get; set; }
        public string Birim { get; set; } = string.Empty;
    }
}
