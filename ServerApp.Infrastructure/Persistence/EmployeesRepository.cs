using ServerApp.Core.Contracts.Repository;
using ServerApp.Core.Entities;
using ServerApp.Infrastructure.Persistence.Ef;
using System.Threading;
using System.Threading.Tasks;
using static ServerApp.SharedKernel.Helpers.ExceptionHelper;

namespace ServerApp.Infrastructure.Persistence
{
    internal sealed class EmployeesRepository : IEmployeesRepository
    {
        private readonly ServerAppDbContext _dbContext;

        public EmployeesRepository(ServerAppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw ArgNullEx($"Argumento {nameof(dbContext)} não pode ser nulo");
        }

        public async Task<bool> SaveAsync(Employee employee, CancellationToken cancellationToken)
        {
            await _dbContext.Employees.AddAsync(employee, cancellationToken);

            return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
