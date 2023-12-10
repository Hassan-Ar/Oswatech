using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Projects.Dtos
{
    public class RentRequestDto 
    {
        public Guid ProjectId { get; set; }
        public DateTime RentEndDate { get; set; }
    }
}
