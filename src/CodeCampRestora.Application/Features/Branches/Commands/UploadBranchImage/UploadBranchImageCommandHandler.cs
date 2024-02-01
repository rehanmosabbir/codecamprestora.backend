using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities.Branches;
using Microsoft.EntityFrameworkCore;


namespace CodeCampRestora.Application.Features.Branches.Commands.UploadBranchImage;

public class UploadBranchImageCommandHandler : ICommandHandler<UploadBranchImageCommand, IResult>
{
    public readonly IUnitOfWork _unitOfWork;
    public readonly IImageService _imageService;
    public UploadBranchImageCommandHandler(IUnitOfWork unitOfWork, IImageService imageService)
    {
        _unitOfWork = unitOfWork;
        _imageService = imageService;
        
    }
    public async Task<IResult> Handle(UploadBranchImageCommand request, CancellationToken cancellationToken)
    {
        var result = await _imageService.UploadMultipleImagesAsync(request.Images);

        // var branchEOs = await _unitOfWork.Branches.IncludeProps(branch => branch.Images,branch => branch.OpeningClosingTimes,branch => branch.CuisineTypes,branch => branch.Address).ToListAsync();

        var branches = await _unitOfWork.Branches.IncludeProps(branch => branch.Images).ToListAsync();
        foreach (var branch in branches)
        {
            if(branch.Id == request.Id)
            {
                if (result.IsSuccess)
                {

                    var imagePaths = result.Data;
                    foreach (var imagePath in imagePaths)
                    {
                        var branchImageList = new List<BranchImage>();
                        branchImageList.Add(new BranchImage() {BranchId = branch.Id, ImagePath = imagePath });

                        branch.Images = branchImageList;

                    }
                }

                await _unitOfWork.Branches.UpdateAsync(branch.Id, branch);
                await _unitOfWork.SaveChangesAsync();
                
            }
        }
        return Result.Success(200);

    }
}
