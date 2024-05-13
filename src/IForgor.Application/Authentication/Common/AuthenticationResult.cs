using IForgor.Domain.Entities;

namespace IForgor.Application.Authentication.Common;
public record AuthenticationResult(User User, string Token);
