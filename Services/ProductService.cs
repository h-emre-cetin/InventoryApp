using InventoryApp.Models;
using InventoryApp.Repositories;

namespace InventoryApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while fetching products.", ex);
            }
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(product.Name))
                {
                    throw new ArgumentException("Product name must be provided.");
                }

                await _repository.AddAsync(product);
                await _repository.SaveChangesAsync();
                return product;
            }
            catch (ArgumentException)
            {
                throw; // Re-throw argument exceptions as they are validation errors.  
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while adding a product.", ex);
            }
        }

        public async Task<Product> UpdateProductAsync(int id, Product updatedProduct)
        {
            try
            {
                var product = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Product not found");

                product.Name = updatedProduct.Name;
                product.Description = updatedProduct.Description;
                product.Price = updatedProduct.Price;
                product.Quantity = updatedProduct.Quantity;

                await _repository.UpdateAsync(product);
                await _repository.SaveChangesAsync();
                return product;
            }
            catch (KeyNotFoundException)
            {
                throw; // Re-throw key not found exceptions as they are expected errors.  
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred while updating product with ID {id}.", ex);
            }
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            try
            {
                var product = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Product not found");

                await _repository.DeleteAsync(id); // Pass the product ID instead of the product object
                await _repository.SaveChangesAsync();
                return product;
            }
            catch (KeyNotFoundException)
            {
                throw; // Re-throw key not found exceptions as they are expected errors.  
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred while deleting product with ID {id}.", ex);
            }
        }
    }
}
