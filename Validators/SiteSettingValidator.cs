using FluentValidation;
using WA_Blog.Models.Entities;

namespace VillaAgency.Validators;

public class SiteSettingValidator : AbstractValidator<SiteSetting>
{
    public SiteSettingValidator()
    {
        RuleFor(x => x.SiteName).NotEmpty();
        RuleFor(x => x.PhoneNumber).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Address).NotEmpty();
    }
}
