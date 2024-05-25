using FluentValidation;

namespace IForgor.Application.Fields.Commands.CreateField;
public class CreateFieldCommandValidator : AbstractValidator<CreateFieldCommand>
{
    public CreateFieldCommandValidator()
    {
        RuleFor(field => field.Title).NotEmpty();
    }
}
