using InventoryApp.Data;
using InventoryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving products.", ex);
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id) ?? throw new InvalidOperationException($"Product with ID {id} not found.");
                
                return product;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred while retrieving product with ID {id}.", ex);
            }
        }

        public async Task AddAsync(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while adding a product.", ex);
            }
        }

        public async Task UpdateAsync(Product product)
        {
            try
            {
                _context.Products.Update(product);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred while updating product with ID {product.Id}.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var product = await GetByIdAsync(id);

                if (product != null)
                {
                    _context.Products.Remove(product);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred while deleting product with ID {id}.", ex);
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while saving changes to the database.", ex);
            }
        }
    }
}
