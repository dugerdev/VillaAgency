using FluentValidation;
using VillaAgency.Models.Entities;

namespace VillaAgency.Validators;

public class PropertyTypeValidator : AbstractValidator<PropertyType>
{
    public PropertyTypeValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}
