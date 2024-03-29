namespace SonmezERP.Models
{
    public class ProductLog
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Input { get; set; }
        public int Output { get; set; }
        public bool LogType { get; set; }
        public DateTime ActionDate { get; set; }


    }
}
