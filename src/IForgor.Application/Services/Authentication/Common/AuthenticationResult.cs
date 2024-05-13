using IForgor.Domain.Entities;

namespace IForgor.Application.Services.Authentication.Common;
public record AuthenticationResult(User User, string Token);
