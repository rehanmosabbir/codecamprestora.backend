using Mapster;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.Common.Interfaces.Services;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;

namespace CodeCampRestora.Application.Features.ReviewComments;

public class CreateReviewCommentCommandHandler : ICommandHandler<CreateReviewCommentCommand, IResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public CreateReviewCommentCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }
    public async Task<IResult> Handle(CreateReviewCommentCommand request, CancellationToken cancellationToken)
    {       
        var comment = request.Adapt<ReviewComment>();
        var userId = new Guid(_currentUserService.UserId);
        comment.UserId = userId;
        await _unitOfWork.Comments.AddAsync(comment);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
