using CoolShop.Models;

namespace CoolShop.Common.Services
{
    public interface IAccountService
    {
        Task<(User? user, string token)> Login(string login, string password);

        Task<(User user, string token)> Register(User user, string password);
    }
}
