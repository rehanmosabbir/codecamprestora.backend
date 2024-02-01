using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuItems.Commands.PutDisplayOrder;

public record UpdateMenuItemDisplayOrderCommnad : ICommand<IResult>
{
    public List<MenuItemDisplayOrderDto> MenuItems { get; set; }
    public UpdateMenuItemDisplayOrderCommnad(List<MenuItemDisplayOrderDto> menuItems)
    {
        MenuItems = menuItems;
    }
}
