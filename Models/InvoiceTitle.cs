using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace SonmezERP.Models
{
    public class InvoiceTitle
    {
        [Key] 
        public int Id { get; set; }
        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        public Customer Customers { get; set; }
        public string Address { get; set; }
        public string Phone{ get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreateDate{ get; set; }
        public string Seris { get; set; }
        public float TotalWithoutTax { get; set; }
        public float TotalTax { get; set; }
        public float TotalWithoutDiscount { get; set; }
        public float TotalWithDiscount { get; set; }
        public float TotalCubicMeters { get; set; }


    }
}
