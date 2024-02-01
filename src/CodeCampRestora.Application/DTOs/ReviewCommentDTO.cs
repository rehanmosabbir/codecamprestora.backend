namespace CodeCampRestora.Application.DTOs;

public class ReviewCommentDTO
{
    public Guid Id { get; set; }
    public string CommentText { get; set; } = default!;
    public bool IsCommentHidden { get; set; } = false;
}
