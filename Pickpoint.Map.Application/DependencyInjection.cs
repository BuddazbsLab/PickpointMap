using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Pickpoint.Map.Application.Common.Behaviors;

namespace Pickpoint.Map.Application.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(IPipelineBehavior<,>));
            //services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            return services;
        }
    }
}
