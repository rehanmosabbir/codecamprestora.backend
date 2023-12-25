using MediatR;

namespace CodeCampRestora.Application.Features.Demo.Queries.GetDemo;

public class GetDemoQueryHandler : IRequestHandler<GetDemoQuery, string>
{
    public Task<string> Handle(GetDemoQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Ok");
    }
}