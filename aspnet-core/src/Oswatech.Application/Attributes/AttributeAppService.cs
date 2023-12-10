using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Oswatech.Attributes.Dtos;
using Oswatech.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Attributes
{
    public class AttributeAppService : CrudAppService<Models.Attributes.Attribute, AttributeDto, Guid>, IAttributeAppService
    {
        public AttributeAppService(IRepository<Models.Attributes.Attribute, Guid> repository) : base(repository)
        {
        }
    }
}
