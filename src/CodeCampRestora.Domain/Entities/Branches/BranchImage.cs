

using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Domain.Entities.Branches;

public class BranchImage:AuditableEntity<Guid>
{
    public string? ImagePath { get; set; }
    public int DisplayOrder { get; set; }
    public Guid BranchId { get; set; }

}
