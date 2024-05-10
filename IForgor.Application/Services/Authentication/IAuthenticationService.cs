namespace IForgor.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Register(string nickname, string email, string password);

    AuthenticationResult Login(string email, string password);
}
