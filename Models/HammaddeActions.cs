using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace SonmezERP.Models
{
    public class HammaddeActions
    {
        public int Id { get; set; }
        [ForeignKey("Hammadde")]
        public int HammaddeId { get; set; }
        public Hammadde Hammmadde{ get; set; }
        public int  HammaddeKG { get; set; }
        public DateTime ActionDate{ get; set; }
    }
}
