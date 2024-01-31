using Microsoft.AspNetCore.Mvc;
using CodeCampRestora.Application.Features.MobieMenuCategories.Queries;
using Swashbuckle.AspNetCore.Annotations;
using CodeCampRestora.Domain.Enums;


namespace CodeCampRestora.Api.Controllers.V1;

[Route("api/v1")]
public class MobileMenuCategoryController : ApiBaseController
{
    private readonly ILogger<BranchesController> _logger;

    public MobileMenuCategoryController(ILogger<BranchesController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetAllMobileMenuCategorty")]
    [SwaggerOperation(
        Summary = "Get all menu category for a mobile app",
        Description = @"Sample Request:
        GetAll: api/v1/MobileHomeMenuCategory"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Catesgory is not found", typeof(IResult))]
    public async Task<IActionResult> GetAllMobileMenuCategories()
    {
        var result = await Sender.Send(new GetAllMobileMenuCategoryQuery());
        return result.ToActionResult();
    }

    [HttpGet("GetPriceRange/{slug}")]
    [SwaggerOperation(
        Summary = "Get Branch By Price Range",
        Description = @"Sample Request:
        GetAll: api/v1/GetPriceRange"
    )]

    public async Task<IActionResult> GetPriceRange(PriceRange slug)
    {
        var result = await Sender.Send(new GetPricesRangeQuery(slug));
        return result.ToActionResult();
    }
}
