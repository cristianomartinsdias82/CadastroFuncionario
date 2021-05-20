using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServerApp.Core.Contracts.Repository;
using ServerApp.Infrastructure.Persistence;
using ServerApp.Infrastructure.Persistence.Ef;

namespace ServerApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ServerAppDbContext>(x =>
            x.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                            y => y.MigrationsAssembly(typeof(ServerAppDbContext).Assembly.FullName)));

            services.AddScoped<IEmployeesRepository, EmployeesRepository>();

            return services;
        }
    }
}
