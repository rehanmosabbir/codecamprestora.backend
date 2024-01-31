

using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities.Orders;

namespace CodeCampRestora.Application.Features.Branches.Commands.UpdateBranchAvailability;

public class UpdateBranchAvailabilityCommandHandler : ICommandHandler<UpdateBranchAvailabilityCommand, IResult<bool>>
{
    public readonly IUnitOfWork _unitOfWork;
    public UpdateBranchAvailabilityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IResult<bool>> Handle(UpdateBranchAvailabilityCommand request, CancellationToken cancellationToken)
    {
        var branch = await _unitOfWork.Branches.GetByIdAsync(request.Id);
        var isAvailable = !branch.IsAvailable;
        branch.IsAvailable = isAvailable;
        await _unitOfWork.Branches.UpdateAsync(request.Id,branch);
        await _unitOfWork.SaveChangesAsync();

        return Result<bool>.Success(isAvailable);
    }
}
