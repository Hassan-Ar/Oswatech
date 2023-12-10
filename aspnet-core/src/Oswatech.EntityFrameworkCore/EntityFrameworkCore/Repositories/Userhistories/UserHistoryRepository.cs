using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using Oswatech.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.EntityFrameworkCore.Repositories.Userhistories
{
    public class UserHistoryRepository : EfCoreRepositoryBase<OswatechDbContext, UserHistory, Guid>, IUserHistoryRepository
    {
        public UserHistoryRepository(IDbContextProvider<OswatechDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
