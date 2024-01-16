using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using IResult = CodeCampRestora.Application.Models.IResult;
using CodeCampRestora.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace CodeCampRestora.Application.Services;
[ScopedLifetime]
public class MenuItemService : IMenuItemService
{
    private readonly IUnitOfWork _unitOfWork;
    public MenuItemService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IResult<Guid>> CreateItemAsync(MenuItem menuItem)
    {
        await _unitOfWork.MenuItem.AddAsync(menuItem);
        await _unitOfWork.SaveChangesAsync();
        return Result<Guid>.Success(menuItem.Id);
    }

    public async Task<IResult> DeleteItemAsync(Guid Id)
    {
        var MenuItem = await _unitOfWork.MenuCategory.GetByIdAsync(Id);
        if(MenuItem is null) return Result.Failure(
            StatusCodes.Status404NotFound,
            Error.NotFound("Item not found!"));
        await _unitOfWork.MenuItem.DeleteAsync(Id);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success(200);
    }

    public async Task<IResult<MenuItemDto>> GetMenuItemByIdAsync(Guid Id)
    {
        var MenuItem = await _unitOfWork.MenuItem.GetByIdAsync(Id);
        if (MenuItem == null)
        {
            return Result<MenuItemDto>.Failure(
                StatusCodes.Status404NotFound,
                Error.NotFound("Item not found"));
        }
        var menuItemDto = MenuItem.Adapt<MenuItemDto>();
        return Result<MenuItemDto>.Success(menuItemDto);
    }
}