using System.Runtime.Intrinsics.Wasm;

namespace SonmezERP.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public string ProductNameTr { get; set; } = string.Empty;
        public string ProductNameEn { get; set; } = string.Empty;
        public float PriceTl { get; set; }
        public float PriceUSD { get; set; }
        public int ProductWidth { get; set; }
        public int ProductHight { get; set; }
        public int ProductSize { get; set; }
        public float ProductWeight { get; set; }
        public int PackageWidth { get; set; }
        public int PackageSize{ get; set; }
        public int PackageHight { get; set; }
        public int PackagePices { get; set; }
        public float CubicMeter { get; set; }
        public int Tir { get; set; }
        public int Container { get; set; }
        public string? Coordinate { get; set; }


    }
}

