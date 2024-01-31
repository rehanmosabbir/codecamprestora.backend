using Mapster;
using Microsoft.AspNetCore.Http;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Attributes;
using IResult = CodeCampRestora.Application.Models.IResult;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Common.Interfaces.Repositories;

namespace CodeCampRestora.Application.Services;

[ScopedLifetime]
public class ImageService : IImageService
{
    private readonly IUnitOfWork _unitOfWork;

    public ImageService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<Guid>> UploadImageAsync(Image image)
    {
        await _unitOfWork.Images.AddAsync(image);
        await _unitOfWork.SaveChangesAsync();

        return Result<Guid>.Success(image.Id);
    }

    private bool IsImageExist(Image? image) => image is not null && !image.IsDeleted;

    public async Task<IResult<bool>> IsImageExist(Guid id)
    {
        var doesExist = await _unitOfWork.Images
            .DoesExist(image => image.Id == id && !image.IsDeleted);

        if(!doesExist) return Result<bool>.Failure(
            StatusCodes.Status404NotFound,
            ImageErrors.NotFound);

        return Result<bool>.Success(true);
    }

    public async Task<IResult<ImageDTO>> GetImageByIdAsync(Guid id)
    {
        var imageEO = await _unitOfWork.Images.GetByIdAsync(id);

        if (!IsImageExist(imageEO)) return Result<ImageDTO>.Failure(
            StatusCodes.Status404NotFound,
            ImageErrors.NotFound);

        var imageDTO = imageEO.Adapt<ImageDTO>();

        return Result<ImageDTO>.Success(imageDTO);
    }

    public async Task<IResult> DeleteImageByIdAsync(Guid id)
    {
        var imageEO = await _unitOfWork.Images.GetByIdAsync(id);

        if(!IsImageExist(imageEO)) return Result.Failure(
            StatusCodes.Status404NotFound,
            ImageErrors.NotFound);

        imageEO!.IsDeleted = true;
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}