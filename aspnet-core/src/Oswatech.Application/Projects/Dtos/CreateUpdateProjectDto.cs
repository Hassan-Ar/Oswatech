using Abp.Application.Services.Dto;
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
    public class CreateUpdateProjectDto : CreateUpdateProductDto
    {

        public bool HasMarket { get; set; }

    }
}
