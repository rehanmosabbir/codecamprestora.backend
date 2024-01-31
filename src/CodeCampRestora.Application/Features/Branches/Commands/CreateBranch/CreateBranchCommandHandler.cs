using Mapster;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities.Branches;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace CodeCampRestora.Application.Features.Branches.Commands.CreateBranch;

public class CreateBranchCommandHandler : ICommandHandler<CreateBranchCommand, IResult<BranchDTO>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBranchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<BranchDTO>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var branch = request.Adapt<Branch>();

            await _unitOfWork.Branches.AddAsync(branch);
            await _unitOfWork.SaveChangesAsync();

            var branchDTO = branch.Adapt<BranchDTO>();
            return Result<BranchDTO>.Success(branchDTO);
        }
        catch(FormatException ex) 
        {
            return Result<BranchDTO>.Failure(
               StatusCodes.Status404NotFound,
               DateTimeErrors.InvalidTimeFormate);
        }

    }
}
