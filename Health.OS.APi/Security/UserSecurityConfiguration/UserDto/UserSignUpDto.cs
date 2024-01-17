using System.ComponentModel.DataAnnotations;
namespace Health.OS.APi.Security.UserSecurityConfiguration.UserDto;

public class UserSignUpDto
{

    [Required] public string UserName { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string EncryptedPassword { get; set; }
}
