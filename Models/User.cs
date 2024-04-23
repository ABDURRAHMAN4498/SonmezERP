using Microsoft.AspNetCore.Identity;

namespace SonmezERP.Models
{
    class User : IdentityUser
    {
        public int Id { get; set; }

    }
}