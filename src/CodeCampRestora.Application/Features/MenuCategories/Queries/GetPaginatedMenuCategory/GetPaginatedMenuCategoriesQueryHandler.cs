using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using MediatR;

namespace CodeCampRestora.Application.Features.MenuCategories.Queries.GetPaginatedMenuCategory
{
    public class GetPaginatedMenuCategoriesQueryHandler : IQueryHandler<GetPaginatedMenuCategoriesQuery, IResult<PaginationDto<Domain.Entities.MenuCategory>>>
    {
        private readonly IMenuCategoryService _menuCategoryService;
        public GetPaginatedMenuCategoriesQueryHandler(IMenuCategoryService menuCategoryService)
        {
            _menuCategoryService = menuCategoryService;
        }
        Task<IResult<PaginationDto<Domain.Entities.MenuCategory>>> IRequestHandler<GetPaginatedMenuCategoriesQuery, IResult<PaginationDto<Domain.Entities.MenuCategory>>>.Handle(GetPaginatedMenuCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = _menuCategoryService.GetPaginatedMenuCategoryAsync(request.PageNumber, request.PageSize);
            return result;
        }
    }
}