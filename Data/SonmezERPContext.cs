using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SonmezERP.Models;

namespace SonmezERP.Data
{
    public class SonmezERPContext : IdentityDbContext<AppUser>
    {
      
        public SonmezERPContext (DbContextOptions<SonmezERPContext> options)
            : base(options)
        {
            
        }


        public DbSet<SonmezERP.Models.Product> Products { get; set; }
        public DbSet<SonmezERP.Models.ProductDetails> ProductDetails { get; set; }
        public DbSet<SonmezERP.Models.UnitsOfMeasurement> UnitsOfMeasurements { get; set; }
        public DbSet<SonmezERP.Models.Brand> Brands { get; set; }
        public DbSet<SonmezERP.Models.Category> Categoreis { get; set; }
        public DbSet<SonmezERP.Models.Color> Colors { get; set; }
        public DbSet<SonmezERP.Models.Kdv> Kdv { get; set; }
        public DbSet<SonmezERP.Models.ProductInputLogList> ProductInputLogList { get; set; }
        public DbSet<SonmezERP.Models.DashboardSettings> DashboardSettingsItems { get; set; }
        //public DbSet<SonmezERP.Models.RawMaterials> Hammadde { get; set; }
        //public DbSet<SonmezERP.Models.User> Users { get; set; }
        //public DbSet<SonmezERP.Models.RawMaterialsActions> HammaddeActions { get; set; }
        //public DbSet<SonmezERP.Models.Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
