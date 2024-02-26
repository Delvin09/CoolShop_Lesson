using CoolShop.Common.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CoolShop.Services.Extensions
{
    public static class Register
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IHashService, HashService>();
            return services;
        }
    }
}
