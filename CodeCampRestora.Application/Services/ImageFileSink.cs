using System.Text.Json;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Application.Services;

public class ImageFileSink : IImageSink
{
    private string _directoryPath;

    public ImageFileSink() : this("images/")
    {
    }

    public ImageFileSink(string directoryPath)
    {
        _directoryPath = directoryPath;
        CreateDirectoryIfDoesntExist();
    }

    private void CreateDirectoryIfDoesntExist()
    {
        var directory = new DirectoryInfo(_directoryPath);
        if (!directory.Exists) directory.Create();
    }

    public async Task<IResult> DeleteAsync(Guid id)
    {
        var isFileExist = await IsImageExist(id);
        if(!isFileExist.IsSuccess) return Result<Guid>.Failure(ImageErrors.NotFound);

        var imageResult = await GetAsync(id);
        if(!imageResult.IsSuccess) return Result.Failure(ImageErrors.NotFound);

        imageResult.Data.IsDeleted = true;
        var filePath = GenerateFilePath(id.ToString());
        var fileContent = JsonSerializer.Serialize(imageResult.Data);
        File.WriteAllText(filePath, fileContent);

        return Result.Success();
    }

    public async Task<IResult<Image>> GetAsync(Guid id)
    {
        var filePath = GenerateFilePath(id.ToString());
        var fileContent = await File.ReadAllTextAsync(filePath);
        var image = JsonSerializer.Deserialize<Image>(fileContent);

        if(image is null || image.IsDeleted) return Result<Image>.Failure(ImageErrors.NotFound);

        return Result<Image>.Success(image);
    }

    public Task<IResult<bool>> IsImageExist(Guid id)
    {
        var directory = new DirectoryInfo(_directoryPath);

        var image = directory
            .GetFiles()
            .SingleOrDefault(fileInfo => fileInfo.Name == id.ToString());

        if(image is null) return Task.FromResult<IResult<bool>>(Result<bool>.Failure());

        return Task.FromResult<IResult<bool>>(Result<bool>.Success(true));
    }

    public async Task<IResult<Guid>> UploadAsync(Image image)
    {
        if(image.Id == Guid.Empty) image.Id = Guid.NewGuid();

        var result = await IsImageExist(image.Id);
        if(result.IsSuccess) return Result<Guid>.Failure(ImageErrors.Exists);

        var imageJson = JsonSerializer.Serialize(image);
        var fileName = Guid.NewGuid();
        var filePath = GenerateFilePath(fileName.ToString());
        await File.WriteAllTextAsync(filePath, imageJson);

        return Result<Guid>.Success(fileName);
    }

    private string GenerateFilePath(string fileName)
    {
        return $"{_directoryPath}/{fileName}";
    }
}