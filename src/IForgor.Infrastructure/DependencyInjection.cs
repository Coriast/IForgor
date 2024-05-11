using IForgor.Application.Common.Interfaces.Authentication;
using IForgor.Application.Common.Interfaces.Persistence;
using IForgor.Application.Common.Interfaces.Services;
using IForgor.Infrastructure.Authentication;
using IForgor.Infrastructure.Persistence;
using IForgor.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IForgor.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        // Setting as Singleton because we use only a single instance through the entire application
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        // Keeps the same instance throughout the entire request
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
