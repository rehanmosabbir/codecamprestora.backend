using MediatR;

namespace CodeCampRestora.Application.Features.Demo.Commands;

public class CreateDemoCommandHandler : IRequestHandler<CreateDemoCommand>
{
    public Task Handle(CreateDemoCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Created");

        return Task.CompletedTask;
    }
}