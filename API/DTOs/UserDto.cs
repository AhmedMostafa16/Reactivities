#nullable disable

namespace API.DTOs;

public class UserDto
{
    public string DisplayName { get; set; }
    public string Token { get; set; }
    public string Username { get; set; }

#nullable enable
    public string? Image { get; set; }
}
