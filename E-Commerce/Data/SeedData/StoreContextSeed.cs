using E_Commerce.Entities;
using System.Text.Json;

namespace E_Commerce.Data.SeedData
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.productTypes.Any())
            {
                var productsTypeData = File.ReadAllText(@".\Data\SeedData\types.json");
                var products = JsonSerializer.Deserialize<List<ProductType>>(productsTypeData);

                await context.productTypes.AddRangeAsync(products!);
                await context.SaveChangesAsync();
            }
            if (!context.productBrands.Any())
            {
                var productsBrandData = File.ReadAllText(@".\Data\SeedData\brands.json");
                var products = JsonSerializer.Deserialize<List<ProductBrand>>(productsBrandData);

                await context.productBrands.AddRangeAsync(products!);
                await context.SaveChangesAsync();
            }
            if (!context.products.Any())
            {
                    var productsData = File.ReadAllText(@".\Data\SeedData\products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    await context.products.AddRangeAsync(products!);
                    await context.SaveChangesAsync();
            }
        }
    }
}