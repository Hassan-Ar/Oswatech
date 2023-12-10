using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Oswatech.Controllers
{
    public abstract class OswatechControllerBase: AbpController
    {
        protected OswatechControllerBase()
        {
            LocalizationSourceName = OswatechConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
