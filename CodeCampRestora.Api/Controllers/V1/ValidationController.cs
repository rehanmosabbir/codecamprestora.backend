using CodeCampRestora.Application.Features.Demo.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeCampRestora.Api.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ValidationController
{
    private readonly ISender _sender;

    public ValidationController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public void Post(Guid id, string name, string address)
    {
       _sender.Send(new CreateDemoCommand(id, name, address));
    }
}