using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SonmezERP.Models
{
    public class Addresses
    {
        [Key]
        public int Id { get; set; }
        public string? Address { get; set; }
        public Customer? Customers { get; set; }
    }
}
