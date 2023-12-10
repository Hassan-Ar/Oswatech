using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Linq.Extensions;
using Oswatech.ProductsStatus;
using Oswatech.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.EntityFrameworkCore.Repositories.Projects
{
    public class ProjectRepository : EfCoreRepositoryBase<OswatechDbContext, Project, Guid>, IProjectRepository
    {
        public ProjectRepository(IDbContextProvider<OswatechDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public IQueryable<Project> ApplyFilter(IQueryable<Project> query, string address = null, Status? status = null, int? minPrice = null)
        {
            return query
                           .WhereIf(!string.IsNullOrEmpty(address), x => x.ProductAddress.Contains(address))
                           .WhereIf(status.HasValue, x => x.ProductStatus == status)
                           .WhereIf(minPrice.HasValue, x => x.Price >= minPrice)
                       ;
        }

        public async Task<(List<Project>, int count)> GetListAsync(string address, Status?  status= null, int? price=null, int skipCount =0 , int maxResultCount = int.MaxValue, string sorting =null)
        {
            var query = ApplyFilter(await GetQueryableAsync(), address, status, price);
            var count = query.Count();
            return (query.PageBy(skipCount, maxResultCount).ToList(), count);
        }

        // TODO addSorting

      

    }
}
