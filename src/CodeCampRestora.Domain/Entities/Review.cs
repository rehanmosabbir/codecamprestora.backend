using CodeCampRestora.Domain.Entities.Common;

namespace CodeCampRestora.Domain.Entities
{
    public class Review : AuditableEntity<Guid>
    {
        public  string? Description { set; get; }
        public  double Rating { set; get; }
        public Guid OrderId { set; get; }
        public Guid BranchId { set; get; }
        public bool IsHideReview { get; set; }

    }
}
