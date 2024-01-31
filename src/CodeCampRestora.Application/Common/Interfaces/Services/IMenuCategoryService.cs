using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuCategory;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities;

namespace CodeCampRestora.Application.Common.Interfaces.Services;
public interface IMenuCategoryService
{
    Task<IResult<Guid>> CreateCategoryAsync(CreateMenuCategoryCommand menuCategory);
    Task<IResult<MenuCategoryDto>> GetMenuCategoryByIdAsync(Guid Id);
    Task<IResult<List<MenuCategoryDto>>> GetAllMenuCategoryAsync(Guid Id);
    Task<IResult<List<MenuCategoryDto>>> GetAllHomeMenuCategoryAsync();
    Task<IResult> DeleteCategoryAsync(Guid Id);
    Task<IResult<PaginationDto<MenuCategory>>> GetPaginatedMenuCategoryAsync(int pageNumber, int pageSize);
}