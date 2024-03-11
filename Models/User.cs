namespace SonmezERP.Models
{
    public class User
    {
        public int Id { get; set; }
        public int UserName { get; set; }
        public string Password { get; set; } = string.Empty;
        public string? Foto { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
