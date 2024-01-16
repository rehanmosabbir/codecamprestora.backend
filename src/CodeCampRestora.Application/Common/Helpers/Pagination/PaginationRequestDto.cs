namespace CodeCampRestora.Application.Common.Helpers.Pagination;

public class PaginationRequestDto
{
    public PaginationRequestDto(int pageNumber, int pageSize, int totalItems, int totalPages)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
