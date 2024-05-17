using FluentValidation;

namespace IForgor.Application.Desks.Commands.CreateDesk;

public class CreateDeskCommandValidator : AbstractValidator<CreateDeskCommand>
{
    public CreateDeskCommandValidator()
    {
        RuleFor(prop => prop.Title).NotEmpty();
    }
}
