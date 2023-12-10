using Abp.Application.Services.Dto;
using Oswatech.Models.Products;
using Oswatech.ProductsStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Products.Dtos
{
    public class GetListProductInputDto : PagedAndSortedResultRequestDto
    {

        public Status? status { get; set; }
        public int? BedsNumber { get; set; }
        public int? RoomsNumber { get; set; }
        public int? Price { get; set; }
        public string Address { get; set; }

    }
}
