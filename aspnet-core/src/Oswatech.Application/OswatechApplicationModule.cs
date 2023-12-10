using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Oswatech.Authorization;
using Oswatech.Properties;
using Oswatech.Property;

namespace Oswatech
{
    [DependsOn(
        typeof(OswatechCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class OswatechApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<OswatechAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(OswatechApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);
           // IocManager.Register<IPropertyRepository,PropertyRepository>();

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
