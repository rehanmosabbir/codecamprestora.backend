using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using CodeCampRestora.Application.Features.Auths.Commands.OwnerLogin;
using CodeCampRestora.Application.Features.Auths.Commands.CreateRefreshToken;
using CodeCampRestora.Application.Features.Auths.Commands.RestaurantOwner.Signup;

namespace CodeCampRestora.Api.Controllers.V1;

[Route("api/v1/owners")]
public class OwnerController : ApiBaseController
{
    [HttpPost("register")]
    [SwaggerOperation(
        Summary = "register as a restaurant owner",
        Description = @"Sample Request:
        Post: api/v1/owner/register
        {
            ""firstName"": ""John"",
            ""lastName"": ""Doe"",
            ""email"": ""john@example.com"",
            ""password"": ""Aa123456.""
        }"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Request validation failed", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error occurred", typeof(IResult))]
    public async Task<IResult> Register([FromBody] OwnerSignupCommand command)
    {
        var result = await Sender.Send(command);
        return result;
    }

    [HttpPost("login")]
    [SwaggerOperation(
        Summary = "Login as a restaurant owner",
        Description = @"Sample Request:
        Post: api/v1/owner/login
        {
            ""username"": ""john@example.com"",
            ""passoword"": ""Aa123456.""
        }"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "User doesn't exist", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Wrong user credentials", typeof(IResult))]
    public async Task<IResult> Login([FromBody] OwnerLoginCommand command)
    {
        var result = await Sender.Send(command);
        return result;
    }

    [HttpPost("refresh")]
    [SwaggerOperation(
        Summary = "refresh token",
        Description = @"Sample Request:
        Post: api/v1/owner/login
        {
            ""accessToken"": ""provided token"",
            ""refreshToken"": ""provided refresh token""
        }"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Request validation failed", typeof(IResult))]
    public async Task<IResult> RefreshToken([FromBody] CreateRefreshTokenCommand command)
    {
        var result = await Sender.Send(command);
        return result;
    }
}
