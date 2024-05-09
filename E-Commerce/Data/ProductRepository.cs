
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
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _storedb.products.FindAsync(id); 
        }
        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _storedb.products.ToListAsync();
        }
    }
}
