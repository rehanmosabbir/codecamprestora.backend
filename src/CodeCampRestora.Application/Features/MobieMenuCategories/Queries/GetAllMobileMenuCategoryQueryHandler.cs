using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.Reviews.Queries.GetReviewById;
using CodeCampRestora.Application.Models;


namespace CodeCampRestora.Application.Features.MobieMenuCategories.Queries
{
    public class GetAllMobileMenuCategoryQueryHandler : IQueryHandler<GetAllMobileMenuCategoryQuery, IResult<List<MenuCategoryDto>>>
    {
        private readonly IMenuCategoryService _menuCategoryService;

        public GetAllMobileMenuCategoryQueryHandler(IMenuCategoryService menuCategoryService)
        {
            _menuCategoryService = menuCategoryService;
        }
        public Task<IResult<List<MenuCategoryDto>>> Handle(GetAllMobileMenuCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = _menuCategoryService.GetAllMobileMenuCategoryAsync();
            return result;
        }

        public Task<IResult<List<ReviewDTO>>> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
