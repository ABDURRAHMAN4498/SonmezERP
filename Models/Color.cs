using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ColorName { get; set; }
        [Required]
        public string Note { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
