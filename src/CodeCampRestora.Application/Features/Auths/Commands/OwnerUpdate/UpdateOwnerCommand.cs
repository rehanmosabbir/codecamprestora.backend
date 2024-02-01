using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.Auths.Commands.OwnerUpdate;
public record UpdateOwnerCommand(
    string FullName,
    string CurrentPassword,
    string NewPassword
) : ICommand<IResult>;
