using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Linq.Extensions;
using Oswatech.ProductsStatus;
using Oswatech.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Oswatech.EntityFrameworkCore.Repositories.Properties
{
    public class PropertyRepository : EfCoreRepositoryBase<OswatechDbContext, Property, Guid>, IPropertyRepository
    {
        public PropertyRepository(IDbContextProvider<OswatechDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<(List<Property>, int count)> GetListAsync(
            string? address =null,
            Status? status =null,
            int? price = null,
            int? bedsnumber = null,
            int? roomsnumber = null,
            int skipCount = 0,
            int maxResultCount = int.MaxValue,
            string sorting = null)
        {
            var query = ApplyFilter(await GetQueryableAsync(), address,  status,  price,bedsnumber, roomsnumber);
            var count = query.Count();
            return (query.PageBy(skipCount,maxResultCount).ToList(),count);
        }

        protected virtual IQueryable<Property> ApplyFilter(
            IQueryable<Property> query,
            string address = null,
            Status? status = null,
            int? minPrice = null,
            int? bedsnumber = null,
            int? roomsnumber = null)
        {
            return query
                .WhereIf(!string.IsNullOrEmpty(address), x => x.ProductAddress.Contains(address))
                .WhereIf(status.HasValue, x => x.ProductStatus == status)
                .WhereIf(minPrice.HasValue, x => x.Price >= minPrice)
                .WhereIf(bedsnumber.HasValue, x => x.BedsNumber == bedsnumber)
                .WhereIf(roomsnumber.HasValue, x => x.RoomsNumber == roomsnumber);
            ;
        }




    }
}
// EfCoreRepository<TechCourseDbContext, Category, Guid> ,ICategoryRepository