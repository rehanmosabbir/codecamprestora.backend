using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MobileMenuCategories.Queries
{
    public class GetAllHomeMenuCategoryQuery : IQuery<IResult<List<MenuCategoryDto>>>
    {
    }
}
