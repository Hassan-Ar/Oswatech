using Abp.Domain.Entities.Auditing;
using Oswatech.Authorization.Users;
using Oswatech.ProductsStatus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Models.Products
{
    public class UserHistory : AuditedEntity<Guid>
    {
        public ProductType Type { get; set; }

        public long UserId { get; set; }

        public virtual User User { get; set; }

        public Guid ProductId { get; set; }

        public DateTime? RentEndDate { get; set; }

        public Status TransType { get; set; }
    }
}


