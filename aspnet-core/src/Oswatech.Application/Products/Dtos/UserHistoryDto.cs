using Abp.Application.Services.Dto;
using Oswatech.Authorization.Users;
using Oswatech.Models.Products;
using Oswatech.ProductsStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Products.Dtos
{
    public class UserHistoryDto : EntityDto<Guid>
    {
        public ProductType Type { get; set; }
        public Guid ProductId { get; set; }

        public DateTime? RentEndDate { get; set; }

        public Status TransType { get; set; }
    }
}
