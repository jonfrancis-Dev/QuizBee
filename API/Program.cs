using Application.Quiz.Queries;
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

// Add CORS
builder.Services.AddCors();

// Add Mediatr for Getting Question List
builder.Services.AddMediatR(x =>
    x.RegisterServicesFromAssemblyContaining<GetQuestionsQuery.Handler>());

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(options => options
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithOrigins("http://localhost:3000", "https://localhost:3000")); // Client Port

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
