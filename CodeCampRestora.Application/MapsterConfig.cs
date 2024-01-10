using Mapster;
using CodeCampRestora.Infrastructure.Entities;
using CodeCampRestora.Application.Features.RestaurantCQ.Commands.UpdateRestaurant;

namespace CodeCampRestora.Application;

public static class MapsterConfig
{
    public static void AddMapsterConfig()
    {
        TypeAdapterConfig<UpdateRestaurantCommand, Restaurant>
            .NewConfig()
            .Ignore(x => x.Id);
    }
}
