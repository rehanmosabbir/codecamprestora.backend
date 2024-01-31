using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Application.Common.Interfaces.DbContexts;

public interface IApplicationDbContext : IDisposable, IAsyncDisposable
{
    DbSet<T> DbSet<T>() where T: class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}