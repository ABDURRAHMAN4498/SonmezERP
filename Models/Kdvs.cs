namespace SonmezERP.Models
{
    public class Kdvs
    {
        public int Id { get; set; }
        public float Kdv { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
