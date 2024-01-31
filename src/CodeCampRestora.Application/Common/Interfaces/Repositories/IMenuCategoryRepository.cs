using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CodeCampRestora.Application.Common.Interfaces.Repositories
{
    public interface IMenuCategoryRepository : IRepository<MenuCategory, Guid>
    {
        Task<List<MenuCategory>> GetAllByIdAsync(Guid Id);
        Task<List<MenuCategory>> GetAllHomeMenuCategoryAsync();
    }
}