using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Application.Features.Auths.Commands.UserLogin;
using CodeCampRestora.Application.Features.Auths.Commands.UserSignup;
using CodeCampRestora.Application.Features.Auths.Commands.CreateRefreshToken;

namespace CodeCampRestora.Api.Controllers.V1;

[Route("api/v1/users")]
public class UserController : ApiBaseController
{
    [HttpPost("register")]
    public async Task<IResult> Register([FromBody] UserSignupCommand command)
    {
        var result = await Sender.Send(command);
        return result;
    }

    [HttpPost("login")]
    public async Task<IResult> Login([FromBody] UserLoginCommand command)
    {
        var result = await Sender.Send(command);
        return result;
    }

    [HttpPost("refresh")]
    public async Task<IResult> RefreshToken([FromBody] CreateRefreshTokenCommand command)
    {
        var result = await Sender.Send(command);
        return result;
    }
}
