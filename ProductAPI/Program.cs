using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers(); // 🔴 REQUIRED
builder.Services.AddOpenApi();

// Register EF Core DbContext with SQLite
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlite("Data Source=products.db"));

var app = builder.Build();

// Create DB and seed data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
    db.Database.EnsureCreated();

    if (!db.Products.Any())
    {
        db.Products.AddRange(
            new Product { Name = "Laptop", Price = 999.99M, Inventory = 5 },
            new Product { Name = "Mouse", Price = 25.50M, Inventory = 20 }
        );
        db.SaveChanges();
    }
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseStaticFiles();     // 🔴 REQUIRED for index.html

app.MapControllers();     // 🔴 REQUIRED for /productAPI

app.Run();

