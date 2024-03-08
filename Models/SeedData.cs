using Microsoft.EntityFrameworkCore;
using SonmezERP.Data;

namespace SonmezERP.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new SonmezERPContext(serviceProvider.GetRequiredKeyedService<
                DbContextOptions<SonmezERPContext>>)))
            {
                if ()
                {
                    
                }
            }
        }
    }
}
