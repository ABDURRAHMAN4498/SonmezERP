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
        public Brands Brand { get; set; }
        public int CategoryId { get; set; }
        public Categoreis Category { get; set; }
        public string ProductNameTr { get; set; }
        public string ProductNameEn { get; set; }
        public int ColorId { get; set; }
        public Colors Color { get; set; }
        public float PriceTl { get; set; }
        public float PriceUSD { get; set; }

        public int KdvId { get; set; }
        public Kdvs Kdv { get; set; }
        public int BirimId { get; set; }
        public Birimler Birim { get; set; }

        public int ProductDetailsId { get; set; }
        public ProductDetails ProductDetails { get; set; }
        public DateTime CeateDate { get; set; }
    }
}

