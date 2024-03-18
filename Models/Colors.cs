using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class Colors
    {
        [Key]
        public int Id { get; set; }
        public string Color { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
