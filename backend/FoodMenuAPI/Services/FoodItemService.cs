using FoodMenuAPI.Models;
using FoodMenuAPI.Repositories.Interfaces;
using FoodMenuAPI.Services.Interfaces;

namespace FoodMenuAPI.Services
{
    public class FoodItemService : IFoodItemService
    {
        private readonly IFoodItemRepository _repository;

        public FoodItemService(IFoodItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FoodItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<FoodItem?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<FoodItem> AddAsync(FoodItem foodItem)
        {
            return await _repository.AddAsync(foodItem);
        }

        public async Task UpdateAsync(int id, FoodItem foodItem)
        {
            var existingFood = await _repository.GetByIdAsync(id);

            if (existingFood == null)
            {
                throw new KeyNotFoundException("Food item not found.");
            }

            existingFood.Name = foodItem.Name;
            existingFood.Category = foodItem.Category;
            existingFood.Description = foodItem.Description;
            existingFood.Price = foodItem.Price;
            existingFood.IsAvailable = foodItem.IsAvailable;

            await _repository.UpdateAsync(existingFood);
        }

        public async Task DeleteAsync(int id)
        {
            var foodItem = await _repository.GetByIdAsync(id);

            if (foodItem == null)
            {
                throw new KeyNotFoundException("Food item not found.");
            }

            await _repository.DeleteAsync(foodItem);
        }
    }
}