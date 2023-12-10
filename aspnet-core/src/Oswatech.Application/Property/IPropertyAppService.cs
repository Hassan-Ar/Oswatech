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

namespace Oswatech.Property
{
    public interface IPropertyAppService : IApplicationService
    {
        Task<PropertyDto> Create(CreatePropertyDto input);
        Task<PropertyDto> Update(UpdatePropertyDto input);
        Task<PagedResultDto<PropertyDto>> GetAll(GetListProductInputDto input);
        Task<PropertyDto> GetById(Guid id);
        Task Delete(Guid id);
    }
}
