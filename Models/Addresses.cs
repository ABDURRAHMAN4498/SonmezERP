using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SonmezERP.Models
{
    public class Addresses
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        
        [ForeignKey("Customers")]
        public int CustomerId{ get; set; }
        public Customer Customers { get; set; }
    }
}
