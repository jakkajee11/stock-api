using System;
using Microsoft.EntityFrameworkCore;
using StockApi.Entities;

namespace StockApi.Services
{
    public interface ICategoryService
    {
        Task<IList<Category>> GetCategories();
        Task<bool> CreateCategory(Category category);
    }

    public class CategoryService : ICategoryService
    {
        private readonly StockApiContext _context;

        public CategoryService(StockApiContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCategory(Category category)
        {
             _context.Categories.Add(category);

            var res = await _context.SaveChangesAsync();

            return res > 0;
        }

        public async Task<IList<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}

