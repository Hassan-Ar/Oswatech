using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Oswatech.EntityFrameworkCore
{
    public static class OswatechDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<OswatechDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<OswatechDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
