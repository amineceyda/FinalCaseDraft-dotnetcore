using FluentValidation;
using SiteManangmentAPI.Application.Models;

public class PaymentRequestValidator : AbstractValidator<PaymentRequest>
{
    public PaymentRequestValidator()
    {
        RuleFor(x => x.UserID).GreaterThan(0).WithMessage("User ID must be greater than 0.");
        RuleFor(x => x.BillingID).GreaterThan(0).WithMessage("Billing ID must be greater than 0.");
        RuleFor(x => x.PaidAmount).GreaterThan(0).WithMessage("Paid amount must be greater than 0.");
        RuleFor(x => x.PaymentMethod).NotEmpty().WithMessage("Payment method is required.");
    }
}
