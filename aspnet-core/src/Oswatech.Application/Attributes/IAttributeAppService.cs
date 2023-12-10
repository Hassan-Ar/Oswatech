using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Oswatech.Attributes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Attributes
{
    public interface IAttributeAppService : ICrudAppService<AttributeDto,Guid,PagedAndSortedResultRequestDto>
        
    {

    }
}
