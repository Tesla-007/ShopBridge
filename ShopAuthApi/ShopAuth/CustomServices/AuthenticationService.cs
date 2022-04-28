using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ShopAuth.IdenityService;
using System;
using System.Text;

namespace ShopAuth.CustomServices
{
    public static class AuthenticationService
    {
        public static void AddDefaultJwtOptions(this JwtBearerOptions options, IConfiguration Configuration)
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = Configuration["Tokens:Issuer"],
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Tokens:Key"]))
            };
        }

        public static void AddJwtAuthentication(this IServiceCollection services, Action<JwtBearerOptions> options)
        {
            services.AddScoped<IShopAuthIdenity, ShopAuthIdenityService>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options);
        }
    }
}
