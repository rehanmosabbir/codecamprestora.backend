using CodeCampRestora.Domain.Entities;

namespace CodeCampRestora.Application.Common.Interfaces.Repositories;

public interface IMenuItemRepository : IRepository<MenuItem, Guid>
{
    Task<List<MenuItem>> GetAllByIdAsync(Guid Id);
}