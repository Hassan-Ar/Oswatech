using Abp.Application.Services;
using Oswatech.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Products
{
    public interface IUserHistoryAppService  : IApplicationService
    {
        Task<List<UserHistoryDto>> GetCurrentUserHistory();
    }
}
