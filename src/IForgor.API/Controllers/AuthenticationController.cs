using ErrorOr;
using IForgor.Application.Authentication.Commands.Register;
using IForgor.Application.Authentication.Common;
using IForgor.Application.Authentication.Queries.Login;
using IForgor.Contracts.Authentication;
using IForgor.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IForgor.API.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.Nickname, request.Email, request.Password);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

        if(authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        }

        return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
        );
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.Nickname,
            authResult.User.Email,
            authResult.Token
        );
    }

}
