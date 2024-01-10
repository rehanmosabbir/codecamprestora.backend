using Microsoft.AspNetCore.Http;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.Models;
using IResult = CodeCampRestora.Application.Models.IResult;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Common.Interfaces.Repositories;

namespace CodeCampRestora.Application.Services;

public class ImageDbSink : IImageSink
{
    private readonly IUnitOfWork _unitOfWork;

    public ImageDbSink(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<Guid>> UploadAsync(Image image)
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
            Error.NotFound("Image don't exist"));

        return Result<bool>.Success(true);
    }

    public async Task<IResult<Image>> GetAsync(Guid id)
    {
        var imageEO = await _unitOfWork.Images.GetByIdAsync(id);

        if (!IsImageExist(imageEO)) return Result<Image>.Failure(
            StatusCodes.Status404NotFound,
            Error.NotFound("Image not found"));

        return Result<Image>.Success(imageEO!);
    }

    public async Task<IResult> DeleteAsync(Guid id)
    {
        var imageEO = await _unitOfWork.Images.GetByIdAsync(id);

        if(!IsImageExist(imageEO)) return Result.Failure(
            StatusCodes.Status404NotFound,
            Error.NotFound("Image not found"));

        imageEO!.IsDeleted = true;
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}