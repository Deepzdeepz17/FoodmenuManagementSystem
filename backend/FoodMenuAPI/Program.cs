
using FoodMenuAPI.Data;
using FoodMenuAPI.Repositories;
using FoodMenuAPI.Repositories.Interfaces;
using FoodMenuAPI.Services;
using FoodMenuAPI.Services.Interfaces;
using FoodMenuAPI.Auth;
using FoodMenuAPI.DTOs.Auth;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Register Controllers
builder.Services.AddControllers();

builder.Services.AddOpenApi();

// Database Connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity Configuration
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme =
        JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],

        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                builder.Configuration["Jwt:Key"]!))
    };
});

// Register Repository
builder.Services.AddScoped<IFoodItemRepository, FoodItemRepository>();

// Register Food Service
builder.Services.AddScoped<IFoodItemService, FoodItemService>();

// Register Authentication Service
builder.Services.AddScoped<IAuthService, AuthService>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Build Application
var app = builder.Build();

// Create Admin account and role
await IdentitySeeder.SeedAsync(app.Services);

// OpenAPI Configuration
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Middleware Configuration
app.UseHttpsRedirection();

app.UseCors("AllowAngular");

app.UseAuthentication();

app.UseAuthorization();

// Map Controllers
app.MapControllers();

// Run Application
app.Run();
