namespace CodeCampRestora.Domain.Entities.Common;

public class AuditableEntity<T>
{
    public T Id { get; set; } = default!;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public string LastModifiedBy { get; set; } = string.Empty;
    public DateTime? LastModified { get; set; }
}