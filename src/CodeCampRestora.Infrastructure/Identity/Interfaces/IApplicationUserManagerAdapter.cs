using Microsoft.AspNetCore.Identity;
using CodeCampRestora.Domain.Identity;

namespace CodeCampRestora.Infrastructure.Identity.Interfaces;

public interface IApplicationUserManagerAdapter
{
    Task<ApplicationUser?> FindByEmailAsync(string email);
    Task<ApplicationUser?> FindByIdAsync(string email);
    Task<ApplicationUser?> FindByNameAsync(string userName);
    Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
    Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
    Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role);
    Task<IList<string>> GetRolesAsync(ApplicationUser user);
    Task<IdentityResult> UpdateAsync(ApplicationUser user);
    Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword);
}