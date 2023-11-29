using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using OpenDHS.Shared.Extensions;
using OpenDHS.Shared.QRCode;

namespace OpenDHS.Shared
{
    public static class WebStartupExtensions
    {
        public static IServiceCollection AddOpenDHSServices(this IServiceCollection services)
        {
            OpensalusEnv.SetWebRoot();
            services.AddDbContext<DbContextClass>();
            services.AddScoped<QRCodeService>();
            services.AddScoped<IMediaService, MediaService>();

            return services;
        }
            public static IApplicationBuilder UseOpenDHSServices(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<DbContextClass>();
                dbContext.Database.EnsureCreated();
            }         
            return app;
        }
    }
}
