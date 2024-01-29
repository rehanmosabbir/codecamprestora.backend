using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.Reviews.Queries.GetReviewById;
using CodeCampRestora.Application.Models;
using MediatR;

namespace CodeCampRestora.Application.Common.Interfaces.MediatRs;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}

public interface IQueryHandler<TRequest, TResponse>
    : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    Task<IResult<List<ReviewDTO>>> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken);
}