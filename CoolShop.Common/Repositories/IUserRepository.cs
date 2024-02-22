using CoolShop.Models;

namespace CoolShop.Common.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByLogin(string login);
        Task<User> CreateUser(User user);

        ValueTask<User?> GetUser(int id);

        Task<List<User>> GetUsers(string? firstName, string? lastName);

        Task UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
