using CodeCampRestora.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeCampRestora.Api.Controllers.V1;


public class CurrentUserController : ApiBaseController
{
    private readonly ICurrentUserService _currentUserService;

    public CurrentUserController(ICurrentUserService currentUserServices)
    {
        _currentUserService = currentUserServices;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}