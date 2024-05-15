using IForgor.Domain.Entities;

namespace IForgor.Application.Authentication.Common;
public record AuthenticationResult(UserLegacy User, string Token);
