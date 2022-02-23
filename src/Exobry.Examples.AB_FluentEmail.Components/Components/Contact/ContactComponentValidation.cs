using FluentValidation;

namespace Exobry.Examples.AB_FluentMail.Client.Components.Contact;

public class ContactComponentValidation : AbstractValidator<ContactComponentState>
{
    public ContactComponentValidation()
    {
        RuleFor(e => e.Email)
            .EmailAddress().WithMessage("Not a valid email address!");

        RuleFor(e => e.Message)
            .NotEmpty().WithMessage("Message cannot be empty!");
    }
}
