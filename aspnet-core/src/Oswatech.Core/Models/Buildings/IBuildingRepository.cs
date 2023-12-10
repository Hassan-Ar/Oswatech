using Abp.Domain.Repositories;
using Oswatech.ProductsStatus;
using Oswatech.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Buildings
{
    public interface IBuildingRepository : IRepository<Building,Guid>
    {
        public Task<(List<Building>, int count)> GetListAsync(
       string address, Status? status = null, int? price = null, int skipCount = 0, int maxResultCount = int.MaxValue, string sorting = null);

        public IQueryable<Building> ApplyFilter(
            IQueryable<Building> query,
            string address = null,
            Status? status = null,
            int? minPrice = null);
    }
}
