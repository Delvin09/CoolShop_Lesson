namespace CoolShop.API.Dtos
{
    public record UserDto(string Login,
        string Role,
        string? FirstName,
        string? LastName,
        string Email,
        string? PhoneNumber);
}
