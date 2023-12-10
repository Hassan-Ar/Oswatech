using Abp.Application.Services.Dto;
using Oswatech.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Buildings.Dtos
{
    public class BuildingDto : ProductDto
    {
        public bool HasGarage { get; set; }

        public Guid? ProjectId { get; set; }

    }
}
