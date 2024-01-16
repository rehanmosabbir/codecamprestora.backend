using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Repositories;

namespace CodeCampRestora.Infrastructure.Data.Repositories;

[ScopedLifetime]
public class MenuItemRepository : Repository<MenuItem,Guid>, IMenuItemRepository
{
    public MenuItemRepository(IApplicationDbContext applicationDbContext)
        : base((DbContext) applicationDbContext)
    {
    }
}