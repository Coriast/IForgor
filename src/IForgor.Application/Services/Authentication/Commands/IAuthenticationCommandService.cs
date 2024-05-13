using ErrorOr;
using IForgor.Application.Services.Authentication.Common;

namespace IForgor.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string nickname, string email, string password);
}
