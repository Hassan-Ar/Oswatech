using Microsoft.AspNetCore.Identity;
using Oswatech.Buildings;
using Oswatech.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Models
{
    public class ApplicationUser : IdentityUser
    {

        public ICollection<Project> UserProject { get; set; }
        public ICollection<Building> UserBuildings { get; set; }
        public ICollection<Properties.Property> UserProperty { get; set; }

       



    }
}
