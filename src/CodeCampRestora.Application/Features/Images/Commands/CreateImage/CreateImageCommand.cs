using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.Images.Commands.CreateImage;

public record CreateImageCommand : ICommand<IResult<Guid>>
{
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string Base64 { get; set; } = default!;
}