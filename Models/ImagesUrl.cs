using System.Configuration;

namespace SonmezERP.Models
{
    public class ImageUrl
    {
        public int Id { get; set; }
        public string? ImageUrlPath { get; set; }
        public ICollection<Product>? Products { get; set; }
        

    }
}
