using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuItem
{
    public record CreateMenuItemCommand(
        string Name,
        string Description,
        string Ingredients, 
        double? Price,
        bool Availability,
        int DisplayOrder, 
        Guid? CategoryId,
        Guid? BranchId 
    ) : ICommand<IResult<Guid>>;
}