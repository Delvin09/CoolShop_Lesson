using CoolShop.Models;

namespace CoolShop.Common.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetProductById(int id);

        Task<List<Product>> GetProducts();

        Task<Product> UpdateProduct(Product product);

        Task<Product> CreateProduct(Product product);

        Task DeleteProduct(int id);
    }
}
