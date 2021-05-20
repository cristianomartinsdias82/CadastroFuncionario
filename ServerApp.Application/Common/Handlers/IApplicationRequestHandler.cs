using MediatR;
using ServerApp.SharedKernel;

namespace ServerApp.Application.Common.Handlers
{
    internal interface IApplicationRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : ApplicationResponse { }
}
