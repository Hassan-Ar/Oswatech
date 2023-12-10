using Abp.Collections.Extensions;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Linq.Extensions;
using Oswatech.Buildings;
using Oswatech.ProductsStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.EntityFrameworkCore.Repositories.Buildings
{
    public class BuildingRepository : EfCoreRepositoryBase<OswatechDbContext, Building, Guid>, IBuildingRepository
    {
        public BuildingRepository(IDbContextProvider<OswatechDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public IQueryable<Building> ApplyFilter(IQueryable<Building> query, string address = null, Status? status = null, int? minPrice = null)
        {
            return query
                         .WhereIf(!string.IsNullOrEmpty(address), x => x.ProductAddress.Contains(address))
                         .WhereIf(status.HasValue, x => x.ProductStatus == status)
                         .WhereIf(minPrice.HasValue, x => x.Price >= minPrice)
                                ;
        }

        public async Task<(List<Building>, int count)> GetListAsync(string address, Status? status =null, int? price = null, int skipCount = 0, int maxResultCount =int.MaxValue, string sorting = null)
        {
            var query = ApplyFilter(await GetQueryableAsync(), address, status, price);
            var count = query.Count();
            return (query.PageBy(skipCount, maxResultCount).ToList(), count);
        }
    }
}
