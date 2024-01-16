namespace CodeCampRestora.Application.Dtos;

public class RestaurantDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public Guid ImageId { get; set; } = default!;
}
