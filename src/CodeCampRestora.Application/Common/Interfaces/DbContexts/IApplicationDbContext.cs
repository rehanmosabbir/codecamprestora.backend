namespace CodeCampRestora.Application.Common.Interfaces.DbContexts;

public interface IApplicationDbContext : IDisposable, IAsyncDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}