using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.Reviews.Queries.GetReviewById;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuItems.Queries
{
    public class GetMenuItemByIdQueryHandler : IQueryHandler<GetMenuItemByIdQuery, IResult<MenuItemDto>>
    {
        private readonly IMenuItemService _menuItemService;
        public GetMenuItemByIdQueryHandler(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }
        public async Task<IResult<MenuItemDto>> Handle(GetMenuItemByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _menuItemService.GetMenuItemByIdAsync(request.Id);
            return result;
        }

        public Task<IResult<List<ReviewDTO>>> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}