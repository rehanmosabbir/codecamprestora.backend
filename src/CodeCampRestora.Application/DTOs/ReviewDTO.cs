namespace CodeCampRestora.Application.DTOs;

public class ReviewDTO
{

    public Guid Id { get; set; }
    public string? Description { set; get; }
    public double Rating { set; get; }
    public bool IsReviewHidden { get; set; }


}
