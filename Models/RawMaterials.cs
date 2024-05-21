using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SonmezERP.Models
{
    public class RawMaterials
    {
        [Key]
        public int Id { get; set; }
        //hammadde adı
        public string? RawMaterialsName { get; set; }
        public int SuplierId { get; set; }
        public Suppliers? Suplier { get; set; }
        public int ColorId { get; set; }
        public Color? Color { get; set; }
        public int Stok { get; set; }
        public int UnitsOfMeasurementId { get; set; }
        public UnitsOfMeasurement? UnitsOfMeasurementName { get; set; }
        public string? RecycleOrOrginal { get; set; }
    }
}
