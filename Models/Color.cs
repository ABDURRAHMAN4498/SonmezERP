using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Renk")]
        [Required(ErrorMessage = "Renk Alanı boş geçilemez!")]
        public string ColorName { get; set; }
        [Display(Name ="Açıklama")]
        public string Note { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
