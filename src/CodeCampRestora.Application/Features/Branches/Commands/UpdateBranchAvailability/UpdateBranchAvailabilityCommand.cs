

using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Enums;
using System.Windows.Input;

namespace CodeCampRestora.Application.Features.Branches.Commands.UpdateBranchAvailability;

public record UpdateBranchAvailabilityCommand:ICommand<IResult<bool>>
{
    public Guid Id { get; set; }
    public bool IsAvailable { get; set; }
}
