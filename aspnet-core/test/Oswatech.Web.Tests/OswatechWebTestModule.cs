using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Oswatech.EntityFrameworkCore;
using Oswatech.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Oswatech.Web.Tests
{
    [DependsOn(
        typeof(OswatechWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class OswatechWebTestModule : AbpModule
    {
        public OswatechWebTestModule(OswatechEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OswatechWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(OswatechWebMvcModule).Assembly);
        }
    }
}