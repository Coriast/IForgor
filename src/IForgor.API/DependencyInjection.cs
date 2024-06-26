﻿using IForgor.API.Common.Errors;
using IForgor.API.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace IForgor.API;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, IForgorProblemDetailsFactory>();
        services.AddMappings();

        return services;
    }
}
