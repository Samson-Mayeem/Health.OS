using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using HealthOS.Utility;
using Health.OS;
using HealthOS.Models.Users;

namespace RealEstate.API.Authorization
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<string> _roles;

        public AuthorizeAttribute(params string[] roles)
        {
            _roles = roles ?? new string[] { };
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // authorization
            var user = (User)context.HttpContext.Items["User"];
            if (user == null || (_roles.Any() && !UserHasRoles((List<string>)context.HttpContext.Items["Roles"])))
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }

        private bool UserHasRoles(List<string> roles)
        {
            if (roles == null) return false;
            return _roles.Any(m => roles.Contains(m.ToUpper()));
        }
    }
}