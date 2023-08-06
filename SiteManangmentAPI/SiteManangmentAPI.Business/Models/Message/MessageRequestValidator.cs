using FluentValidation;
using SiteManangmentAPI.Application.Models;

public class MessageRequestValidator : AbstractValidator<MessageRequest>
{
    public MessageRequestValidator()
    {
        RuleFor(x => x.SenderUserID).GreaterThan(0).WithMessage("Sender user ID must be greater than 0.");
        RuleFor(x => x.ReceiverUserID).GreaterThan(0).WithMessage("Receiver user ID must be greater than 0.");
        RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Message content is required.");
    }
}
