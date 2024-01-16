using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Domain.Entities.Branches;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Repositories;


namespace CodeCampRestora.Infrastructure.Data.Repositories;

[ScopedLifetime]
public class BranchRepository : Repository<Branch, Guid>, IBranchRepository
{
    public BranchRepository(IApplicationDbContext applicationDbContext)
        : base((DbContext)applicationDbContext)
    {
        
    }
    
}
