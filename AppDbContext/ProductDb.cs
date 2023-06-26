using Microsoft.EntityFrameworkCore;
using Session6_BoilerPlate.Models;
using System.Collections.Generic;

namespace Session6_BoilerPlate.AppDbContext
{
    public class ProductDb : DbContext
    {
        public ProductDb(DbContextOptions<ProductDb> Context) : base(Context)
        {
        }

        public DbSet<Product> HealthProducts { get; set; }

    }

}
