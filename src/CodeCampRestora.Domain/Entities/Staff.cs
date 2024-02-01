using CodeCampRestora.Domain.Identity;

namespace CodeCampRestora.Domain.Entities;

public class Staff : ApplicationUser
{
    public Guid BranchId { get; set; }
}