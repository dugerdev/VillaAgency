using FluentValidation;
using VillaAgency.Models.Entities;

namespace VillaAgency.Validators;

public class PropertyImageValidator : AbstractValidator<PropertyImage>
{
    public PropertyImageValidator()
    {
        RuleFor(x => x.PropertyId).NotEmpty();
        RuleFor(x => x.ImageUrl).NotEmpty()
            .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.RelativeOrAbsolute))
            .WithMessage("ImageUrl must be a valid URL");
        RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0);
    }
}
