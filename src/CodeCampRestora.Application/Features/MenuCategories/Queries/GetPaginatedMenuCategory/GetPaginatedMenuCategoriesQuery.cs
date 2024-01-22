using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuCategories.Queries.GetPaginatedMenuCategory;

public record GetPaginatedMenuCategoriesQuery : IQuery<IResult<PaginationDto<Domain.Entities.MenuCategory>>>{
    public int PageNumber { get; set; }
    public int PageSize { get; set ;}
    public GetPaginatedMenuCategoriesQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}