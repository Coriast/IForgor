using FluentValidation;

namespace IForgor.Application.Authentication.Queries.Login;
public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(prop => prop.Email).NotEmpty();
        RuleFor(prop => prop.Password).NotEmpty();
    }
}
