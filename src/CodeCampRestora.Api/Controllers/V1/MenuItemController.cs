using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuItem;
using CodeCampRestora.Application.Features.MenuItems.Commands.DeleteMenuItem;
using CodeCampRestora.Application.Features.MenuItems.Commands.PutDisplayOrder;
using CodeCampRestora.Application.Features.MenuItems.Queries;
using CodeCampRestora.Application.Features.MenuItems.Queries.GetAllMenuItems;
using CodeCampRestora.Application.Features.MenuItems.Queries.GetPaginatedMenuItems;
using CodeCampRestora.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CodeCampRestora.Api.Controllers.V1
{
    public class MenuItemController : ApiBaseController
    {
        [HttpPost]
        [SwaggerOperation(summary: "create a menu item")]
        public async Task<Application.Models.IResult> Post([FromBody] CreateMenuItemCommand command)
        {
            var result = await Sender.Send(command);
            return result;
        }

        [HttpGet("{id:Guid}")]
        [SwaggerOperation(
            Summary = "Get a menu item",
            Description = @"Sample Request:
            Get: api/v1/MenuCategory/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
        )]
        public async Task<IResult<MenuItemDto>> GetById(
            [FromRoute, SwaggerParameter(Description = "Get menu item by id", Required = true)]
            Guid id)
        {
            var result = await Sender.Send(new GetMenuItemByIdQuery(id));
            return result;
        }

        [HttpDelete("{id:Guid}")]
        [SwaggerOperation(
            Summary = "Delete a menu item",
            Description = @"Sample Request:
            Get: api/v1/MenuItem/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
        )]
        public async Task<Application.Models.IResult> Delete(
            [FromRoute, SwaggerParameter(Description = "Delete by id", Required = true)]
            Guid id)
        {
            var result = await Sender.Send(new DeleteMenuItemCommand(id));
            return result;
        }

        [HttpGet("GetAll{id:Guid}")]
        [SwaggerOperation(
            Summary = "Get all menu items",
            Description = @"Sample Request:
            Get: api/v1/MenuItem/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
        )]
        public async Task<IResult<List<MenuItemDto>>> GetAll(
            [FromRoute, SwaggerParameter(Description = "Get all menu items by branch id", Required = true)]
            Guid id)
        {
            var result = await Sender.Send(new GetAllMenuItemsQuery(id));
            return result;
        }

        [HttpGet("Paginated")]
        [SwaggerOperation(
            Summary = "Get paginated menu items with branchId",
            Description = @"Sample Request:
            Get: api/v1/MenuItem/Paginated?BranchId=3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c&PageNumber=1&PageSize=10"
        )]
        public async Task<IResult<PaginationDto<MenuItemDto>>> GetPaginated(Guid BranchId, int PageNumber, int PageSize)
        {
            
            var result = await Sender.Send(new GetPaginatedMenuItemsQuery(BranchId, PageNumber, PageSize));
            return result;
        }

        [HttpPut("UpdateDisplayOrder")]
        [SwaggerOperation(
            Summary = "Edit display order",
            Description = @"Sample Request:
            Get: api/v1/MenuItem/UpdateDisplayOrder"
        )]
        public async Task<Application.Models.IResult> Update(List<MenuItemDto> menuItems)
        {
            var result = await Sender.Send(new UpdateMenuItemDisplayOrderCommnad(menuItems));
            return result;
        }
    }
}