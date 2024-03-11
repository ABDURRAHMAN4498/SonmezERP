namespace SonmezERP.Models
{
    public class Colors
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
