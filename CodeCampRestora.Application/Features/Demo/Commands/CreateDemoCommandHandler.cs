using FluentValidation;
using MediatR;

namespace CodeCampRestora.Application.Features.Demo.Commands;

public class CreateDemoCommandHandler : IRequestHandler<CreateDemoCommand>
{
    private readonly IValidator<CreateDemoCommand> _validator;

    public CreateDemoCommandHandler(IValidator<CreateDemoCommand> validator)
    {
        _validator = validator;
    }

    public Task Handle(CreateDemoCommand request, CancellationToken cancellationToken)
    {
        var result = _validator.Validate(request);
        foreach(var item in result.Errors)
        {
            Console.WriteLine(item.ErrorMessage);
        }

        Console.WriteLine("Created");

        return Task.CompletedTask;
    }
}