using CodeCampRestora.Domain.Entities.Branches;
using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Infrastructure.Entities;

public class Restaurant : AuditableEntity<Guid>
{
    public string Name { get; set; } = default!;
    public Guid ImageId { get; set; } = default!;

    public int CategoryId { get; set; }
    public List<Category>? Categories { get; set; }
    public Guid BranchId { get; set; }
    public List<Branch> Branches { get; set; }
}
