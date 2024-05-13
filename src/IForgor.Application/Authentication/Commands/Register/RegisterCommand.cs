using ErrorOr;
using IForgor.Application.Authentication.Common;
using MediatR;

namespace IForgor.Application.Authentication.Commands.Register;
public record RegisterCommand(string Nickname, string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
