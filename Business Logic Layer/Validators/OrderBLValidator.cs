using Business_Logic_Layer.Common.Model;
using FluentValidation;
using FluentValidation.Results;

namespace Business_Logic_Layer.Validators
{
    public class OrderBLCreateValidator : AbstractValidator<OrderBLCreate>
    {
        public OrderBLCreateValidator()
        {
            RuleFor(x => x).NotNull().Custom((x, context) => {
                if (x.TimeStart >= x.TimeEnd)
                {
                    context.AddFailure(new ValidationFailure(
                        $"x.TimeStart", // property name
                        $"'{x.TimeStart}' is not a valid DateTime."));
                    context.AddFailure(new ValidationFailure(
                        $"x.TimeEnd", // property name
                        $"'{x.TimeEnd}' is not a valid DateTime."));
                }
            });
        }
    }
    public class OrderBLUpdateValidator : AbstractValidator<OrderBLUpdate>
    {
        public OrderBLUpdateValidator()
        {
            RuleFor(x => x).NotNull().Custom((x, context) => {
                if (x.TimeStart >= x.TimeEnd)
                {
                    context.AddFailure(new ValidationFailure(
                        $"x.TimeStart", // property name
                        $"'{x.TimeStart}' is not a valid DateTime."));
                    context.AddFailure(new ValidationFailure(
                        $"x.TimeEnd", // property name
                        $"'{x.TimeEnd}' is not a valid DateTime."));
                }
            });
        }
    }
}
