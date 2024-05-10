namespace IForgor.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult Register(string nickname, string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), nickname, email, "token");
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "nickname", email, "token");
    }
}
