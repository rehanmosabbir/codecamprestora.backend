using CodeCampRestora.Application.Features.Demo.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeCampRestora.Api.Controllers;

public class ValidationController : ApiBaseController
{
    [HttpPost]
    public void Post(Guid id, string name, string address)
    {
       Sender.Send(new CreateDemoCommand(id, name, address));
    }
}