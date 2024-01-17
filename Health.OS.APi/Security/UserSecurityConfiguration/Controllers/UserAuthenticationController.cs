using Health.OS.APi.Security.UserSecurityConfiguration.UserDto;
using Health.OS.APi.Security.UserSecurityConfiguration.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Health.OS.APi.Security.AuthResults;
namespace Health.OS.APi.Security.UserSecurityConfiguration.Controllers;


[Route("almanac/api/v1/[controller]")]
[ApiController]
public class UserAuthenticationController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ILogger<UserAuthenticationController> _logger;
    private readonly JwtConfig _jwtConfig;
    private readonly ITokenGenerator _itokenStringGenerator;
    public UserAuthenticationController(
        UserManager<IdentityUser> userManager,
        IOptionsMonitor<JwtConfig> optionsMonitor,
        ILogger<UserAuthenticationController> logger, ITokenGenerator itokenStringGenerator)
    {
        _logger = logger;
        _itokenStringGenerator = itokenStringGenerator;
        _userManager = userManager;
        _jwtConfig = optionsMonitor.CurrentValue;
    }

    [HttpPost("registration")]
    public async Task<IActionResult> SignUp(UserSignUpDto userSignUpDto)
    {
        if (ModelState.IsValid)
        {

            var existUser = await _userManager.FindByEmailAsync(
                userSignUpDto.Email);

            if (existUser != null)
            {
                return BadRequest("${Error, user with email exists already}");
            }

            var newUser = new IdentityUser()
            {
                Email = userSignUpDto.Email,
                UserName = userSignUpDto.UserName
            };
            var isCreated = await _userManager.CreateAsync(newUser, userSignUpDto.EncryptedPassword);
            if (isCreated.Succeeded)
            {
                var token = _itokenStringGenerator.GenerateJwtToken(newUser);
                return Ok(new AuthResult()
                {
                    Result = true,
                    ResultToken = token
                });
            }
            return BadRequest(new { Errors = isCreated.Errors.Select(x => x.Description).ToList() });
        }
        return BadRequest("Invalid request payload");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userSigninDto)
    {
        if (ModelState.IsValid)
        {
            var existingUser = await _userManager.FindByEmailAsync(userSigninDto.Email);
            if (existingUser is null)
            {
                return BadRequest("Error in authentication");
            }

            var checkPasswordValid = await _userManager.CheckPasswordAsync(existingUser, userSigninDto.Password);
            if (checkPasswordValid)
            {
                var token = _itokenStringGenerator.GenerateJwtToken(existingUser);
                return Ok(new LoginRequestResponse()
                {
                    ResultToken = token,
                    Result = true
                });
            }
            _itokenStringGenerator.GenerateJwtToken(existingUser);
        }

        return BadRequest("Error in authentication");
    }
}

