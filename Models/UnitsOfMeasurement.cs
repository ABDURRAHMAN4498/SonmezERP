using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{   //ölçü birimleri
    public class UnitsOfMeasurement
    {
        [Key]
        public int Id { get; set; }
        //ölçü birimi
        public string UnitsOfMeasurementName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
