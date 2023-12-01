using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OpenDHS.Shared.Extensions;
using OpenDHS.Shared.QRCode;

namespace OpenDHS.Shared
{
    public static class WebStartupExtensions
    {
        public static IServiceCollection AddOpenDHSServices<TDBContext>(this IServiceCollection services) where TDBContext : DbContextClass
        {
            OpensalusEnv.SetWebRoot();
            services.AddScoped<QRCodeService>();
            services.AddScoped<IMediaService, MediaService<TDBContext>>();

            return services;
        }
            public static IApplicationBuilder UseOpenDHSServices<TDBContext>(this IApplicationBuilder app) where TDBContext : DbContextClass
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<TDBContext>();
                dbContext.Database.EnsureCreated();
            }         
            return app;
        }
    }
}
