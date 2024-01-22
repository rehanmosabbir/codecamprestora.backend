using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;

namespace CodeCampRestora.Application.Features.RestaurantCQ.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler : ICommandHandler<DeleteRestaurantCommand, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRestaurantCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IResult> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Restaurants.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}
