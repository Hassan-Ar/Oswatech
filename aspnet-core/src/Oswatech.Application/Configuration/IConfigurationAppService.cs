using System.Threading.Tasks;
using Oswatech.Configuration.Dto;

namespace Oswatech.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
