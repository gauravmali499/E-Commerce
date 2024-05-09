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

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Product1",
                    Description = "Amazing Product",
                    PictureUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.aptronixindia.com%2F16-inch-macbook-pro-apple-m1-chip&psig=AOvVaw08qcogK7sbtKme9s1AQpCf&ust=1715340761494000&source=images&cd=vfe&opi=89978449&ved=0CBAQjRxqFwoTCODsv7u8gIYDFQAAAAAdAAAAABAE",
                    Price = 210000,
                    ProductBrand = new ProductBrand() { Id = 101, Name = "Apple" },
                    ProductBrandId = 101,
                    ProductType = new ProductType() { Id = 1001, Name = "Laptop" },
                    ProductTypeId = 1001
                });
        }*/
    }
}
