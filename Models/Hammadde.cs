using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SonmezERP.Models
{
    public class Hammadde
    {
        [Key]
        public int Id { get; set; }
        public string HammaddeName { get; set; }
        [ForeignKey("Suplier")]
        public int SuplierId { get; set; }
        public Suppliers Suplier { get; set; }
        [ForeignKey("Color")]
        public int ColorId { get; set; }
        public Colors Color { get; set; }
        public int Stok { get; set; }
        [ForeignKey("Birim")]
        public int BirimId { get; set; }
        public Birimler Birim { get; set; }
        public string RecycleOrOrginal { get; set; }


    }
}
