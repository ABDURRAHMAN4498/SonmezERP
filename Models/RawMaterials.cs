using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SonmezERP.Models
{
    public class RawMaterials
    {
        [Key]
        public int Id { get; set; }
        //hammadde adı
        [Display(Name ="Hammadde Adı")]
        [Required(ErrorMessage ="Lütfen hammadde adını giriniz!!")]
        public string? RawMaterialsName { get; set; }
        [Display(Name ="Stok")]
        [Required(ErrorMessage ="Lütfen stok miktarını giriniz!!")]
        public int Stock { get; set; }
    }
}
