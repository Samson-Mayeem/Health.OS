using System.ComponentModel.DataAnnotations;

namespace Health.OS.APi.Security.UserSecurityConfiguration.UserDto;

public class UserLoginDto
{
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}