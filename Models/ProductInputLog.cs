using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace SonmezERP.Models
{
    public class ProductInputLog
    {
        public List<ProductInputLogList> Inputs { get; set; } = new List<ProductInputLogList>();
    }
}
