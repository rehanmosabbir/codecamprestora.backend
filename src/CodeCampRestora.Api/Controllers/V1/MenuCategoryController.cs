using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.MenuCategories.Commands.DeleteMenuCategory;
using CodeCampRestora.Application.Features.MenuCategories.Queries;
using CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuCategory;
using IResult =  CodeCampRestora.Application.Models.IResult;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Features.MenuCategories.Commands.GetAllMenuCategory;
using CodeCampRestora.Application.Features.MenuCategories.Queries.GetAllHomeMenuCategory;

namespace CodeCampRestora.Api.Controllers.V1;

public class MenuCategoryController : ApiBaseController
{
    [HttpPost]
    [SwaggerOperation(summary: "Create a menu category")]
    public async Task<IResult> Post([FromBody] CreateMenuCategoryCommand command)
    {
        var result = await Sender.Send(command);
        return result;
    }

    [HttpGet("{id:Guid}")]
    [SwaggerOperation(
        Summary = "Get a menu Category",
        Description = @"Sample Request:
        Get: api/v1/MenuCategory/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    public async Task<IResult<MenuCategoryDto>> Get(
        [FromRoute, SwaggerParameter(Description = "Get menu category by id", Required = true)]
        Guid id)
    {
        var result = await Sender.Send(new GetMenuCategoryByIdQuery(id));
        return result;
    }

    [HttpGet("GetAll{id:Guid}")]
    [SwaggerOperation(
        Summary = "Get all menu Categories",
        Description = @"Sample Request:
        Get: api/v1/MenuCategory/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    public async Task<IResult<List<MenuCategoryDto>>> GetAll(
        [FromRoute, SwaggerParameter(Description = "Get all menu categories by restaurant id", Required = true)]
        Guid id)
    {
        var result = await Sender.Send(new GetAllHomeMenuCategory(id));
        return result;
    }

    [HttpGet("GetAllHomeMenu")]
    [SwaggerOperation(
        Summary = "Get all menu Categories",
        Description = @"Sample Request:
        Get: api/v1/MenuCategory/GetAllHome"
    )]

    public async Task<IResult<List<MenuCategoryDto>>> GetAllHomeMenu()
    {
        var result = await Sender.Send(new GetAllHomeMenuCategoryQuery());
        return result;
    }

    [HttpDelete("{id:Guid}")]
    [SwaggerOperation(
        Summary = "Delete a menu category",
        Description = @"Sample Request:
        Get: api/v1/MenuCategory/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    public async Task<IResult> Delete(
        [FromRoute, SwaggerParameter(Description = "Delete by id", Required = true)]
        Guid id)
    {
        var result = await Sender.Send(new DeleteMenuCategoryCommand(id));
        return result;
    }
}