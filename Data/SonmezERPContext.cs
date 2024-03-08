using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SonmezERP.Models;

namespace SonmezERP.Data
{
    public class SonmezERPContext : DbContext
    {
        public SonmezERPContext (DbContextOptions<SonmezERPContext> options)
            : base(options)
        {
        }

        public DbSet<SonmezERP.Models.Products> Products { get; set; } = default!;
    }
}
