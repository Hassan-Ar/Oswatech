﻿using Abp.Application.Services.Dto;
using Oswatech.Models.Products;
using Oswatech.ProductsStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Products.Dtos
{
    public class ProductDto : AuditedEntityDto<Guid>
    {
        public string ProductNumber { get; set; }
        public string ProductAddress { get; set; }
        public int Price { get; set; }
        public bool ProductAvailablety { get; set; }
        public DateTime RentEndDate { get; set; }
        public Status ProductStatus { get; set; } // for rent
    }
}
