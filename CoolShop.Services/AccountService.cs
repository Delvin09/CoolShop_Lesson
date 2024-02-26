using CoolShop.Common.Repositories;
using CoolShop.Common.Services;
using CoolShop.Models;

namespace CoolShop.Services
{
    internal class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IHashService _hashService;

        public AccountService(IUserRepository userRepository, ITokenService tokenService, IHashService hashService)
        {
            this._userRepository = userRepository;
            this._tokenService = tokenService;
            this._hashService = hashService;
        }

        public async Task<(User? user, string token)> Login(string login, string password)
        {
            var user = await _userRepository.GetUserByLogin(login);
            if (user == null) return (null, null!);

            var hash = _hashService.GetHash(password, user.PasswordSalt);

            if (!user.PasswordHash.SequenceEqual(hash.hash))
                throw new UnauthorizedAccessException();

            var token = _tokenService.GetToken(user);
            return (user, token);
        }

        public async Task<(User user, string token)> Register(User user, string password)
        {
            var hash = _hashService.GetHash(password);
            user.PasswordHash = hash.hash;
            user.PasswordSalt = hash.salt;

            user = await _userRepository.CreateUser(user);
            var token = _tokenService.GetToken(user);

            return (user, token);
        }
    }
}
