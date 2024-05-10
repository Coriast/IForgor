using IForgor.Application.Interfaces.Authentication;

namespace IForgor.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Register(string nickname, string email, string password)
    {
        // Check if user already exists


        // Create user -> Generating unique ID

        // Create JWT token
        Guid userId = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(userId, nickname);

        return new AuthenticationResult(userId, nickname, email, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "nickname", email, "token");
    }
}
