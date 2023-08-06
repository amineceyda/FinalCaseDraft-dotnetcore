using FluentValidation;
using SiteManangmentAPI.Application.Models;

public class BillingRequestValidator : AbstractValidator<BillingRequest>
{
    public BillingRequestValidator()
    {
        RuleFor(x => x.ApartmentID).GreaterThan(0).WithMessage("Apartment ID must be greater than 0.");
        RuleFor(x => x.BillingDate).NotEmpty().WithMessage("Billing date is required.");
        RuleFor(x => x.BillAmount).GreaterThan(0).WithMessage("Bill amount must be greater than 0.");
        RuleFor(x => x.RentAmount).GreaterThanOrEqualTo(0).WithMessage("Rent amount must be greater than or equal to 0.");
    }
}
