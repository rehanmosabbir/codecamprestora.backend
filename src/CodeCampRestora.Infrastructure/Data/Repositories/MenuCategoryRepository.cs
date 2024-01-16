using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Infrastructure.Data.Repositories;

[ScopedLifetime]
public class MenuCategoryRepository : Repository<MenuCategory, Guid>, IMenuCategoryRepository
{
    public MenuCategoryRepository(IApplicationDbContext applicationDbContext) 
    : base((DbContext)applicationDbContext)
    { 
    }
}
