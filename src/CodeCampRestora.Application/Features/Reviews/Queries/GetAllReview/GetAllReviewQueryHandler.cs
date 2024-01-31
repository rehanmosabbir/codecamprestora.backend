using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Features.Reviews.Queries.GetReviewById;
using CodeCampRestora.Application.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace CodeCampRestora.Application.Features.Reviews.Queries.GetAllReview;

public class GetAllReviewQueryHandler : IQueryHandler<GetAllReviewQuery, IResult<List<ReviewDTO>>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllReviewQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<List<ReviewDTO>>> Handle(GetAllReviewQuery request, CancellationToken cancellationToken)
    {
        var reviews = await _unitOfWork.Reviews.Get("ReviewComments", request.PageNumber, request.PageSize);

        var reviewDTOs = reviews.Select(review => new ReviewDTO
        {
            Description = review.Description,
            IsReviewHidden = review.IsReviewHidden,
            Rating = review.Rating,
            ReviewComments = review.ReviewComments
                .Select(comment => 
                    new ReviewCommentDTO { CommentText = comment.CommentText })
                .ToList()
        }).ToList();

        //var reviewDTOs = reviews.Select(review => review.Adapt<ReviewDTO>()).ToList();
        return Result<List<ReviewDTO>>.Success(reviewDTOs);
    }
}
