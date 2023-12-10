using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Models.Products
{
    public class SecondProduct : AuditedEntity<Guid>
    {
        public string Name { get; set; }
    }
}
