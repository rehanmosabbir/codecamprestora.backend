using CodeCampRestora.Application.Common;
using FluentValidation;

namespace CodeCampRestora.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : ApplicationValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(item => item.CustomerName).NotEmpty().WithMessage("Customer Name can't be empty");
            RuleFor(item => item.Phone).NotEmpty().WithMessage("Customer Mobile No. can't be empty").Matches(@"^01\d{9}$")
                .WithMessage("Invalid format for mobile number");
            RuleFor(item => item.Seats).NotEmpty().WithMessage("No. of seat can't be empty");
        }
    }
}
