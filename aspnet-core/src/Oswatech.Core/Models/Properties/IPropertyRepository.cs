using Abp.Domain.Repositories;
using Oswatech.ProductsStatus;
using Oswatech.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Properties
{
    public interface IPropertyRepository : IRepository<Property,Guid>
    {
          Task<(List<Property>, int count)> GetListAsync(
           string? address =null,
            Status? status =null,
            int? price = null,
            int? bedsnumber = null,
            int? roomsnumber = null,
            int skipCount = 0,
            int maxResultCount = int.MaxValue,
            string sorting = null);
        
    }

}
