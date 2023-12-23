using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repositories
{
    public class AppDbContext : DbContext
    {
        public IConfiguration _config { get; set; }
        public AppDbContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("AZURE_SQL_CONNECTIONSTRING"),
                sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
