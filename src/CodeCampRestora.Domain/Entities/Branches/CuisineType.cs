namespace CodeCampRestora.Domain.Entities.Branches;


public class CuisineType 
{
    public CuisineType()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public required string CuisineTag { get; set; }
    public Guid BranchId { get; set; }

}