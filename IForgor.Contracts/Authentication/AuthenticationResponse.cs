namespace IForgor.Contracts.Authentication;
public record AuthenticationResponse(Guid Id, string Nickname, string Email, string Token);
