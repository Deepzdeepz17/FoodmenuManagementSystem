using FoodMenuAPI.Models;
using FoodMenuAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodMenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemsController : ControllerBase
    {
        private readonly IFoodItemService _foodItemService;

        public FoodItemsController(IFoodItemService foodItemService)
        {
            _foodItemService = foodItemService;
        }

        // GET: api/FoodItems
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var foodItems = await _foodItemService.GetAllAsync();
            return Ok(foodItems);
        }

        // GET: api/FoodItems/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var foodItem = await _foodItemService.GetByIdAsync(id);

            if (foodItem == null)
                return NotFound("Food item not found.");

            return Ok(foodItem);
        }

        // POST: api/FoodItems
        [HttpPost]
        public async Task<IActionResult> Add(FoodItem foodItem)
        {
            var createdFood = await _foodItemService.AddAsync(foodItem);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdFood.Id },
                createdFood);
        }

        // PUT: api/FoodItems/1
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FoodItem foodItem)
        {
            try
            {
                await _foodItemService.UpdateAsync(id, foodItem);
                return Ok("Food item updated successfully.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Food item not found.");
            }
        }

        // DELETE: api/FoodItems/1
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _foodItemService.DeleteAsync(id);
                return Ok("Food item deleted successfully.");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Food item not found.");
            }
        }
    }
}