using Abp.Application.Services;
using Oswatech.MultiTenancy.Dto;

namespace Oswatech.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

