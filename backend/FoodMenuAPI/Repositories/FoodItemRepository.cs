using FoodMenuAPI.Data;
using FoodMenuAPI.Models;
using FoodMenuAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodMenuAPI.Repositories
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private readonly ApplicationDbContext _context;

        public FoodItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all food items
        public async Task<List<FoodItem>> GetAllAsync()
        {
            return await _context.FoodItems.ToListAsync();
        }

        // Get food item by ID
        public async Task<FoodItem?> GetByIdAsync(int id)
        {
            return await _context.FoodItems.FindAsync(id);
        }

        // Add a new food item
        public async Task<FoodItem> AddAsync(FoodItem foodItem)
        {
            _context.FoodItems.Add(foodItem);

            await _context.SaveChangesAsync();

            return foodItem;
        }

        // Update an existing food item
        public async Task UpdateAsync(FoodItem foodItem)
        {
            _context.FoodItems.Update(foodItem);

            await _context.SaveChangesAsync();
        }

        // Delete a food item
        public async Task DeleteAsync(FoodItem foodItem)
        {
            _context.FoodItems.Remove(foodItem);

            await _context.SaveChangesAsync();
        }
    }
}