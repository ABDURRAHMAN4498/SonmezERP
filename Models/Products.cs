using System.Runtime.Intrinsics.Wasm;

namespace SonmezERP.Models
{
    public class Products
    {
        public int Id { get; set; }
        public bool Visiblity { get; set; } 
        public string ProductCode { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public Brands? Brand { get; set; }
        public Categoreis? Category { get; set; }
        public string ProductNameTr { get; set; } = string.Empty;
        public string ProductNameEn { get; set; } = string.Empty;
        public Colors? Color { get; set; }
        public float PriceTl { get; set; }
        public float PriceUSD { get; set; }
        public Kdvs? Kdv { get; set; }
        public Birimler? Birim { get; set; }
        public ProductDetails? ProductDetails { get; set; }
        public DateTime CeateDate { get; set; }
        public users { get; set; }
    }
}

