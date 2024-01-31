namespace CodeCampRestora.Application.DTOs;

public class ImageDTO
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string Base64 {get; set;} = default!;
}