using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Kategory")]
        [Required(ErrorMessage = "Kategory Adı Alanı Boş Geçilemez")]
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
