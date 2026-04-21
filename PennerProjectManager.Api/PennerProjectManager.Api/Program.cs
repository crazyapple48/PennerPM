using Microsoft.EntityFrameworkCore;
using PennerProjectManager.Api.Data;
using PennerProjectManager.Api.Endpoints;
using PennerProjectManager.Api.Repositories;
using PennerProjectManager.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddTransient<ICategoryRepository, LocalCategoryRepository>();
builder.Services.AddTransient<IDatabaseService, LocalDatabaseService>();

if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.Desktop;
        var path = Environment.GetFolderPath(folder);
        var dbPath = Path.Join(path, "pennerPM.db");
        options.UseSqlite($"Data Source={dbPath};");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    DbSeeder.Seed(db);
    ;
}

app.UseHttpsRedirection();

// Map endpoints here
app.MapCategoryEndpoints();

app.Run();
