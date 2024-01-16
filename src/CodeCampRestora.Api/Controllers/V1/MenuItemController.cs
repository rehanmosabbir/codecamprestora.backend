using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuItem;
using CodeCampRestora.Application.Features.MenuItems.Commands.DeleteMenuItem;
using CodeCampRestora.Application.Features.MenuItems.Queries;
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
    }
}