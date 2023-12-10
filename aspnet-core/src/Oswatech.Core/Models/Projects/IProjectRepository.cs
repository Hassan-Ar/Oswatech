using Abp.Domain.Repositories;
using Oswatech.ProductsStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Projects
{
    public interface IProjectRepository : IRepository<Project,Guid>
    {
        public  Task<(List<Project>, int count)> GetListAsync(
         string address, Status? status = null, int? price = null, int skipCount = 0, int maxResultCount = int.MaxValue, string sorting = null);

        public  IQueryable<Project> ApplyFilter(
            IQueryable<Project> query,
            string address = null,
            Status? status = null,
            int? minPrice = null);
    }
}
