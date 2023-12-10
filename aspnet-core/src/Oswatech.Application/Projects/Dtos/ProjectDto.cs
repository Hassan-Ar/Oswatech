using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Oswatech.Products.Dtos;
using Oswatech.ProductsStatus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Projects.Dtos
{
    [AutoMapTo(typeof(Project))]

    public class ProjectDto : AuditedEntityDto<Guid>
    {
        public string ProductNumber { get; set; }
        public string ProductAddress { get; set; }
        public int Price { get; set; }
        public bool ProductAvailablety { get; set; }
        public bool HasMarket { get; set; }

        public DateTime RentEndDate { get; set; }
        public Status ProductStatus { get; set; } // for rent
    }
}
