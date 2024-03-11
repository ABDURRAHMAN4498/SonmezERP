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
        public SonmezERPContext()
        {

        }
        public SonmezERPContext (DbContextOptions<SonmezERPContext> options)
            : base(options)
        {
        }

        public DbSet<SonmezERP.Models.Products> Products { get; set; } = default!;
        public DbSet<SonmezERP.Models.Birimler> Birimler { get; set; } = default!;
        public DbSet<SonmezERP.Models.Brands> Brands { get; set; } = default!;
        public DbSet<SonmezERP.Models.Categoreis> Categoreis { get; set; } = default!;
        public DbSet<SonmezERP.Models.Colors> Colors { get; set; } = default!;
        public DbSet<SonmezERP.Models.Hammadde> Hammadde{ get; set; } = default!;
        public DbSet<SonmezERP.Models.Kdvs> Kdv{ get; set; } = default!;
        public DbSet<SonmezERP.Models.ProductDetails> ProductDetails{ get; set; } = default!;
        public DbSet<User> Users { get; set; }



    }
}
