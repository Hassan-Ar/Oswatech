using System.Threading.Tasks;
using Abp.Application.Services;
using Oswatech.Authorization.Accounts.Dto;

namespace Oswatech.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
