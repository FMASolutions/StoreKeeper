using Microsoft.EntityFrameworkCore;
using StoreKeeper.Core.Models;
using StoreKeeper.Data.Configurations;

namespace StoreKeeper.Data
{
    public class StoreKeeperDbContext : DbContext
    {
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<SubGroup> SubGroups {get; set;}
        public StoreKeeperDbContext(DbContextOptions<StoreKeeperDbContext> options): base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {   
            builder.ApplyConfiguration(new ProductGroupConfiguration());                
            builder.ApplyConfiguration(new SubGroupConfiguration());
        }
    }
}
