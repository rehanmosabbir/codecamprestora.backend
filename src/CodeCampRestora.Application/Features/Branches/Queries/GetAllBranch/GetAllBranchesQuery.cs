using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;



namespace CodeCampRestora.Application.Features.Branches.Queries.GetAllBranch;

public record GetAllBranchesQuery(Guid Id) : IQuery<IResult<List<BranchListDTO>>>;



