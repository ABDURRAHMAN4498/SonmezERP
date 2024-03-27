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
        public string ProductCode { get; set; }
        public string Barcode { get; set; }
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        [Display(Name ="Ürün Adı")]
        public string ProductNameTr { get; set; }
        [Display(Name ="Product Name")]
        public string ProductNameEn { get; set; }
        public int ColorId { get; set; }
        public Color? Color { get; set; }
        public float PriceTl { get; set; }
        public float PriceUSD { get; set; }
        public int KdvId { get; set; }
        public Kdv? Kdv { get; set; }
        public int UnitsOfMeasurementId { get; set; }
        public UnitsOfMeasurement? UnitsOfMeasurementName { get; set; }
        public int ProductDetailsId { get; set; }
        public ProductDetails? ProductDetails { get; set; }
        public DateTime CeateDate { get; set; }
    }
}

