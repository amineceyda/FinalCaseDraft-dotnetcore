using FluentValidation;
using SiteManangmentAPI.Application.Models;

public class ContactRequestValidator : AbstractValidator<ContactRequest>
{
    public ContactRequestValidator()
    {
        RuleFor(x => x.UserID).GreaterThan(0).WithMessage("User ID must be greater than 0.");
        RuleFor(x => x.ContactName).NotEmpty().WithMessage("Contact name is required.");
        RuleFor(x => x.ContactPhone).NotEmpty().WithMessage("Contact phone number is required.");
        RuleFor(x => x.ContactEmail).NotEmpty().EmailAddress().WithMessage("Invalid contact email.");
    }
}
