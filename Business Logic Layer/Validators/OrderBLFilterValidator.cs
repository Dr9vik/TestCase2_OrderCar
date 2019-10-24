using Business_Logic_Layer.Common.Model.ModelFilter;
using FluentValidation;
using FluentValidation.Results;

namespace Business_Logic_Layer.Validators
{
    public class OrderBLFilterValidator : AbstractValidator<OrderBLFilter>
    {
        public OrderBLFilterValidator()
        {
            RuleFor(x => x).Custom((x, context) => {
                if (x.Start == null)
                    return;
                if (x.End == null)
                    return;
                if (x.Start < x.End)
                    return;
                if (x.Start >= x.End)
                {
                    context.AddFailure(new ValidationFailure(
                        $"x.Start", // property name
                        $"'{x.Start}' is not a valid DateTime."));
                    context.AddFailure(new ValidationFailure(
                        $"x.End", // property name
                        $"'{x.End}' is not a valid DateTime."));
                }
            });
        }
    }
}
