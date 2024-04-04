using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class ProductLog
    {
        public int Id { get; set; }
        [Display(Name = "Ürün")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Display(Name ="Girilecek Miktar")]
        public int Input { get; set; }
        [Display(Name ="Çıkılacak Miktar")]
        public int Output { get; set; }
        public bool LogType { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ActionDate { get; set; }


    }
}
