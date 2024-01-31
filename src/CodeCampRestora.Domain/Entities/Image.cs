namespace CodeCampRestora.Domain.Entities;

public class Image
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string Base64 {get; set;} = default!;
    public bool IsDeleted { get; set; }
}