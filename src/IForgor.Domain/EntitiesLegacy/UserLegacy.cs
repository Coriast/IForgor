namespace IForgor.Domain.Entities;
public class UserLegacy
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nickname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
