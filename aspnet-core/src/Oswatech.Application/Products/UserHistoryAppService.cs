using Microsoft.AspNetCore.Authorization;
using Oswatech.Models.Products;
using Oswatech.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Products
{
    [Authorize]
    public class UserHistoryAppService : OswatechAppServiceBase , IUserHistoryAppService
    {
        private readonly IUserHistoryRepository _userHistoryRepository;
        public UserHistoryAppService(IUserHistoryRepository userHistoryRepository)
        {
            _userHistoryRepository = userHistoryRepository;
        }

        public async Task<List<UserHistoryDto>> GetCurrentUserHistory()
        {
            var user = await GetCurrentUserAsync();

            var history = _userHistoryRepository
                                  .GetAll()
                                  .Where(x => x.UserId == user.Id)
                                  .ToList();
            
            return ObjectMapper.Map<List<UserHistoryDto>>(history);
        }
    }
}
