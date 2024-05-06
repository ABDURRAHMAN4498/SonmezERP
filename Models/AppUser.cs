
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SonmezERP.Models
{
    public class AppUser:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }

    }
}
