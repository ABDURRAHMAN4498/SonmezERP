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

        public DbSet<SonmezERP.Models.Products> Products { get; set; }
        public DbSet<SonmezERP.Models.Birimler> Birimler { get; set; }
        public DbSet<SonmezERP.Models.Brands> Brands { get; set; }
        public DbSet<SonmezERP.Models.Categoreis> Categoreis { get; set; }
        public DbSet<SonmezERP.Models.Colors> Colors { get; set; }
        public DbSet<SonmezERP.Models.Hammadde> Hammadde{ get; set; }
        public DbSet<SonmezERP.Models.Kdvs> Kdv{ get; set; }
        public DbSet<SonmezERP.Models.ProductDetails> ProductDetails{ get; set; }
        public DbSet<SonmezERP.Models.User> Users { get; set; }
        public DbSet<SonmezERP.Models.HammaddeActions> HammaddeActions { get; set; }
        public DbSet<SonmezERP.Models.Customer> Customers { get; set; }
    }
}
