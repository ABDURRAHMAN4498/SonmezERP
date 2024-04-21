using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class ProductInputLogList
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product{ get; set; }
        [Display(Name = "Girilen Miktar")]
        public int InputQuantity { get; set; }
        public DateTime dateTime { get; set; }
    }
}
