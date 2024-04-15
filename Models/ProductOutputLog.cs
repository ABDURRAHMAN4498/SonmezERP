using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class ProductOutputLog
    {
        public int Id { get; set; }

        [Display(Name = "Ürün")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public List<ProductOutputLogList> Outputs { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ActionDate { get; set; } = DateTime.Now;
    }
}
