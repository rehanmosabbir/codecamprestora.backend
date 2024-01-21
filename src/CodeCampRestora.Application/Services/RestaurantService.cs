using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Infrastructure.Entities;

namespace CodeCampRestora.Application.Services;

[ScopedLifetime]
public class RestaurantService : IRestaurantService
{
    private readonly IUnitOfWork _unitOfWork;

    public RestaurantService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> CreateRestaurant(Restaurant restaurant)
    {  
        await _unitOfWork.Restaurants.AddAsync(restaurant);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success();
    }
}
