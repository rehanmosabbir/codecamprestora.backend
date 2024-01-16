using CodeCampRestora.Domain.Enums;

namespace CodeCampRestora.Domain.Entities.Branches;

public class Branch
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = string.Empty;
    public PriceRange? PriceRange { get; set; }
    public bool IsAvailable { get; set; }
    public Guid RestaurantId { get; set; }
    public Address? Address { get; set; }
    public IList<CuisineType>? CuisineTypes { get; set; }
    public IList<OpeningClosingTime>? OpeningClosingTimes { get; set; }
}