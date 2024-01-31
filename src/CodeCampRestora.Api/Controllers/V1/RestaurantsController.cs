using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using CodeCampRestora.Application.Features.RestaurantCQ.Commands.UpdateRestaurant;
using CodeCampRestora.Application.Features.RestaurantCQ.Commands.CreateRestaurant;
using CodeCampRestora.Application.Dtos;
using CodeCampRestora.Application.Features.RestaurantCQ.Queries.GetRestaurantById;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Api.Controllers.V1;

public class RestaurantsController : ApiBaseController
{
    // TODO: End point will be removed later
    [HttpPost]
    [SwaggerOperation(
    Summary = "Create a restaurant",
    Description = @"Sample Request:
    Post: api/v1/restaurants
    {
        ""name"": ""Pizza Hut"",
        ""imageId"": ""60C28298-B55A-4497-A3B4-0EB21DF208CB""
    }"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    public async Task<IActionResult> Create([FromBody] CreateRestaurantCommand command)
    {
        var result = await Sender.Send(command);
        return result.ToActionResult();
    }

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
    public async Task<IActionResult> Update([FromBody] UpdateRestaurantCommand command)
    {
        var result = await Sender.Send(command);
        return result.ToActionResult();
    }

    [HttpGet]
    [SwaggerOperation(
    Summary = "Get a Restaurant",
    Description = @"Sample Request:
    Get: api/v1/Restaurants/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Restaurant not found", typeof(IResult))]
    [Route("{id:Guid}")]
    public async Task<IResult<RestaurantDto>> GetById([FromRoute] Guid id)
    {
        var query = new GetRestaurantByIdQuery(id);
        var restaurantModel = await Sender.Send(query);
        return restaurantModel;
    }
}
