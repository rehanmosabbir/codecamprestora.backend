using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.Reviews.Queries.GetReviewById;
using CodeCampRestora.Application.Models;
using MediatR;

namespace CodeCampRestora.Application.Features.MenuCategories.Queries.GetPaginatedMenuCategory
{
    public class GetPaginatedMenuCategoriesQueryHandler : IQueryHandler<GetPaginatedMenuCategoriesQuery, IResult<PaginationDto<MenuCategoryDto>>>
    {
        private readonly IMenuCategoryService _menuCategoryService;
        public GetPaginatedMenuCategoriesQueryHandler(IMenuCategoryService menuCategoryService)
        {
            _menuCategoryService = menuCategoryService;
        }

        public Task<IResult<List<ReviewDTO>>> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<IResult<PaginationDto<MenuCategoryDto>>> IRequestHandler<GetPaginatedMenuCategoriesQuery, IResult<PaginationDto<MenuCategoryDto>>>.Handle(
            GetPaginatedMenuCategoriesQuery request, CancellationToken cancellationToken
        )
        {
            var result = _menuCategoryService.GetPaginatedMenuCategoryAsync(request.RestaurantId, request.PageNumber, request.PageSize);
            return result;
        }
    }
}