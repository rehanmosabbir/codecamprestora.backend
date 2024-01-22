using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using Swashbuckle.AspNetCore.Annotations;
using CodeCampRestora.Application.Features.MobileMenuCategories.Queries;

namespace CodeCampRestora.Api.Controllers.V1
{
    public class MobileMenuCategoryController : ApiBaseController
    {
        [HttpGet("GetAllHomeMenu")]
        [SwaggerOperation(
        Summary = "Get all menu Categories",
        Description = @"Sample Request:
        Get: api/v1/MenuCategory/GetAllHome"
        )]
        public async Task<IResult<List<MenuCategoryDto>>> GetAllHomeMenu()
        {
            var result = await Sender.Send(new GetAllHomeMenuCategoryQuery());
            return result;
        }
    }
}
