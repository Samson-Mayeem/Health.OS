namespace RealEstate.Data.Authorization;

using HealthOS.DataAccess.Helpers;
using HealthOS.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using RealEstate.Data.Helpers;

using System.Net.Http;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContent context, IUnitOfWork unitOfWork, IJwtUtils jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var UserID = jwtUtils.ValidateJwtToken(token);
        if (UserID != null)
        {
            // attach user to context on successful jwt validation
            var userRepository = unitOfWork.GetRepository<User>() as IUserRepository;
            var user = await userRepository.GetAsync(UserID.Value, e => e.UserRoles);
            context.Items["User"] = user;

            if (user != null)
            {
                var userRoleRolesRepository = unitOfWork.GetRepository<UserRole>() as UserRoleRepository;
                context.Items["Roles"] = (await userRoleRolesRepository.GetByUserIdAsync(user.Id)).Select(m => m.Role.Name.ToUpper()).ToList();
            }
        }

        await _next(context);
    }


}