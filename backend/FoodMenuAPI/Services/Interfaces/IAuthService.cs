using FoodMenuAPI.DTOs.Auth;

namespace FoodMenuAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse?> LoginAsync(LoginRequest request);
    }
}