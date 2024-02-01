
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.Branches.Queries.GetAllBranchImageById;

public record GetAllBranchImageQuery(Guid Id): IQuery<IResult<List<string>>>;

