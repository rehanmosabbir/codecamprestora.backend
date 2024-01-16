using Mapster;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Application.Features.Images.Commands.CreateImage;

public class CreateImageCommandHandler : ICommandHandler<CreateImageCommand, IResult<Guid>>
{
    private readonly IImageService _imageService;

    public CreateImageCommandHandler(IImageService imageService)
    {
        _imageService = imageService;
    }

    public async Task<IResult<Guid>> Handle(CreateImageCommand request, CancellationToken cancellationToken)
    {
        var imageEO = request.Adapt<Image>();

        var result = await _imageService.UploadImageAsync(imageEO);
        return result;
    }
}