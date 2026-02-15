using FluentValidation;
using VillaAgency.Models.Entities;

namespace VillaAgency.Validators;

public class PropertyValidator : AbstractValidator<Property>
{
    public PropertyValidator()
    {
        RuleFor(x => x.Tittle).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.Price).GreaterThanOrEqualTo(0).WithMessage("Price must be non-negative");
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.City).NotEmpty();
        RuleFor(x => x.State).NotEmpty();
        RuleFor(x => x.ZipCode).NotEmpty();
        RuleFor(x => x.Bathrooms).GreaterThanOrEqualTo(0);
        RuleFor(x => x.BedRooms).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Area).GreaterThanOrEqualTo(0);
        RuleFor(x => x.PropertyTypeId).NotEmpty().WithMessage("PropertyType is required");
    }
}
