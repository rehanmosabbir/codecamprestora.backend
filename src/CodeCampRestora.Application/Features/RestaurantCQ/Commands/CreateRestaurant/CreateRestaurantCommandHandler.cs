using Mapster;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Infrastructure.Entities;


namespace CodeCampRestora.Application.Features.RestaurantCQ.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler : ICommandHandler<CreateRestaurantCommand, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRestaurantCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurantModel = request.Adapt<Restaurant>();
        await _unitOfWork.Restaurants.AddAsync(restaurantModel);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
