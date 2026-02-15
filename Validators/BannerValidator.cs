using FluentValidation;
using VillaAgency.Models.Entities;

namespace VillaAgency.Validators;

public class BannerValidator : AbstractValidator<Banner>
{
    public BannerValidator()
    {
        RuleFor(x => x.Tittle).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("ImageUrl is required")
            .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.RelativeOrAbsolute))
            .WithMessage("ImageUrl must be a valid URL");
        RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0);
        RuleFor(x => x.LinkedinUrl)
            .Must(u => string.IsNullOrWhiteSpace(u) || Uri.IsWellFormedUriString(u, UriKind.Absolute))
            .WithMessage("LinkedIn URL must be a valid absolute URL when provided");
    }
}
