using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Application.Employees.Commands.SaveEmployee;
using System.Threading;
using System.Threading.Tasks;
using static ServerApp.SharedKernel.Helpers.ExceptionHelper;

namespace ServerApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ISender _mediator;

        public EmployeesController(ISender mediator)
        {
            _mediator = mediator ?? throw ArgNullEx($"Argumento {nameof(mediator)} não pode ser nulo");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaveEmployeeRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            var result = response.GetResult();

            if (result.Succeeded)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
