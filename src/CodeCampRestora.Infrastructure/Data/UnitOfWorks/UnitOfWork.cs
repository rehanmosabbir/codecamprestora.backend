﻿using System.ComponentModel.Design;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;

namespace CodeCampRestora.Infrastructure.Data.UnitOfWorks;

[ScopedLifetime]
public class UnitOfWork : IUnitOfWork
{
    public IImageRepository Images { get; }
    public IRestaurantRepository Restaurants { get; }
    public IMenuItemRepository MenuItem { get; }

    public IMenuCategoryRepository MenuCategory { get; }

    private readonly IApplicationDbContext _appplicationDbContext;

    public UnitOfWork(
        IImageRepository images,
        IRestaurantRepository restaurants,
        IMenuItemRepository menuItem,
        IMenuCategoryRepository menuCategory,
        IApplicationDbContext applicationDbContext)
    {
        _appplicationDbContext = applicationDbContext;
        Images = images;
        Restaurants = restaurants;
        MenuItem = menuItem;
        MenuCategory = menuCategory;
    }

    public async Task SaveChangesAsync()
    {
        await _appplicationDbContext.SaveChangesAsync();
    }
}