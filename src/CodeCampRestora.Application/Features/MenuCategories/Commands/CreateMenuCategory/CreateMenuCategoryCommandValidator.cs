using CodeCampRestora.Application.Common;
using CodeCampRestora.Application.Features.MenuItems.Commands.CreateMenuCategory;
using FluentValidation;


namespace CodeCampRestora.Application.Features.MenuCategories.Commands.CreateMenuCategory
{
    public class CreateMenuCategoryCommandValidator : ApplicationValidator<CreateMenuCategoryCommand>
    {
        public CreateMenuCategoryCommandValidator()
        {
            RuleFor(item => item.RestaurantId).NotNull().WithMessage("RestaurantId can not be null!");
        }
    }
}