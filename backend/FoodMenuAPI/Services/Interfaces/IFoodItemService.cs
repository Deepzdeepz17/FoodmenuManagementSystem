using FoodMenuAPI.Models;

namespace FoodMenuAPI.Services.Interfaces
{
    public interface IFoodItemService
    {
        Task<List<FoodItem>> GetAllAsync();

        Task<FoodItem?> GetByIdAsync(int id);

        Task<FoodItem> AddAsync(FoodItem foodItem);

        Task UpdateAsync(int id, FoodItem foodItem);

        Task DeleteAsync(int id);
    }
}