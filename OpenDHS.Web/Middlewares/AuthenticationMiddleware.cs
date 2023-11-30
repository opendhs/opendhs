using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OpenDHS.Shared.Data;
using OpenDHS.Web.Data;
using System.Text;

namespace OpenDHS.Web.Middlewares
{
    public static class AuthenticationMiddleware
    {
        public static void AddAuthMiddleware(this WebApplicationBuilder builder)
        {
            //TODO: Evaluate JwtBearerToken Conflicts
            builder.Services.AddIdentity<UserEntity, RoleEntity>()
                .AddEntityFrameworkStores<OpenDHSDataContext>()
                .AddDefaultTokenProviders();

            // Registering Authentication Middleware
            builder.Services.AddAuthentication((opt) =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer((opt) =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });

            // Registering Authorization Middleware
            // 
        }

        public static void UseAuthMiddleware(this WebApplication app)
        {
            // Using Authentication Middleware (First)
            app.UseAuthentication();


            // Using uthorization Middleware (Second)
            app.UseAuthorization();
        }
    }
}
