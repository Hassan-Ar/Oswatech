using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Attributes.Dtos
{
    public class AttributeDto : AuditedEntityDto<Guid>
    {
        public string Title { get; set; }
        public string LogImgPath { get; set; }
        public Guid ProductId { get; set; }
    }
}
