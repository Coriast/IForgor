using ErrorOr;
using FluentValidation;
using IForgor.Application.Authentication.Commands.Register;
using IForgor.Application.Authentication.Common;
using MediatR;

namespace IForgor.Application.Common.Behaviours;
public class ValidateRegisterCommandBehaviour : IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IValidator<RegisterCommand> _validator;

    public ValidateRegisterCommandBehaviour(IValidator<RegisterCommand> validator)
    {
        _validator = validator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if(validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult.Errors
            .Select(error => Error.Validation(error.PropertyName, error.ErrorMessage))
            .ToList();

        return errors;
    }
}
