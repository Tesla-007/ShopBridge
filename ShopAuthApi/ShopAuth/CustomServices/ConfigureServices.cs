using Microsoft.Extensions.DependencyInjection;
using ShopAuth.Domain;
using ShopAuth.Domain.Interface;
using ShopAuth.Domain.SeedData;

namespace ShopAuth.CustomServices
{
    public static class ConfigureServices
    {
        public static void ConfigureCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountDomain, AccountDomain>();
            services.AddHttpClient();
        }
    }
}
