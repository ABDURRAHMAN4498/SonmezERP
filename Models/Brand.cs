using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Marka")]
        public string BrandName { get; set; }
        public string Descraption { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
