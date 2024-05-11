using IForgor.Domain.Entities;

namespace IForgor.Application.Services.Authentication;
public record AuthenticationResult(User user, string Token);
