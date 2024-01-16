using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.RestaurantCQ.Commands.DeleteRestaurant;

public record DeleteRestaurantCommand(Guid Id) : ICommand<IResult>;

