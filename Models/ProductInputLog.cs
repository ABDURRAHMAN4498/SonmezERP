using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace SonmezERP.Models
{
    public class ProductInputLog
    {
        public int Id { get; set; }
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ActionDate { get; set; } = DateTime.Now;
        public List<ProductInputLogList> Inputs { get; set; } = new List<ProductInputLogList>();
    }
}
