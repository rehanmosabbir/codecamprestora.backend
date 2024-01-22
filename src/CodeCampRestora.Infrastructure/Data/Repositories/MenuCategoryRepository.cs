using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Infrastructure.Data.Repositories;

[ScopedLifetime]
public class MenuCategoryRepository : Repository<MenuCategory, Guid>, IMenuCategoryRepository
{
    private readonly DbSet<MenuCategory> _menuCategory;
    public MenuCategoryRepository(IApplicationDbContext applicationDbContext, ApplicationDbContext context) 
    : base((DbContext)applicationDbContext)
    {
        _menuCategory = context.Set<MenuCategory>();
    }

    public async Task<List<MenuCategory>> GetAllByIdAsync(Guid Id)
    {
        var Entities = _menuCategory.Where(e => e.RestaurantId == Id).ToList();
        return Entities;
    }

    public async Task<List<MenuCategory>> GetAllHomeMenuCategoryAsync()
    {
        return await _menuCategory.ToListAsync();
    }
}