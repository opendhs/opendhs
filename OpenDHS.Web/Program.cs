using Microsoft.AspNetCore.Identity;
using OpenDHS.Shared;
using OpenDHS.Shared.Data;
using OpenDHS.Web.Data;
using OpenDHS.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add-Registering services to the container.
builder.AddCorsMiddleware();



builder.AddAuthMiddleware();
builder.Services.AddControllers();
builder.Services.AddRazorPages();   
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.AddSwaggerMiddleware();
builder.Services.AddOpenDHSServices<OpenDHSDataContext>();


var app = builder.Build();
// Use-Configure the HTTP request pipeline.
app.UseCorsMiddleware();
app.UseStaticFiles();
app.UseAuthMiddleware();
app.UseSwaggerMiddleware();
app.UseOpenDHSServices<OpenDHSDataContext>();
app.MapControllers();
app.MapRazorPages();

app.Run();
