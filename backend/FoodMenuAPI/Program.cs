using FoodMenuAPI.Data;
using FoodMenuAPI.Repositories;
using FoodMenuAPI.Repositories.Interfaces;
using FoodMenuAPI.Services;
using FoodMenuAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register Controllers
builder.Services.AddControllers();

builder.Services.AddOpenApi();

// Database Connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repository
builder.Services.AddScoped<IFoodItemRepository, FoodItemRepository>();

// Register Service
builder.Services.AddScoped<IFoodItemService, FoodItemService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();