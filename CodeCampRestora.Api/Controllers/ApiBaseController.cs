using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeCampRestora.Api.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ApiBaseController : ControllerBase
{
    private ISender? _sender;
    protected ISender Sender => _sender ??= HttpContext.RequestServices.GetService<ISender>()!;
}