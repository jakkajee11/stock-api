using System;
using Microsoft.EntityFrameworkCore;
using StockApi.Entities;

namespace StockApi.Services
{
    public interface IShoppingCartService
    {
        Task<IList<ShoppingCart>> GetShoppingCarts();
        Task<IList<ShoppingCart>> GetShoppingCart(Guid userId);
        Task<bool> AddToCart(Guid userId, Guid productId, int amount);
        Task<bool> Checkout(Guid userId);
    }

    public class ShoppingCartService : IShoppingCartService
    {
        private readonly StockApiContext _context;

        public ShoppingCartService(StockApiContext context)
        {
            _context = context;
        }

        public async Task<bool> AddToCart(Guid userId, Guid productId, int amount)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

            var cart = await _context.ShoppingCarts.FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId && !c.CheckedOut);

            if (user == null)
                throw new Exception("Invalid user");

            if (product == null)
                throw new Exception("Invalid product");

            if (cart == null)
            {
                cart = new ShoppingCart
                {
                    User = user,
                    Product = product,
                    Amount = amount
                };

                _context.ShoppingCarts.Add(cart);
            } else
            {                
                cart.Amount += 1;

                _context.Entry(cart).State = EntityState.Modified;
            }

            
            var res = await _context.SaveChangesAsync();

            return res > 0;
        }

        public async Task<bool> Checkout(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                throw new Exception("Invalid user");            

            var carts = await _context.ShoppingCarts.Where(c => c.UserId == userId && !c.CheckedOut).ToListAsync();

            if (carts == null || carts.Count == 0)
                throw new Exception("Cart is empty");

            foreach(var cart in carts)
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == cart.ProductId);
                var available = product.Available - cart.Amount;

                product.Available = available;

                cart.CheckedOut = true;

                _context.Entry(product).State = EntityState.Modified;
                _context.Entry(cart).State = EntityState.Modified;
            }

            var res = await _context.SaveChangesAsync();

            return res > 0;
        }

        public async Task<IList<ShoppingCart>> GetShoppingCart(Guid userId)
        {
            return await _context.ShoppingCarts
                .Where(c => c.UserId == userId && !c.CheckedOut)
                .Include(x => x.Product)
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<IList<ShoppingCart>> GetShoppingCarts()
        {
            return await _context.ShoppingCarts.ToListAsync();
        }
    }
}

