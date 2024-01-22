using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.Auths.Commands.RestaurantOwner.Signup;

public record OwnerSignupCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : ICommand<IResult>;