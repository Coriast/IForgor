using ErrorOr;
using IForgor.Application.Services.Authentication.Common;

namespace IForgor.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}
