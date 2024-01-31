using FluentValidation;
using CodeCampRestora.Application.Common;

namespace CodeCampRestora.Application.Features.Branches.Commands.CreateBranch;

public class CreatingBranchValidator : ApplicationValidator<CreateBranchCommand>
{
    public CreatingBranchValidator()
    {
        RuleFor(item => item.Name).NotEmpty().WithMessage("Branch Name can't be empty");
        RuleFor(item => item.Address).NotEmpty().WithMessage("Branch Adreess can't be empty");
    }
}
