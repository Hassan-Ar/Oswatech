using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Oswatech.Buildings;
using Oswatech.Models.Products;
using Oswatech.ProductsStatus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Properties
{
    public class Property : FullAuditedAggregateRoot<Guid>
    {

        public string ProductNumber { get; set; }
        public string ProductAddress { get; set; }
        public Status ProductStatus { get; set; }
        public DateTime RentEndDate { get; set; }
        public int Price { get; set; }
        public bool ProductAvailablety { get; set; }
        public virtual ICollection<Models.Attributes.Attribute>? ProductAttributes { get; set; }
        public int BedsNumber { get; set; }
        public int WindowsNumber { get; set; }
        public int BathsNumber { get; set; }
        public int RoomsNumber { get; set; }
        public bool HasWIFI { get; set; }

        #region
        [ForeignKey(nameof(Building))]
        public Guid? BuildingId { get; set; }
        public virtual Building Building { get; set; }


        #endregion

    }
}
