using IForgor.Application.Services.Authentication;
using IForgor.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace IForgor.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(request.Nickname, request.Email, request.Password);

        var response = new AuthenticationResponse(
            authResult.user.Id,
            authResult.user.Nickname,
            authResult.user.Email,
            authResult.Token
            );

        return Ok(response);
    }
    
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(request.Email, request.Password);

        var response = new AuthenticationResponse(
            authResult.user.Id,
            authResult.user.Nickname,
            authResult.user.Email,
            authResult.Token
            );

        return Ok(response);
    }


}
