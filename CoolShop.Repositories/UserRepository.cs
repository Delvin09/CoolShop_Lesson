using CoolShop.Common.Repositories;
using CoolShop.Entity.SqlServer;
using CoolShop.Models;
using Microsoft.EntityFrameworkCore;

namespace CoolShop.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly CoolShopContext _context;

        public UserRepository(CoolShopContext context)
        {
            this._context = context;
        }

        public Task<User?> GetUserByLogin(string login)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Login == login);
        }

        public async Task<User> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public ValueTask<User?> GetUser(int id)
        {
            return _context.Users.FindAsync(id);
        }

        public Task<List<User>> GetUsers(string? firstName, string? lastName)
        {
            return _context.Users
                .Where(u => (firstName == null || u.FirstName == firstName) && (lastName == null || u.LastName == lastName))
                .ToListAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await GetUser(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateUser(User user)
        {
            _context.Attach(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
