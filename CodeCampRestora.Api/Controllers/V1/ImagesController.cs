using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using IResult = CodeCampRestora.Application.Models.IResult;
using CodeCampRestora.Application.Features.Images.Commands.DeleteImage;
using CodeCampRestora.Application.Features.Images.Commands.CreateImage;
using CodeCampRestora.Application.Features.Images.Queries.GetAnImageById;

namespace CodeCampRestora.Api.Controllers.V1;

public class ImagesController : ApiBaseController
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Upload an image",
        Description = @"Sample Request:
        Post: api/v1/images
        {
            ""name"": ""Picture.jpg"",
            ""type"": ""jpg"",
            ""base64"": ""2fRsKyhC+ImrSG4ghXZbWg==""
        }"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    public async Task<IResult> Post(
        [FromBody, SwaggerRequestBody(Required = true, Description = "image payload")]
        CreateImageCommand command)
    {
        var result = await Sender.Send(command);
        return result;
    }

    [HttpGet("{id:Guid}")]
    [SwaggerOperation(
        Summary = "Get an image",
        Description = @"Sample Request:
        Get: api/v1/images/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Image not found", typeof(IResult))]
    public async Task<IResult> Get(
        [FromRoute, SwaggerParameter(Description = "Get image by id", Required = true)]
        Guid id)
    {
        var result = await Sender.Send(new GetAnImageByIdQuery(id));
        return result;
    }

    [HttpDelete("{id:Guid}")]
    [SwaggerOperation(
        Summary = "Delete an image",
        Description = @"Sample Request:
        Get: api/v1/images/3d8cd15b-6414-4bbc-92f7-5d6e9d3e5c9c"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Request Success", typeof(IResult))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Image not found", typeof(IResult))]
    public async Task<IResult> Delete(
        [FromRoute, SwaggerParameter(Description = "Delete by id", Required = true)]
        Guid id)
    {
        var result = await Sender.Send(new DeleteImageCommand(id));
        return result;
    }
}