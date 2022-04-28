using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ShopAuth.Domain.Entities;
using ShopAuth.Domain.ShopBridgeDb;
using System;

namespace ShopAuth.CustomServices
{
    public static class DatabaseService
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddDbContextPool<ShopBridgeDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("ShopAuthDb"))
                        .LogTo(Console.WriteLine, LogLevel.Error)
                        .EnableSensitiveDataLogging();
            });
            services.AddDefaultIdentity<IdentityAdmin>()
                    .AddEntityFrameworkStores<ShopBridgeDbContext>();
        }

    }
}
