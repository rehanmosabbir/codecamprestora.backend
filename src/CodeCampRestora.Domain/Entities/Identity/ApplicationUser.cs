using Microsoft.AspNetCore.Identity;
using CodeCampRestora.Domain.Entities;

namespace CodeCampRestora.Domain.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public Guid StaffId { get; set; } = default!;
    public virtual Staff? Staff { get; set; }
    public Guid? RestaurantId { get; set; } = default!;
}