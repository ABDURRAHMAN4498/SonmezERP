using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace SonmezERP.Models
{
    public class RawMaterialsActions
    {
        public int Id { get; set; }

        [ForeignKey("Hammadde")]
        public int HammaddeId { get; set; }
        public RawMaterials? Hammmadde{ get; set; }
        public bool HammaddeAction { get; set; }
        public int  HammaddeKG { get; set; }
        public DateTime ActionDate{ get; set; }
    }
}
