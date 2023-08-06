using FluentValidation;
using SiteManangmentAPI.Application.Models;

public class UserRequestValidator : AbstractValidator<UserRequest>
{
    public UserRequestValidator()
    {
        RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required.");
        RuleFor(x => x.UserType).NotEmpty().WithMessage("UserType is required.");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("A valid email address is required.");
        RuleFor(x => x.TCNo).NotEmpty().Length(11).WithMessage("TCNo must be exactly 11 characters.");
        RuleFor(x => x.VehiclePlateNumber).NotEmpty().WithMessage("Vehicle plate number is required.");
        RuleFor(x => x.GeneratedPassword).NotEmpty().WithMessage("Generated password is required.");
    }
}
