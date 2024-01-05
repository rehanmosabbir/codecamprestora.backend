namespace CodeCampRestora.Application.Models;

public record Error(string code, string Description)
{
    public static Error NotFound(string description) => new("NotFound", description);
    public static Error NotValidated(string code, string description) => new($"{code}_validation_failed", description);
}

public record ImageErrors()
{
    public static readonly Error NotFound = new("Image.NotFound", "Image doesn't exist");
}