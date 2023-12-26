using MediatR;

namespace CodeCampRestora.Application.Features.Demo.Commands;

public record CreateDemoCommand(Guid Id, string Name, string Address) : IRequest;