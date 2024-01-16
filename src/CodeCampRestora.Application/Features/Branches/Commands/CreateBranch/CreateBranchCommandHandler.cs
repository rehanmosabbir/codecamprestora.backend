using MediatR;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Domain.Entities.Branches;
using System.Globalization;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Models;
using Mapster;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Application.Features.Branches.Commands.CreateBranch;

public class  CreateBranchCommandHandler : ICommandHandler<CreateBranchCommand, IResult<BranchDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeService _dateTimeService;
    public CreateBranchCommandHandler(IUnitOfWork unitOfWork,IDateTimeService dateTimeService)
    {
        _unitOfWork = unitOfWork;
        _dateTimeService = dateTimeService;
            
    }

    public async Task<IResult<BranchDTO>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = request.Adapt<Branch>();

        await _unitOfWork.Branches.AddAsync(branch);
        await _unitOfWork.SaveChangesAsync();

        var branchDTO = branch.Adapt<BranchDTO>();
      return Result<BranchDTO>.Success(branchDTO);

    }

   
}
