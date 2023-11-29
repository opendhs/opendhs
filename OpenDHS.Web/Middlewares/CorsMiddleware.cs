namespace OpenDHS.Web.Middlewares
{
    public static class CorsMiddleware
    {
        const string OpenDHSApiCors = "OPENDHS-API-CORS";
        public static void AddCorsMiddleware(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: OpenDHSApiCors,
                                  policy =>
                                  {
                                      policy.WithOrigins("*");
                                  });
            });
        }

        public static void UseCorsMiddleware(this WebApplication app) {
            app.UseCors(OpenDHSApiCors);
        }

    }
}
