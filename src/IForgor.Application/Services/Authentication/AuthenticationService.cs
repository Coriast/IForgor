using IForgor.Application.Common.Interfaces.Authentication;
using IForgor.Application.Common.Interfaces.Persistence;
using IForgor.Domain.Entities;

namespace IForgor.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string nickname, string email, string password)
    {
        // 1. Validate the user doesn't exist
        if(_userRepository.GetUserByEmail(email) != null)
        {
            throw new Exception("User with given email already exists");
        }

        // 2. Create user & persist to DB
        var user = new User
        { 
            Nickname = nickname,
            Email = email,
            Password = password 
        };

        _userRepository.Add(user);

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        var user = _userRepository.GetUserByEmail(email);
        if (user is null)
        {
            throw new Exception("User with given email does not exist.");
        }

        if(user.Password != password)
        {
            throw new Exception("Invalid password");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
