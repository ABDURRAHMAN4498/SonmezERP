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
        public int BrandsId { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public string ProductNameTr { get; set; }
        public string ProductNameEn { get; set; }
        public Color Color { get; set; }
        public float PriceTl { get; set; }
        public float PriceUSD { get; set; }
        public Kdv Kdv { get; set; }
        public UnitsOfMeasurement UnitsOfMeasurementName { get; set; }
        public ProductDetails ProductDetails { get; set; }
        public DateTime CeateDate { get; set; }
    }
}

