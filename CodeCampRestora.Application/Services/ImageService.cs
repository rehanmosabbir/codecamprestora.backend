using Mapster;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Attributes;
using IResult = CodeCampRestora.Application.Models.IResult;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Application.Services;

[ScopedLifetime]
public class ImageService : IImageService
{
    private readonly IImageSink _imageSink;

    public ImageService(IImageSink imageSink)
    {
        _imageSink = imageSink;
    }

    public async Task<IResult<Guid>> UploadImageAsync(Image image)
    {
        return await _imageSink.UploadAsync(image);
    }

    public async Task<IResult<bool>> IsImageExist(Guid id)
    {
        return await _imageSink.IsImageExist(id);
    }

    public async Task<IResult<ImageDTO>> GetImageByIdAsync(Guid id)
    {
        var result = await _imageSink.GetAsync(id);
        if (!result.IsSuccess) return Result<ImageDTO>.Failure(ImageErrors.NotFound);

        var imageDTO = result.Data.Adapt<ImageDTO>();
        return Result<ImageDTO>.Success(imageDTO);
    }

    public async Task<IResult> DeleteImageByIdAsync(Guid id)
    {
         return await _imageSink.DeleteAsync(id);
    }
}