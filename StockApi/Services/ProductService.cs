using System;
using Microsoft.EntityFrameworkCore;
using StockApi.Entities;

namespace StockApi.Services
{
    public interface IProductService
    {
        Task<IList<Product>> GetProducts();
        Task<Product> GetProduct(Guid productId);
        Task<bool> IsAvailable(Guid productId, int amount);
        Task<bool> CreateProduct(Product product);
    }
    public class ProductService : IProductService
    {
        private readonly StockApiContext _context;

        public ProductService(StockApiContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateProduct(Product product)
        {
            _context.Products.Add(product);

            var res = await _context.SaveChangesAsync();

            return res > 0;
        }

        public async Task<Product> GetProduct(Guid productId)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<IList<Product>> GetProducts()
        {
            return await _context.Products
                            .Include(x => x.Category)
                            .ToListAsync();
        }

        public async Task<bool> IsAvailable(Guid productId, int amount)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

            return product != null && product.Available >= amount;
        }
    }
}

