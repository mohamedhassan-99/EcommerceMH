using Ecommerce.Application.ServicesConfiguration;
using Ecommerce.Infrastructure.AppContext;
using Ecommerce.Infrastructure.ServiceConfiguration;
using Ecommerce.Web.Middlewares;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Host.UseSerilog((hostContext, loggerbuider) =>
{
    loggerbuider
    .Enrich.FromLogContext()
    .WriteTo.File(path: "Logs/",
                  restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error,
                  rollingInterval: RollingInterval.Day);
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.IgnoreNullValues = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await MigrateDataBase(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// that's my custom middleware
app.UseMiddleware<MyExceptionHandlingMiddleware>();

app.UseCors(act => act.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static async Task MigrateDataBase(WebApplication app)
{
    using (var scopedServiceInstance = app.Services.CreateScope())
    {
        // to apply the last migration on the database if not exist
        await scopedServiceInstance.ServiceProvider.GetRequiredService<AppDbContext>().Database.MigrateAsync();
    }
}


