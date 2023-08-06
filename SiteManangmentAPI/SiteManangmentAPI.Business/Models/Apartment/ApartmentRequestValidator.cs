using FluentValidation;
using SiteManangmentAPI.Application.Models;
using SiteManangmentAPI.Base.Enums;

public class ApartmentRequestValidator : AbstractValidator<ApartmentRequest>
{
    public ApartmentRequestValidator()
    {
        RuleFor(x => x.OwnerUserID).GreaterThan(0).WithMessage("Owner user ID must be greater than 0.");
        RuleFor(x => x.TenantUserID).GreaterThan(0).WithMessage("Tenant user ID must be greater than 0.");
        RuleFor(x => x.Block).NotEmpty().WithMessage("Block is required.");
        RuleFor(x => x.Status).IsInEnum().WithMessage("Invalid apartment status.");
        RuleFor(x => x.Type).IsInEnum().WithMessage("Invalid apartment type.");
        RuleFor(x => x.Floor).GreaterThan(0).WithMessage("Floor must be greater than 0.");
        RuleFor(x => x.ApartmentNumber).NotEmpty().WithMessage("Apartment number is required.");
    }
}
