using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Application.Features.MobieMenuCategories.Queries;
public class GetPricesRangeQueryHandler : IQueryHandler<GetPricesRangeQuery, IResult<List<BranchListDTO>>>
{
    private readonly IUnitOfWork _uniOfWork;
    public GetPricesRangeQueryHandler(IUnitOfWork unitOfWork)
    {
        _uniOfWork = unitOfWork;
    }

    public async Task<IResult<List<BranchListDTO>>> Handle(GetPricesRangeQuery request, CancellationToken cancellationToken)
    {
        var branches = _uniOfWork
               .Branches
               .GetByFilter(branch => branch.PriceRange == request.PriceRange);

        var branchesDTO = branches.Select(branch => branch.Adapt<BranchListDTO>()).ToList();

        return Result<List<BranchListDTO>>.Success(branchesDTO);
    }
}

