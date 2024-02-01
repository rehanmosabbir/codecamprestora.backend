using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Repositories;

namespace CodeCampRestora.Infrastructure.Data.Repositories;

[ScopedLifetime]
public class StaffRepository : Repository<Staff, Guid>, IStaffRepository
{
    public StaffRepository(IApplicationDbContext dbContext) : base((DbContext)dbContext)
    {
    }
}