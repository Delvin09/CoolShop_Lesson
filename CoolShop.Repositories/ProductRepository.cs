using CoolShop.Common.Repositories;
using CoolShop.Entity.SqlServer;
using CoolShop.Models;
using Microsoft.EntityFrameworkCore;

namespace CoolShop.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly CoolShopContext _context;

        public ProductRepository(CoolShopContext context)
        {
            this._context = context;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
                _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _context.Products.Attach(product);
            _context.Products.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            var result = await _context.Products.ToListAsync();
            return result;
        }
    }
}
