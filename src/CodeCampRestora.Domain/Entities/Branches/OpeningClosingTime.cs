 
 
namespace CodeCampRestora.Domain.Entities.Branches;
 
public class OpeningClosingTime
{
    public Guid Id { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly Opening { get; set; }
    public TimeOnly Closing { get; set; }
    public bool IsClosed { get; set; }
    public Guid BranchId { get; set; }
    
}
