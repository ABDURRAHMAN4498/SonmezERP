using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class ProductOutputLog
    {
        public int Id { get; set; }
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ActionDate { get; set; } = DateTime.Now;
        public List<ProductOutputLogList> Outputs { get; set; } = new List<ProductOutputLogList>();
    }
}
