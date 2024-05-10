using E_Commerce.Data.SeedData;
using E_Commerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Data
{
    public class StoreContext:DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<ProductBrand> productBrands { get; set; }
        public DbSet<ProductType> productTypes { get; set; }
        public StoreContext(DbContextOptions<StoreContext> options): base(options){ }
    }
}
