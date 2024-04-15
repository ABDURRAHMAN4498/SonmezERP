using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace SonmezERP.Models
{
    public class ProductInputLog
    {
        public int Id { get; set; }
        [Display(Name = "Ürün")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Display(Name ="Girilen Miktar Miktar")]
        public int Input { get; set; }
        [Display(Name ="Çıkılacak Miktar")]
        public int Output { get; set; }
        public bool LogType { get; set; }
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ActionDate { get; set; }
        
            
            


    }
}
