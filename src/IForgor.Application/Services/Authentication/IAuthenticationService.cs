using ErrorOr;

namespace IForgor.Application.Services.Authentication;

public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Register(string nickname, string email, string password);

    ErrorOr<AuthenticationResult> Login(string email, string password);
}
