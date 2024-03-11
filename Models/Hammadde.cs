namespace SonmezERP.Models
{
    public class Hammadde
    {
        public int Id { get; set; }
        public string? HammaddeName { get; set; }
        public Colors? Color { get; set; }
        public int Stok { get; set; }
        public Birimler? Birim { get; set; }
    }
}
