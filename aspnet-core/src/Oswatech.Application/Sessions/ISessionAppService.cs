using System.Threading.Tasks;
using Abp.Application.Services;
using Oswatech.Sessions.Dto;

namespace Oswatech.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
