﻿using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Domain.Entities.Branches;
using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Infrastructure.Entities;

public class Restaurant : AuditableEntity<Guid>
{
    public string Name { get; set; } = default!;
    public Guid ImageId { get; set; } = default!;
    public int CategoryId { get; set; }
    public ICollection<Category>? Categories { get; set; }
    public IList<Branch>? Branches { get; set; }
}
