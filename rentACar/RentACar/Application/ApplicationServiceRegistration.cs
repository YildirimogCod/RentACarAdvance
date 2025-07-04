﻿using System.Reflection;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transactional;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.SeriLog;
using Core.CrossCuttingConcerns.SeriLog.Logger;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
                configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
                configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
                configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });
            services.AddSingleton<LoggerServiceBase, FileLogger>();
            return services;
        }

        public static IServiceCollection AddSubClassesOfType(this IServiceCollection services, Assembly assembly,
            Type type, Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
        {
            var types = assembly.GetTypes()
                .Where(t => t.IsSubclassOf(type) && type != t).ToList();

            foreach (var t in types)
            {
                if (addWithLifeCycle == null)
                {
                    services.AddScoped(t);
                }
                else
                {
                    services = addWithLifeCycle(services, t);
                }
            }
            return services;
        }
    }
}
