using CodeCampRestora.Application.Common.Helpers.Pagination;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Application.Features.Branches.Queries.GetAllBranch;

public class GetAllBranchQueryHandeller : IQueryHandler<GetAllBranchesQuery, IResult<List<BranchListDTO>>>
{
    private readonly IUnitOfWork _uniOfWork;
    public GetAllBranchQueryHandeller(IUnitOfWork uniOfWork)
    {
        _uniOfWork = uniOfWork;
    }

    public async Task<IResult<List<BranchListDTO>>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
    {

        var restaurant = await _uniOfWork
            .Restaurants
            .IncludeProps(resturant => resturant.Branches)
            .SingleOrDefaultAsync(restaurant => restaurant.Id == request.Id);

        if (restaurant is null)
        {
            return Result<List<BranchListDTO>>.Failure(
                StatusCodes.Status404NotFound,
                BranchErrors.NotFound);
        }

        var branchListDtos = restaurant.Branches.Select(branch =>
            branch.Adapt<BranchListDTO>()).ToList();

        return Result<List<BranchListDTO>>.Success(branchListDtos);
    }
}
