using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Application.Common.Helpers.Pagination;

public class PagedList<T> : List<T>
{
    public PagedList(IEnumerable<T> items, int totalCount, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        PageSize = pageSize;
        TotalCount = totalCount;
        AddRange(items);
    }

    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public static async Task<PagedList<T>> ToPagedListAsync(IQueryable<T> data, int pageNumber, int pageSize)
    {
        var totalCount = await data.CountAsync();
        var items = await data.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedList<T>(items, totalCount, pageNumber, pageSize);
    }
}
