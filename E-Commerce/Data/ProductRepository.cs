
using E_Commerce.Entities;
using E_Commerce.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storedb;
        public ProductRepository(StoreContext storedb)
        {
            _storedb = storedb;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _storedb.productBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _storedb.products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id); 
        }
        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _storedb.products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _storedb.productTypes.ToListAsync();
        }
    }
}
