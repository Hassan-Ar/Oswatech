using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Oswatech.Configuration;

namespace Oswatech.Web.Host.Startup
{
    [DependsOn(
       typeof(OswatechWebCoreModule))]
    public class OswatechWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public OswatechWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OswatechWebHostModule).GetAssembly());
        }
    }
}
