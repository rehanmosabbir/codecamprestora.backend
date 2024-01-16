using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Common.Interfaces.Services;

public interface IImageService
{
    Task<IResult<Guid>> UploadImageAsync(Image image);
    Task<IResult<ImageDTO>> GetImageByIdAsync(Guid id);
    Task<IResult> DeleteImageByIdAsync(Guid id);
    Task<IResult<bool>> IsImageExist(Guid id);
}