﻿using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Domain.Entities
{
    public class Review : AuditableEntity<Guid>
    {
        public Guid ReviewId { get; set; }
        public required string Description { set; get; }
        public required int Rating { set; get; }
        public Guid OrderId { set; get; }

        public Guid BranchId { set; get; }
        public bool HideReview { get; set; }

    }
}
