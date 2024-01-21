using CodeCampRestora.Application.Models;
using CodeCampRestora.Infrastructure.Entities;

namespace CodeCampRestora.Application.Common.Interfaces.Services;

public interface IRestaurantService
{
    Task<IResult> CreateRestaurant(Restaurant restaurant);
}
