using ErrorOr;
using IForgor.Application.Authentication.Common;
using IForgor.Application.Common.Interfaces.Authentication;
using IForgor.Application.Common.Interfaces.Persistence;
using IForgor.Domain.Common.Errors;
using IForgor.Domain.Entities;
using MediatR;

namespace IForgor.Application.Authentication.Commands.Register;
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // 1. Validate the user doesn't exist
        if (_userRepository.GetUserByEmail(command.Email) != null)
        {
            return Errors.User.DuplicateEmail;
        }

        // 2. Create user & persist to DB
        var user = new User
        {
            Nickname = command.Nickname,
            Email = command.Email,
            Password = command.Password
        };

        _userRepository.Add(user);

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
