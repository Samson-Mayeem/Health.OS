using HealthOS.Models.Users;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Text;

namespace RealEstate.API.Helpers
{
    public class Helper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Helper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static string GetDummyText(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-._~";
            var random = new Random();
            var result = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }

        public static bool UserHasRoles(List<string> rolesToSearch, List<string> existingRoles)
        {
            if (rolesToSearch == null || existingRoles == null) return false;

            rolesToSearch = rolesToSearch.Select(m => m.ToUpper()).ToList();

            return existingRoles.Select(m => m.ToUpper()).Any(m => rolesToSearch.Contains(m.ToUpper()));
        }

        public bool UserHasRoles(List<string> rolesToSearch)
        {
            var user = (User)_httpContextAccessor.HttpContext.Items["User"];
            var existingRoles = (List<string>)_httpContextAccessor.HttpContext.Items["Roles"];

            if (rolesToSearch == null) return false;

            if (rolesToSearch == null || existingRoles == null || user == null) return false;

            return existingRoles.Any(m => rolesToSearch.Contains(m.ToUpper()));
        }


        public bool UserHasRoles(string role)
        {
            if(role == null) return false;

            return UserHasRoles(new List<string> { role });
        }

        public bool UserHasRoles(params string[] roles)
        {
            var _roles = roles ?? new string[] { };
            var rolesList = _roles.ToList();

            return UserHasRoles(rolesList);
        }
    }
}
