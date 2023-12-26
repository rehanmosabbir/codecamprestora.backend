using FluentValidation;
using MediatR;

namespace CodeCampRestora.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var validationResults = await Task.WhenAll(
            _validators.Select(validator => validator.ValidateAsync(request)));

        var errors = validationResults
            .Where(validationResult => !validationResult.IsValid)
            .SelectMany(validationResult => validationResult.Errors)
            .Select(validationFailure => new {
                propertyName = validationFailure.PropertyName,
                errorMessage = validationFailure.ErrorMessage
            })
            .ToList();

        foreach(var error in errors)
        {
            Console.WriteLine($"{error.propertyName} - {error.errorMessage}");
        }

        return await next();
    }
}