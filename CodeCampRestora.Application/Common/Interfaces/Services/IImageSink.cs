using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Common.Interfaces.Services;

public interface IImageSink
{
    Task<IResult<Guid>> UploadAsync(Image image);
    Task<IResult<Image>> GetAsync(Guid id);
    Task<IResult> DeleteAsync(Guid id);
    Task<IResult<bool>> IsImageExist(Guid id);
}