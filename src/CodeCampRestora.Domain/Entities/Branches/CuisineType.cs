namespace CodeCampRestora.Domain.Entities.Branches;


public class CuisineType
{
    public Guid Id { get; set; }
    public  string CuisineTag { get; set; }
    public Guid BranchId { get; set; }

}
