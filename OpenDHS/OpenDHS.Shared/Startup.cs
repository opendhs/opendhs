using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Opensalus.Shared.Extensions;
using Opensalus.Shared.QRCode;
using System;

namespace Opensalus.Shared
{
    public static class WebStartupExtensions
    {
        public static IServiceCollection AddOpensalusServices(this IServiceCollection services)
        {
            OpensalusEnv.SetWebRoot();
            services.AddDbContext<DbContextClass>();
            services.AddScoped<QRCodeService>();
            services.AddScoped<IMediaService, MediaService>();

            return services;
        }
            public static IApplicationBuilder UseOpensalusServices(this IApplicationBuilder app)
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
