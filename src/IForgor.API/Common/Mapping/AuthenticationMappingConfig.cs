using IForgor.Application.Authentication.Commands.Register;
using IForgor.Application.Authentication.Common;
using IForgor.Application.Authentication.Queries.Login;
using IForgor.Contracts.Authentication;
using Mapster;

namespace IForgor.API.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}
