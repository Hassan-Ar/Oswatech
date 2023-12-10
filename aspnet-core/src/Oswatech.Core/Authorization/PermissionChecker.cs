using Abp.Authorization;
using Oswatech.Authorization.Roles;
using Oswatech.Authorization.Users;

namespace Oswatech.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
