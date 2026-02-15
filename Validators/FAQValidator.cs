using FluentValidation;
using VillaAgency.Models.Entities;

namespace VillaAgency.Validators;

public class FAQValidator : AbstractValidator<FAQ>
{
    public FAQValidator()
    {
        RuleFor(x => x.Question).NotEmpty();
        RuleFor(x => x.Answer).NotEmpty();
        RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0);
    }
}
