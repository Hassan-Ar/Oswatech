using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Oswatech.Products.Dtos;
using Oswatech.Projects.Dtos;
using Oswatech.Property.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Projects
{
    public interface IProjectAppService : IApplicationService
    {
        Task<ProjectDto> Create(CreateUpdateProjectDto input);
        Task<ProjectDto> Update(CreateUpdateProjectDto input);
        Task<PagedResultDto<ProjectDto>> GetAll(GetListProductInputDto input);
        Task<ProjectDto> GetById(Guid id);
        Task Delete(Guid id);
        Task Rent(RentRequestDto input);
        Task Buy(Guid input);

    }
}
