using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace SonmezERP.Models
{
    public class RawMaterialsInputActions
    {
        public int Id { get; set; }
        
        public int HammaddeId { get; set; }
        public RawMaterials? Hammmadde{ get; set; }
        
        public int Amout { get; set; }
        public DateTime ActionDate{ get; set; }
    }
}
