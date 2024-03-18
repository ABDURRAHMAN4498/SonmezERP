using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class Brands
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; }= string.Empty;
    }
}
