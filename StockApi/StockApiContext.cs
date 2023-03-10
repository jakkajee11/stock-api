using System;
using Microsoft.EntityFrameworkCore;
using StockApi.Entities;

namespace StockApi
{
    public class StockApiContext : DbContext
    {
        public StockApiContext(DbContextOptions<StockApiContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    }
}

