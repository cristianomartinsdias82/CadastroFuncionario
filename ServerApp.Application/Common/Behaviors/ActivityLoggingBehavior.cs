using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using ServerApp.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static ServerApp.SharedKernel.Helpers.ExceptionHelper;

namespace ServerApp.Application.Common.Behaviors
{
    public class ActivityLoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : ApplicationResponse, new()
    {
        private readonly ILogger<ActivityLoggingBehavior<TRequest, TResponse>> _logger;

        public ActivityLoggingBehavior(ILogger<ActivityLoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger ?? throw ArgNullEx($"Argumento {nameof(logger)} não podo ser nulo");
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation($"{DateTime.Now:HH:mm:ss.fff} ({typeof(TRequest).Name}) Iniciando processo...");

            var response = await next();

            _logger.LogInformation($"{DateTime.Now:HH:mm:ss.fff} ({typeof(TRequest).Name}) Processo concluído.");

            return response;
        }
    }
}
