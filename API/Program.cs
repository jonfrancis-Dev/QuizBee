using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Add SQLite Connection (This is temporary for prototype)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("TemporaryConnection"));
});


var app = builder.Build();

app.MapControllers();


using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

// Seed Data (NOT NEEDED IN PRODUCTION)
try
{
    var context = services.GetRequiredService<ApplicationDbContext>();
    await context.Database.MigrateAsync();
    await DbInitializer.SeedAsync(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration");
}


app.Run();
