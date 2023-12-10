using Abp.Domain.Entities.Auditing;
using Castle.MicroKernel.Registration;
using Oswatech.Models.Attributes;
using Oswatech.Models.Products;
using Oswatech.ProductsStatus;
using Oswatech.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Buildings
{
    public class Building : FullAuditedEntity<Guid>
    {
        public string ProductNumber { get; set; }
        public string ProductAddress { get; set; }
        public Status ProductStatus { get; set; }
        public DateTime RentEndDate { get; set; }
        public int Price { get; set; }
        public bool ProductAvailablety { get; set; }
        public bool HasGarage { get; set; }
        public virtual ICollection<Models.Attributes.Attribute>? ProductAttributes { get; set; }

        #region
        public Guid? ProjectId { get; set; }
        public virtual Project? Project { get; set; }
        public virtual ICollection<Properties.Property>? properties { get; set; }

        #endregion

    }
}
