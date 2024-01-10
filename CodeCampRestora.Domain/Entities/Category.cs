using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Infrastructure.Entities;

public class Category : AuditableEntity<Guid>
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;

    public Guid RestaurantId { get; set; } = default!;
    public Restaurant? Restaurant { get; set; }
}
