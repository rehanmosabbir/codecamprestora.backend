using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using IResult = CodeCampRestora.Application.Models.IResult;
using CodeCampRestora.Application.Features.RestaurantCQ.Commands.UpdateRestaurant;
namespace CodeCampRestora.Api.Controllers.V1;

public class RestaurantsController : ApiBaseController
{
    [HttpPut]
    [SwaggerOperation(
    Summary = "Update a Restaurant",
    Description = @"Sample Request:
    Post: api/v1/restaurants
        {
            ""Id"": ""7C12E100-D081-49F5-94FE-D0D1598945C3"",
            ""name"": ""Cafe Reo"",
            ""imageId"": ""60C28298-B55A-4497-A3B4-0EB21DF208CB""
        }"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Image not found", typeof(IResult))]
    public async Task<IResult> Update([FromBody] UpdateRestaurantCommand command)
    {
        var result = await Sender.Send(command);
        return result;
    }


}

