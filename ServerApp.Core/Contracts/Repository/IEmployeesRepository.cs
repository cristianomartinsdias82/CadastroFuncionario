using ServerApp.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ServerApp.Core.Contracts.Repository
{
    public interface IEmployeesRepository
    {
        Task<bool> SaveAsync(Employee employee, CancellationToken cancellationToken);
    }
}
