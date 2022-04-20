using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Services.Interfaces;
using Tekever.ShowTracker.Services.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Tekever.ShowTracker.Services
{
	public static class Dependency
	{
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddSingleton<IGoogleAuthenticationService, GoogleAuthenticationService>();
            services.AddScoped<IShowService, ShowService>();
            return services;
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddMvc();
            services.AddSession();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    const string securityKey = "anything_s3crEt!_go3s_here";
                    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = false,
                        ValidIssuer = "ShowTracker",
                        IssuerSigningKey = symmetricSecurityKey
                    };
                });
        }
    }
}
