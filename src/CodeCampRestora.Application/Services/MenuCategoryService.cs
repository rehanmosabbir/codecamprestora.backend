using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace CodeCampRestora.Application.Services;
[ScopedLifetime]
public class MenuCategoryService : IMenuCategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    public MenuCategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IResult<Guid>> CreateCategoryAsync(MenuCategory menuCategory)
    {
        await _unitOfWork.MenuCategory.AddAsync(menuCategory);
        await _unitOfWork.SaveChangesAsync();
        return Result<Guid>.Success(menuCategory.Id);
    }

    public async Task<Models.IResult> DeleteCategoryAsync(Guid Id)
    {
        var MenuCategory = await _unitOfWork.MenuCategory.GetByIdAsync(Id);

        if (MenuCategory == null) return Result.Failure(
            StatusCodes.Status404NotFound,
            Error.NotFound("Category not found!"));
            
        await _unitOfWork.MenuCategory.DeleteAsync(Id);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<IResult<List<MenuCategoryDto>>> GetAllHomeMenuCategoryAsync()
    {
        var MenuCategories = await _unitOfWork.MenuCategory.GetAllAsync();
        var MenuCategoriesDto = MenuCategories.Adapt<List<MenuCategoryDto>>();
        return Result<List<MenuCategoryDto>>.Success(MenuCategoriesDto);
    }

    public async Task<IResult<List<MenuCategoryDto>>> GetAllMenuCategoryAsync(Guid Id)
    {
        var MenuCategories = await _unitOfWork.MenuCategory.GetAllByIdAsync(Id);
        var MenuCategoriesDto = MenuCategories.Adapt<List<MenuCategoryDto>>();
        return Result<List<MenuCategoryDto>>.Success(MenuCategoriesDto);
    }

    public async Task<IResult<MenuCategoryDto>> GetMenuCategoryByIdAsync(Guid Id)
    {
        var MenuCategory = await _unitOfWork.MenuCategory.GetByIdAsync(Id);
        if (MenuCategory == null)
        {
            return Result<MenuCategoryDto>.Failure(
                StatusCodes.Status404NotFound,
                Error.NotFound("Menu Category not found"));
        }
        var menuCategoryDto = MenuCategory.Adapt<MenuCategoryDto>();
        return Result<MenuCategoryDto>.Success(menuCategoryDto);
    }
}