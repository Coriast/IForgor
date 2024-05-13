using ErrorOr;
using IForgor.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using IForgor.Domain.Common.Errors;
using IForgor.Application.Services.Authentication.Common;
using IForgor.Application.Services.Authentication.Commands;
using IForgor.Application.Services.Authentication.Queries;

namespace IForgor.API.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationCommandService _authCommandService;
    private readonly IAuthenticationQueryService _authQueryService;

    public AuthenticationController(IAuthenticationCommandService authCommandService, IAuthenticationQueryService authQueryService)
    {
        _authCommandService = authCommandService;
        _authQueryService = authQueryService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = _authCommandService.Register(request.Nickname, request.Email, request.Password);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = _authQueryService.Login(request.Email, request.Password);

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
