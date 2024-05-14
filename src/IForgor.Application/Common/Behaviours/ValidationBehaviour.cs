using ErrorOr;
using FluentValidation;
using IForgor.Application.Authentication.Commands.Register;
using IForgor.Application.Authentication.Common;
using MediatR;

namespace IForgor.Application.Common.Behaviours;
public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehaviour(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if(_validator is null)
        {
            return await next();
        }

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if(validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult.Errors
            .Select(error => Error.Validation(error.PropertyName, error.ErrorMessage))
            .ToList();

        return (dynamic)errors;
    }
}
