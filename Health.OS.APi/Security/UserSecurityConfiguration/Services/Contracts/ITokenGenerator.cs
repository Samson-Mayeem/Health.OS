using Microsoft.AspNetCore.Identity;

namespace Health.OS.APi.Security.UserSecurityConfiguration.Services.Contracts;

public interface ITokenGenerator
{
    string GenerateJwtToken(IdentityUser user);
}