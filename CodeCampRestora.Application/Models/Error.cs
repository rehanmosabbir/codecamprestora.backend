namespace CodeCampRestora.Application.Models;

public record Error(string code, string Description)
{
    public static Error NotFound(string description) => new("not_found", description);
    public static Error NotValidated(string code, string description) => new($"{code}_validation_failed", description);
}

public record ImageErrors
{
    public static Error NotFound => new("Image.NotFound", "The image doesn't exist.");
    public static Error Exists => new("Image.Exists", "The image already exist.");
}

public record RestaurantErrors
{
    public static Error NotFound => new("Restaurant.NotFound", "Restaurant not found");
}