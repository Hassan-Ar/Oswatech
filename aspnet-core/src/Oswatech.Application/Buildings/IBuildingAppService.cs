using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Oswatech.Buildings.Dtos;
using Oswatech.Products.Dtos;
using Oswatech.Projects.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Buildings
{
    internal interface IBuildingAppService : IApplicationService
    {
        Task<PagedResultDto<BuildingDto>> GetAll(GetListProductInputDto input);
        Task<BuildingDto> GetById(Guid id);
        Task<BuildingDto> Create(CreateBuildingDto input);
        Task<BuildingDto> Update(UpdateBuildingDto input);
        Task Delete(Guid id);
        Task Buy(Guid id);
        Task Rent(RentRequestDto input);

    }
}
