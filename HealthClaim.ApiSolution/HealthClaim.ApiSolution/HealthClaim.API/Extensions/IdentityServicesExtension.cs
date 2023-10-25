using HealthClaim.BAL.Service;
using HealthClaim.DAL;
using HealthClaim.DAL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace HealthClaim.API.Extensions
{
    public static class IdentityServicesExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentityCore<ApplicationUser>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
             .AddEntityFrameworkStores<HealthClaimDbContext>()
            .AddSignInManager<SignInManager<ApplicationUser>>();

            using var hmac = new HMACSHA256();
            byte[] keyBytes = hmac.Key;

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization();

            /* services.AddAuthorization(opt =>
             {
                 opt.AddPolicy("IsActivityHost", policy =>
                 {
                     policy.Requirements.Add(new IsHostRequirment());
                 });
             });*/

            //services.AddTransient(IAuthorizationHandler, IsHostRequirmentHandler);

            services.AddScoped<TokenService>();

            return services;
        }
    }
}
