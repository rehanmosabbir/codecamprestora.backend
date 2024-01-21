using CodeCampRestora.Domain.Entities.Common;
using CodeCampRestora.Domain.Entities.Branches;

namespace CodeCampRestora.Infrastructure.Entities;

public class Restaurant : AuditableEntity<Guid>
{
    public string Name { get; set; } = default!;
    public string ImagePath { get; set; } = default!;
    public ICollection<Category>? Categories { get; set; }
    public ICollection<Branch>? Branches { get; set; }
}
