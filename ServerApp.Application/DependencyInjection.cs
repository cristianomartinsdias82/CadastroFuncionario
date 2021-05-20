using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServerApp.Application.Common.Behaviors;
using System.Reflection;

namespace ServerApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddAutoMapper(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ApplicationValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ActivityLoggingBehavior<,>));
            services.AddValidatorsFromAssemblies(new Assembly[] { assembly });

            return services;
        }
    }
}
