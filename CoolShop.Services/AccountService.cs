using CoolShop.Common.Repositories;
using CoolShop.Common.Services;
using CoolShop.Models;

namespace CoolShop.Services
{
    internal class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AccountService(IUserRepository userRepository, ITokenService tokenService)
        {
            this._userRepository = userRepository;
            this._tokenService = tokenService;
        }

        public async Task<(User? user, string token)> Login(string login, string password)
        {
            var user = await _userRepository.GetUserByLogin(login);
            if (user == null) return (null, null!);
            if (user.Password != password)
                throw new UnauthorizedAccessException();

            var token = _tokenService.GetToken(user);
            return (user, token);
        }

        public async Task<(User user, string token)> Register(User user)
        {
            user = await _userRepository.CreateUser(user);
            var token = _tokenService.GetToken(user);

            return (user, token);
        }
    }
}
