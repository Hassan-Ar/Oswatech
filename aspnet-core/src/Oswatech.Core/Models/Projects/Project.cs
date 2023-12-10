using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Oswatech.Authorization.Users;
using Oswatech.Buildings;
using Oswatech.Models.Products;
using Oswatech.ProductsStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Projects
{
    
    public class Project :  FullAuditedAggregateRoot<Guid>
    {
        public string ProductNumber { get; set; }
        public string ProductAddress { get; set; }
        public Status ProductStatus { get; set; }
        public DateTime RentEndDate { get; set; }
        public int Price { get; set; }
        public bool ProductAvailablety { get; set; }
        public bool HasMarket { get; set; }
        public virtual ICollection<Models.Attributes.Attribute>? ProductAttributes { get; set; }

        #region
        public virtual ICollection<Building> buildings { get; set; }
        #endregion

    }
}
