namespace SonmezERP.Models
{
    public class Suppliers
    {
        //tedariçiler tablosu
        public int Id { get; set; }
        public string SuplierName { get; set; }
        public string suplierAddress { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Country { get; set; }
        public string? City{ get; set; }

    }
}
