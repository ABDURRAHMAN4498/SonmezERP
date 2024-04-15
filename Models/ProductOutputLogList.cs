using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class ProductOutputLogList
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductOutputLogId { get; set; }
        public ProductOutputLog ProductOutputLog { get; set; }
        public int OutputQuantity { get; set; }
    }
}
