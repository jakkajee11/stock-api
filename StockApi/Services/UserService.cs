using System;
using Microsoft.EntityFrameworkCore;
using StockApi.Entities;

namespace StockApi.Services
{
    public interface IUserService
    {
        Task<bool> CreateUser(User user);
        Task<IList<User>> GetUsers();
        Task<User> GetUser(Guid userId);
    }
    public class UserService : IUserService
    {
        private readonly StockApiContext _context;

        public UserService(StockApiContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateUser(User user)
        {
            _context.Users.Add(user);

            var res = await _context.SaveChangesAsync();

            return res > 0;
        }

        public async Task<User> GetUser(Guid userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<IList<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}

