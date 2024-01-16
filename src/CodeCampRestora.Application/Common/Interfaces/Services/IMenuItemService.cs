using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities;

namespace CodeCampRestora.Application.Common.Interfaces.Services
{
    public interface IMenuItemService
    {
        Task<IResult<Guid>> CreateItemAsync(MenuItem menuItem);
        Task<IResult<MenuItemDto>> GetMenuItemByIdAsync(Guid Id);
        Task<IResult> DeleteItemAsync(Guid Id);
    }
}