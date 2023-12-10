using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Oswatech.Authorization.Roles;
using Oswatech.Authorization.Users;
using Oswatech.MultiTenancy;
using Oswatech.Buildings;
using Oswatech.Projects;
using Oswatech.Models.Products;
using Oswatech.Models.Attributes;

namespace Oswatech.EntityFrameworkCore
{
    public class OswatechDbContext : AbpZeroDbContext<Tenant, Role, User, OswatechDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public OswatechDbContext(DbContextOptions<OswatechDbContext> options)
            : base(options)
        {

        }
        public DbSet<Properties.Property> Properties { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<UserHistory> UserHistory { get; set; }
        public DbSet<Attribute> Attributes { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>(
        //        x => x.HasKey(opt => opt.Id)
        //        );
        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
