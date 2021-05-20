using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ServerApp.Infrastructure.Persistence.Ef.Factory
{
    internal class ServerAppDbContextFactory : IDesignTimeDbContextFactory<ServerAppDbContext>
    {
        public ServerAppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ServerAppDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Initial catalog=TesteJPVTech;Integrated security=SSPI;");

            return new ServerAppDbContext(optionsBuilder.Options);
        }
    }
}
