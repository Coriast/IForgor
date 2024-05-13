using ErrorOr;
using IForgor.Application.Authentication.Common;
using MediatR;

namespace IForgor.Application.Authentication.Queries.Login;
public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
