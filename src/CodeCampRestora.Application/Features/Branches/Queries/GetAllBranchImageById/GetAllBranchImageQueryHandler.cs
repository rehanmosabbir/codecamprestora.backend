
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Application.Features.Branches.Queries.GetAllBranchImageById;

public class GetAllBranchImageQueryHandler : IQueryHandler<GetAllBranchImageQuery, IResult<List<string>>>
{
    public readonly IUnitOfWork _UnitOfWork;
    public readonly IImageService _ImageService;
    public GetAllBranchImageQueryHandler(IUnitOfWork UnitOfWork, IImageService ImageService)
    {
        _UnitOfWork = UnitOfWork;
        _ImageService = ImageService;
    }
    public async Task<IResult<List<string>>> Handle(GetAllBranchImageQuery request, CancellationToken cancellationToken)
    {
        var branchEOs = _UnitOfWork.Branches.IncludeProps(
            branch => branch.Images!)
            .Where(x => x.Id == request.Id).ToList();

        //var imagepathlist = branchEOs
        //    .Select(branchEO => 
        //        branchEO.Images?.Select(image => image.ImagePath));

        var imagepathlist = new List<string>();
        foreach (var item in branchEOs)
        {
            imagepathlist = item.Images?.Select(x => x.ImagePath).ToList()!;
        }

        var imagepath = await _ImageService.GetAllImagesAsync(imagepathlist);
        return imagepath;
    }
}
