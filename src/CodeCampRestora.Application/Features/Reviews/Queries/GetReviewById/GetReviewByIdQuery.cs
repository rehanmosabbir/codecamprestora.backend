using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.Reviews.Queries.GetReviewById;

public record GetReviewByIdQuery(Guid BranchId,int PageNumber,int PageSize) : IQuery<IResult<List<ReviewDTO>>>;

 