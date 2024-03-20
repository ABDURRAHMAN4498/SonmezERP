﻿using Microsoft.EntityFrameworkCore;
using SonmezERP.Models;

namespace SonmezERP.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SonmezERPContext(
             serviceProvider.GetRequiredService<
                 DbContextOptions<SonmezERPContext>>()))
            {
                if (context.Products.Any())
                {
                    return;
                }
                context.Products.AddRange(
                    new Product
                    {
                        Id = 1,
                        ProductCode = "0202",
                        Barcode = "4546464850202",
                        ProductNameTr = "Loft koltuk",
                        ProductNameEn = "Loft Armchair",
                        PriceTl = 35.5f,
                        PriceUSD = 35.5f,

                    }
                );
                context.ProductDetails.AddRange(
                    new ProductDetails
                    {
                        
                    });
                context.SaveChanges();
            }
        }
    }
}
