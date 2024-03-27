using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public int ProductWidth { get; set; }
        public int ProductHight { get; set; }
        public int ProductSize { get; set; }
        public float ProductWeight { get; set; }
        public int PackageWidth { get; set; }
        public int PackageSize { get; set; }
        public int PackageHight { get; set; }
        public int PackagePices { get; set; }
        public float CubicMeter { get; set; }
        public int Tir { get; set; }
        public int Container { get; set; }
        public string? Coordinate { get; set; }
        public string Descreption { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
