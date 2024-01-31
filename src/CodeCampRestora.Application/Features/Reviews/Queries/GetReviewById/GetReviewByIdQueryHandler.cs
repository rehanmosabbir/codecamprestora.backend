using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using Mapster;

namespace CodeCampRestora.Application.Features.Reviews.Queries.GetReviewById
{
    public class GetReviewByIdQueryHandler : IQueryHandler<GetReviewByIdQuery, IResult<List<ReviewDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetReviewByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult<List<ReviewDTO>>> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _unitOfWork.Reviews.GetReviewsByBranchId(request.BranchId,"ReviewComments", request.PageNumber, request.PageSize);
            var reviewsDto = reviews.Adapt<List<ReviewDTO>>();
            return Result<List<ReviewDTO>>.Success(reviewsDto);
        }
    }
}
