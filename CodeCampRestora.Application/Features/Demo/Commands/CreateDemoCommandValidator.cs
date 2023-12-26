using FluentValidation;

namespace CodeCampRestora.Application.Features.Demo.Commands;

public class CreateDemoCommandValidator : AbstractValidator<CreateDemoCommand>
{
    public CreateDemoCommandValidator()
    {
        RuleFor(item => item.Id).NotEqual(Guid.Empty).WithMessage("Guid can't be empty");
        RuleFor(item => item.Name).NotEmpty();
        RuleFor(item => item.Address).NotEmpty();
    }
}