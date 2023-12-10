using Abp.Application.Services.Dto;
using Oswatech.Products.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Property.Dtos
{
    public class UpdatePropertyDto : ProductDto
    {
        public int BedsNumber { get; set; }
        public int WindowsNumber { get; set; }
        public int BathsNumber { get; set; }
        public int RoomsNumber { get; set; }
        public Guid? BuildingId { get; set; }
        public bool HasWIFI { get; set; }

    }
}
