using CodeCampRestora.Application.Features.Reviews.Commands.CreateReview;
using CodeCampRestora.Application.Features.Reviews.Commands.IsReviewHidden;
using CodeCampRestora.Application.Features.Reviews.Queries.GetAllReview;
using CodeCampRestora.Application.Features.Reviews.Queries.GetReviewById;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CodeCampRestora.Api.Controllers.V1;

[Route("api/v1/[controller]")]
[ApiController]
public class ReviewController : ApiBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
    {
        var request = new GetAllReviewQuery(pageNumber, pageSize);
        var response = await Sender.Send(request);
        return response.ToActionResult();
    }
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create Reviews",
        Description = @"Sample Request:
            Get: api/v1/Review
            {
            ""BranchId"": ""7C12E100-D081-49F5-94FE-D0D1598945C3"",
            ""OrderId"":""7C12E100-D081-49F5-94FE-D0D1598945C3"",
            ""Rating"":""4"",
            ""Description"":""Someting""
            }"
    )]
    public async Task<IActionResult> CreateReviews([FromBody] CreateReviewCommand reviewCommand)
    {
        var result = await Sender.Send(reviewCommand);
        return result.ToActionResult();
    }
    [HttpGet]
    [Route("{BranchId:Guid}")]
    [SwaggerOperation(
        Summary = "Get a review by BranchID",
        Description = @"Sample Request:
        Get: api/v1/branch/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    public async Task<IActionResult> Get(Guid BranchId, int pageNumber, int pageSize)
    {
        var result = await Sender.Send(new GetReviewByIdQuery(BranchId, pageNumber,pageSize));
        return result.ToActionResult();
    }

    [HttpPatch]
    [SwaggerOperation(
        Summary = "Hide or Show a Review",
        Description = @"Sample Request:
            Patch: api/v1/IsReviewHidden
            {
             ""hideReview"": true
            }"
    )]
    public async Task<IActionResult> IsReviewHiddenUpdate([FromBody] HiddenReviewCommand hiddenReviewCommand)
    {
        var result = await Sender.Send(hiddenReviewCommand);
        return result.ToActionResult();
    }
}
