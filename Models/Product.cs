using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.Wasm;

namespace SonmezERP.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public bool Visiblity { get; set; }
        [Display(Name ="Kod")]
        public string ProductCode { get; set; }
        public string Barcode { get; set; }
        public string? ımagePath { get; set; }
        [Display(Name ="Marka")]
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        [Display(Name ="Katregory")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        [Display(Name ="Ürün Adı")]
        public string ProductNameTr { get; set; }
        [Display(Name ="Product Name")]
        public string ProductNameEn { get; set; }
        public int ColorId { get; set; }
        public Color? Color { get; set; }
        [Display(Name ="Fiyat ₺")]
        public float PriceTl { get; set; }
        [Display(Name ="Fiyat $")]
        public float PriceUSD { get; set; }
        [Display(Name ="Stok")]
        public int Stock { get; set; }
        public int KdvId { get; set; }
        public Kdv? Kdv { get; set; }
        [Display(Name = "Unit Of Measurement")]
        public int UnitsOfMeasurementId { get; set; }
        public UnitsOfMeasurement? UnitsOfMeasurement { get; set; }
        [Display(Name ="Ürün Detayları")]
        public int ProductDetailsId { get; set; }
        public ProductDetails? ProductDetails { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CeateDate { get; set; }
        
    }
}

