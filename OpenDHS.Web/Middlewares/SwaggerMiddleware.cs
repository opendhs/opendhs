namespace OpenDHS.Web.Middlewares
{
    public static class SwaggerMiddleware
    {
        public static void AddSwaggerMiddleware(this WebApplicationBuilder builder) {
            builder.Services.AddSwaggerGen();
        }
        public static void UseSwaggerMiddleware(this WebApplication app)
        {
            if (app.Environment.IsProduction())
                return;
            
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
