
using FoodMenuAPI.DTOs.Auth;
using FoodMenuAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodMenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _authService.LoginAsync(request);

            if (result == null)
                return Unauthorized("Invalid email or password.");

            return Ok(result);
        }
    }
}
