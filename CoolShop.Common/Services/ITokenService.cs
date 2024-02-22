using CoolShop.Models;

namespace CoolShop.Common.Services
{
    public interface ITokenService
    {
        string GetToken(User user);
    }
}
