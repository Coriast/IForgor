using FluentValidation;

namespace IForgor.Application.Authentication.Commands.Register;
public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(prop => prop.Nickname).NotEmpty();
        RuleFor(prop => prop.Email).NotEmpty();
        RuleFor(prop => prop.Password).NotEmpty();
    }
}
