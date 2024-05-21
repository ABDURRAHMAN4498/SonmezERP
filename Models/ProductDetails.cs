using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class ProductDetails
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Kod")]
        public string? ProductCode { get; set; }
        [Display(Name ="En")]
        public int ProductWidth { get; set; }
        [Display(Name ="Boy")]
        public int ProductHight { get; set; }
        [Display(Name ="Yükseklik")]
        public int ProductSize { get; set; }
        [Display(Name ="Ağırlık")]
        public float ProductWeight { get; set; }
        [Display(Name ="Paket En")]
        public int PackageWidth { get; set; }
        [Display(Name ="Paket Boy")]
        public int PackageSize { get; set; }
        [Display(Name ="Yükseklik")]
        public int PackageHight { get; set; }
        [Display(Name ="Paket Adet")]
        public int PackagePices { get; set; }
        [Display(Name =" Paket MetreKüp")]
        public float CubicMeter { get; set; }
        [Display(Name ="TIR")]
        public int Tir { get; set; }
        [Display(Name ="Container")]
        public int Container { get; set; }
        [Display(Name ="Koordinat")]
        public string? Coordinate { get; set; }
        [Display(Name ="Açıklama")]
        public string? Descreption { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
