using Microsoft.AspNetCore.Identity;

namespace FoodMenuAPI.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}