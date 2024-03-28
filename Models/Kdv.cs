using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class Kdv
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Vergi")]
        public float KdvName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
