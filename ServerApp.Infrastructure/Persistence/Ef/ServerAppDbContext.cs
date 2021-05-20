using Microsoft.EntityFrameworkCore;
using ServerApp.Core.Entities;

namespace ServerApp.Infrastructure.Persistence.Ef
{
    internal class ServerAppDbContext : DbContext
    {
        public ServerAppDbContext() { }

        public ServerAppDbContext(DbContextOptions<ServerAppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ServerAppDbContext).Assembly);
        }
    }
}
