using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using CodeCampRestora.Application.Features.Demo.Queries.GetDemo;

namespace CodeCampRestora.Api.Controllers.V1;

[Route("/api/v1/[controller]")]
public class DemoController : ApiBaseController
{
    [HttpGet("GetDemo")]
    [SwaggerOperation(
        Summary = "Get a demo",
        Description = "This is created to undrestand the flow of our api"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The product was created", typeof(string))]
    public async Task<string> Get()
    {
        return await Sender.Send(new GetDemoQuery());
    }

    [HttpPost("CreateDemo")]
    [SwaggerOperation(
        Summary = "Creates a demo",
        Description = "This is created to undrestand the flow of our api"
    )]
    [SwaggerResponse(StatusCodes.Status200OK)]
    public void Create(
        [FromBody, SwaggerRequestBody("demo creation payload", Required = true)]
        string value)
    {
        Console.WriteLine(value);
    }
}