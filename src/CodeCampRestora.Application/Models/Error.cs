namespace CodeCampRestora.Application.Models;

public record Error(string code, string Description)
{
    public static Error NotFound(string description) => new("not_found", description);
    public static Error NotValidated(string code, string description) => new($"{code}_validation_failed", description);
}

public record AuthErrors
{
    public static Error UserExists => new("User.Exists", "User already exists.");
    public static Error RoleNotFound => new("User.RoleNotFound", "Role doesn't exist.");
    public static Error UserCreationFailed => new("User.CreationFailed", "User creation failed.");
    public static Error LoginError => new("User.LoginError", "Login failed.");
    public static Error ClaimsNotFound => new("User.ClaimsNotFound", "Claims don't exist.");
    public static Error Expired => new("User.Expired", "Token is expired.");
    public static Error UserNotFound => new("User.NotFound", "User not found.");
    public static Error InvalidToken => new("Jwt.InvalidRefreshToken", "Invalid refresh token.");
    public static Error InvalidClaim => new("Jwt.InvalidClaim", "The token contains invalid claims.");
    public static Error TokenMismatch => new("Jwt.TokenMismatch", "The refresh token does not belong to this access token.");
    public static Error TokenIsUsed => new("Jwt.Used", "The refresh token has been used.");
    public static Error TokenGenerationFailed => new("JWT.GenerationFailed", "Something went wrong.");
}

public record RestaurantErrors
{
    public static Error NotFound => new("Restaurant.NotFound", "Restaurant not found");
}