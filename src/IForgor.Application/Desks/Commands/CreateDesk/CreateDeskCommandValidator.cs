using FluentValidation;

namespace IForgor.Application.Desks.Commands.CreateDesk;

public class CreateDeskCommandValidator : AbstractValidator<CreateDeskCommand>
{
    public CreateDeskCommandValidator()
    {
        RuleFor(desk => desk.Title).NotEmpty();
    }
}
