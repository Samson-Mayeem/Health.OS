using HealthOS.Models;
using HealthOS.Models.Users;

namespace RealEstate.Data.Authorization
{
    public class AuthorizationHelper
    {
        public bool UserIsRecordAuthorized(Guid resourceUserId, User user)
        {
            if (user != null
                && ((resourceUserId == user.Id)
                        || user.UserRoles.Any(m => m.Role.Name.ToUpper().Equals("ADMIN") || m.Role.Name.ToUpper().Equals("SUPER ADMIN"))
                   )
               )
            {
                return true;
            }

            return false;
        }
    }
}
