using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SonmezERP.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        [ForeignKey("Address")]
        public int CustomerAddressId  { get; set; }
        public Addresses Address { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Fax { get; set; }
        public string? OfficePhone { get; set; }
        public string? OfficeAddress { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerCity { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreaterUser { get; set; }
        public bool Active { get; set; }
        public int CreaterUserId { get; set; }
        public User User { get; set; }




    }
}
