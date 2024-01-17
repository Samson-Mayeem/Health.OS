using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Health.OS.APi.Security;
using Health.OS.APi.Security.UserSecurityConfiguration.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
namespace Health.OS.APi.Security.UserSecurityConfiguration.Services
{
    public class TokenStringGenerator : ITokenGenerator
    {
        private readonly JwtConfig _jwtConfig;

        public TokenStringGenerator(IOptions<JwtConfig> jwtConfig)
        {
            _jwtConfig = jwtConfig.Value;
        }

        public string GenerateJwtToken(IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User object is null.");
            }

            if (string.IsNullOrEmpty(_jwtConfig.Secret))
            {
                throw new ArgumentNullException(nameof(_jwtConfig.Secret), "JWT secret is null or empty.");
            }

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                        new Claim("id", user.Id),
                        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
                    }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}