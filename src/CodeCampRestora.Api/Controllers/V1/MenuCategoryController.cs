using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using CodeCampRestora.Application.Models;
using IResult =  CodeCampRestora.Application.Models.IResult;
using CodeCampRestora.Application.Features.MenuCategories.Queries;
using CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuCategory;
using CodeCampRestora.Application.Features.MenuCategories.Commands.DeleteMenuCategory;
using CodeCampRestora.Application.Features.MenuCategories.Commands.GetAllMenuCategory;
using CodeCampRestora.Application.Features.MenuCategories.Queries.GetPaginatedMenuCategory;

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
        var result = await Sender.Send(new GetAllMenuCategoryQuery(id));
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

    [HttpGet("Paginated")]
    [SwaggerOperation(
        Summary = "Get paginated menu categories",
        Description = @"Sample Request:
        Get: api/v1/MenuCategory/Paginated?PageNumber=1&PageSize=10"
    )]
    public async Task<IResult<PaginationDto<MenuCategory>>> GetPaginated(int PageNumber, int PageSize)
    {
        
        var result = await Sender.Send(new GetPaginatedMenuCategoriesQuery(PageNumber, PageSize));
        return result;
    }
}