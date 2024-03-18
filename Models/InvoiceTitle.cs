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
        //kdv hariç toplam
        public float TotalWithoutTax { get; set; }
        //kdv toplamı
        public float TotalTax { get; set; }
        //indirimsiz toplam
        public float TotalWithoutDiscount { get; set; }
        //indirimli toplam
        public float TotalWithDiscount { get; set; }
        //Metreküp toplamı
        public float TotalCubicMeters { get; set; }


    }
}
