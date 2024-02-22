using CoolShop.Common.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CoolShop.Repositories.Extensions
{
    public static class Register
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
