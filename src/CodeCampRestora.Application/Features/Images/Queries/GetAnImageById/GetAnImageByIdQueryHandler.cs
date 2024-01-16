using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Application.Features.Images.Queries.GetAnImageById;

public class GetAnImageByIdQueryHandler : IQueryHandler<GetAnImageByIdQuery, IResult<ImageDTO>>
{
    private readonly IImageService _imageService;

    public GetAnImageByIdQueryHandler(IImageService imageService)
    {
        _imageService = imageService;
    }

    public async Task<IResult<ImageDTO>> Handle(GetAnImageByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _imageService.GetImageByIdAsync(request.Id);
        return result;
    }
}