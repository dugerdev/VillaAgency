using FluentValidation;
using VillaAgency.Models.Entities;

namespace VillaAgency.Validators;

public class ContactValidator : AbstractValidator<Contact>
{
    public ContactValidator()
    {
        RuleFor(x => x.FullName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Subject).NotEmpty();
        RuleFor(x => x.Message).NotEmpty();
    }
}
