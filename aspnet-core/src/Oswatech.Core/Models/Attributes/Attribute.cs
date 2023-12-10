using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Models.Attributes
{
    public class Attribute : AuditedEntity<Guid>
    {
        public string Title { get; set; }
        public string LogImgPath { get; set; }
        public Guid ProductId { get; set; }

    }
}
