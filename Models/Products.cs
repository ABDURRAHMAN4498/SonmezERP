using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.Wasm;

namespace SonmezERP.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public bool Visiblity { get; set; } 
        public string ProductCode { get; set; }
        public string Barcode { get; set; }
        [ForeignKey("Brand")]
        public int BrandsId { get; set; }
        public Brands Brand { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Categoreis Category { get; set; }
        public string ProductNameTr { get; set; }
        public string ProductNameEn { get; set; }
        [ForeignKey("Colors")]
        public int ColorId { get; set; }
        public Colors Color { get; set; }
        public float PriceTl { get; set; }
        public float PriceUSD { get; set; }
        [ForeignKey("Kdv")]
        public int KdvId { get; set; }
        public Kdvs Kdv { get; set; }
        [ForeignKey("Birim")]
        public int BirimId { get; set; }
        public Birimler Birim { get; set; }
        [ForeignKey("ProductDetails")]
        public int ProductDetailsId { get; set; }
        public ProductDetails ProductDetails { get; set; }
        public DateTime CeateDate { get; set; }
    }
}

