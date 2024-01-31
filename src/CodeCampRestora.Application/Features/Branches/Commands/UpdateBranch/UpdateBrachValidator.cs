
using FluentValidation;
using CodeCampRestora.Application.Common;

namespace CodeCampRestora.Application.Features.Branches.Commands.UpdateBranch;

public class UpdateBrachValidator : ApplicationValidator<UpdateBranchCommand>
{
    public UpdateBrachValidator()
    {
        RuleFor(item => item.Name).NotEmpty().WithMessage("Branch Name can't be empty");
        RuleFor(model => model.Address!.Latitude).LessThanOrEqualTo(90)
                              .GreaterThanOrEqualTo(-90)
                              .WithMessage("Latitude must be between -90 <-> 90 degress.");

        RuleFor(model => model.Address!.Longitude).LessThanOrEqualTo(180)
                                         .GreaterThanOrEqualTo(-180)
                                         .WithMessage("Longitude must be between -180 <-> 180 degress.");
        RuleFor(model => model.PriceRange)
          .IsInEnum()
          .WithMessage("Invalid price range. Please choose a valid value Low = 1, Medium = 2,   High = 3.");
    }
}
