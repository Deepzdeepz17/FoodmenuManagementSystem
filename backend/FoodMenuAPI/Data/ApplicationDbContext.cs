
using Microsoft.EntityFrameworkCore;
using FoodMenuAPI.Models;

namespace FoodMenuAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FoodItem> FoodItems { get; set; }
    }
}
