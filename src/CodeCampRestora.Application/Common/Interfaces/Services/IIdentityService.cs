using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Identity;

namespace CodeCampRestora.Application.Common.Interfaces.Services;

public interface IIdentityService
{
    Task<IResult> RegisterRestaurantOwnerAsync(RegisterUserDTO registerUserDto, Guid restaurantId);
    Task<IAuthOwnerResult> AuthenticatRestaurantOwnerAsync(LoginDTO loginDto);
    Task<IResult> RegisterMobileUserAsync(RegisterMobileUserDTO registerMobileUserDTO);
    Task<IResult> UpdateRestaurantOwnerAsync(RestaurantOwnerUpdateDTO restaurantOwnerUpdate);
    Task<IAuthResult> AuthenticateMobileUserAsync(MobileUserLoginDto mobileUserLoginDto);
    Task<IAuthResult> RefreshTokenAsync(string accessToken, string refreshToken, CancellationToken cancellationToken);
    Task<IAuthResult> CreateStaff(ApplicationUser user);
}