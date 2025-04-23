using InventoryApp.Data;
using InventoryApp.Models;
using InventoryApp.Repositories;
using InventoryApp.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace InventoryApp.Tests
{
    public class ProductServiceTests
    {
        private async Task<AppDbContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new AppDbContext(options);
            databaseContext.Database.EnsureCreated();

            if (await databaseContext.Products.CountAsync() <= 0)
            {
                databaseContext.Products.Add(new Product { Name = "Test Product", Description = "Test", Price = 10, Quantity = 5 });
                await databaseContext.SaveChangesAsync();
            }

            return databaseContext;
        }

        [Fact]
        public async Task GetProductsAsync_ReturnsProducts()
        {
            var context = await GetDatabaseContext();
            var repo = new ProductRepository(context);
            var service = new ProductService(repo);

            var products = await service.GetProductsAsync();

            Assert.NotEmpty(products);
        }

        [Fact]
        public async Task AddProductAsync_WithInvalidName_ThrowsException()
        {
            var context = await GetDatabaseContext();
            var repo = new ProductRepository(context);
            var service = new ProductService(repo);

            var invalidProduct = new Product { Name = "", Description = "Invalid", Price = 5, Quantity = 2 };

            await Assert.ThrowsAsync<ArgumentException>(() => service.AddProductAsync(invalidProduct));
        }
    }
}
