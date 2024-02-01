
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.Branches.Commands.UploadBranchImage;

public record UploadBranchImageCommand:ICommand<IResult>
{
    public Guid Id { get; set; }
    public List<ImageDTO> Images { get; set; }
}
