﻿using FluentValidation;
using IForgor.Application.Common.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IForgor.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        services.AddScoped(typeof(IPipelineBehavior<, >), typeof(ValidationBehaviour<, >));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
