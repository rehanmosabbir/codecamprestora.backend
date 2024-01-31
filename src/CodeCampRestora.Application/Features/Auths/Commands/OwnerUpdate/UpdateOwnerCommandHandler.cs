using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;


namespace CodeCampRestora.Application.Features.Auths.Commands.OwnerUpdate;
public class UpdateOwnerCommandHandler : ICommandHandler<UpdateOwnerCommand, IResult>
{
    private readonly IIdentityService _identityService;
    private readonly ICurrentUserService _currentUserService;

    public UpdateOwnerCommandHandler(IIdentityService identityService, ICurrentUserService currentUserService)
    {
        _identityService = identityService;
        _currentUserService = currentUserService;
    }

    public async Task<IResult> Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
    {
        var newUser = new RestaurantOwnerUpdateDTO
        {
            Id = new Guid(_currentUserService.UserId),
            FullName = request.FullName,
            CurrentPassword = request.CurrentPassword,
            NewPassword = request.NewPassword,
        };
        var result = await _identityService.UpdateRestaurantOwnerAsync(newUser);
        return result;
    }
}
