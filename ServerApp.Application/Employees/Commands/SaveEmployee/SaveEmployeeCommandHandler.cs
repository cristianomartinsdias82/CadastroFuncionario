using AutoMapper;
using ServerApp.Application.Common.Handlers;
using ServerApp.Core.Contracts.Repository;
using ServerApp.Core.Entities;
using ServerApp.SharedKernel;
using System.Threading;
using System.Threading.Tasks;
using static ServerApp.SharedKernel.Helpers.ExceptionHelper;

namespace ServerApp.Application.Employees.Commands.SaveEmployee
{
    internal sealed class SaveEmployeeCommandHandler : IApplicationRequestHandler<SaveEmployeeRequest, SaveEmployeeResponse>
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IMapper _mapper;

        public SaveEmployeeCommandHandler(IEmployeesRepository employeesRepository, IMapper mapper)
        {
            _employeesRepository = employeesRepository ?? throw ArgNullEx($"Argumento {nameof(employeesRepository)} não pode ser nulo");
            _mapper = mapper ?? throw ArgNullEx($"Argumento {nameof(mapper)} não pode ser nulo");
        }

        public async Task<SaveEmployeeResponse> Handle(SaveEmployeeRequest request, CancellationToken cancellationToken)
        {
            var successful = await _employeesRepository.SaveAsync(_mapper.Map<Employee>(request), cancellationToken);

            return new SaveEmployeeResponse
            {
                Result = successful ?
                OperationResult.Successful("Funcionário cadastrado com sucesso!") :
                OperationResult.Failure("Não foi possível cadastrar o funcionário!")
            };
        }
    }
}
