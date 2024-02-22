using System.ComponentModel.DataAnnotations;

namespace CoolShop.API.Dtos
{
    public record AccountDto([Required][StringLength(maximumLength: 100, MinimumLength = 4)] string Login,
        [Required][StringLength(maximumLength: 255, MinimumLength = 6)]
        string Password,
        [Required][StringLength(maximumLength: 50, MinimumLength = 1)]
        string Role,
        string? FirstName,
        string? LastName,
        [Required][EmailAddress] string Email,
        [Phone]string? PhoneNumber);
}
