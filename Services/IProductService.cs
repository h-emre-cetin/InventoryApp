using InventoryApp.Models;

namespace InventoryApp.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> AddProductAsync(Product product);

        Task<Product> UpdateProductAsync(int id, Product updatedProduct);

        Task<Product> DeleteProductAsync(int id);
    }
}
