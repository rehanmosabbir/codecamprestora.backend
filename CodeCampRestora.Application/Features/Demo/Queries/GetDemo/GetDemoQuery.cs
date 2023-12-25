using MediatR;

namespace CodeCampRestora.Application.Features.Demo.Queries.GetDemo;

public record GetDemoQuery : IRequest<string>;