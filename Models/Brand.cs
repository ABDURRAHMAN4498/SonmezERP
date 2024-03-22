using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string BrandName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
